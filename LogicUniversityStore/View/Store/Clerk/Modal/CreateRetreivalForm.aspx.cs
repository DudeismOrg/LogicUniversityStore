using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Clerk.Modal
{
    public partial class RetrievalForm : System.Web.UI.Page
    {
        private RetreiveReqController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["reqListRetrieval"] != null)
            {
                controller = new RetreiveReqController((List<Requisition>)Session["reqListRetrieval"]);
                Dictionary<RequisitionItem, MainRow> dic = controller.GetRow();
                gvRetrieval.RowDataBound += GvRetrieval_RowDataBound; 
                gvRetrieval.DataSource =dic;
                gvRetrieval.DataBind();
                
            }
        }

        private void GvRetrieval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                controller = new RetreiveReqController((List<Requisition>)Session["reqListRetrieval"]);
                KeyValuePair<RequisitionItem, MainRow> item = (KeyValuePair<RequisitionItem, MainRow>)e.Row.DataItem;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gvChild = (GridView)e.Row.FindControl("gvChild");
                    gvChild.DataSource = item.Value.DictionaryMap;
                    gvChild.DataBind();

                }
            }
        }

        protected void btnGenerateR_Click(object sender, EventArgs e)
        {
            List<Requisition> reqList;
            reqList = (List<Requisition>)Session["reqListRetrieval"];

            if (reqList.Count == 0) throw new InvalidConstructorException("please check the Requistions for retrieval");
            Retrieval ret = new Retrieval();
            ret.RetrievalDate = DateTime.Now.Date;
            ret.RetrievalNumber = new Common().GetRefNumber();
            RetrievalDao dao = new RetrievalDao();
            StockCardDao scDao = new StockCardDao();
            dao.Create(ret);
            foreach (var requisition in reqList)
            {
              Requisition req =  dao.db.Requisitions.Find(requisition.ReqID);
                foreach (var item in req.RequisitionItems)
                {
                    item.RetrievalID = ret.RetrievalID;
                    
                }
                req.Status = RequisitionStatus.Allocated.ToString();
                dao.db.SaveChanges();
                
            }
            Session["reqListRetrieval"] = null;

            Response.Redirect("/View/Store/Clerk/ProcessRequest.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["reqListRetrieval"] = null;
            Response.Redirect("/View/Store/Clerk/ProcessRequest.aspx");
        }
    }
}