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
        public Dictionary<RequisitionItem, MainRow> requistionDic;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["reqListRetrieval"] != null)
            {
                controller = new RetreiveReqController((List<Requisition>)Session["reqListRetrieval"]);
                Dictionary<RequisitionItem, MainRow> dic = controller.GetRow();
                requistionDic = controller.GetRow();
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
            ret.Retriever = ((LUUser)Session["User"]).UserID;
            ret.IsCollected = false;
            RetrievalDao dao = new RetrievalDao();
            StockCardDao scDao = new StockCardDao();
            dao.Create(ret);

            foreach (var req in reqList)
            {
                dao.db.Requisitions.Find(req.ReqID).Status = RequisitionStatus.Allocated.ToString();
                foreach (var item in req.RequisitionItems)
                {
                   RequisitionItem dbItem = dao.db.RequisitionItems.Find(item.ReqItemID);
                    dbItem.ApprovedQuantity = item.ApprovedQuantity;
                    dbItem.RetrievalID = ret.RetrievalID;
                    if(item.ApprovedQuantity < item.NeededQuantity)
                    {
                        dbItem.IsOutstanding = true;
                    }
                }
            }
            dao.db.SaveChanges();
            Session["reqListRetrieval"] = null;
            Session["reqList"] = null;
            Session["lockedItem"] = null;
            string path = Request.ApplicationPath+ "View/Store/Clerk/ProcessRequest.aspx";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alertRedirect('Retreval Form Generated for selected Requsitions !!!','"+ path + "')", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["reqListRetrieval"] = null;
            Response.Redirect("/View/Store/Clerk/ProcessRequest.aspx?IsAlter=cancell");
        }
    }
}