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

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        RetreiveReqController controller;
        RetrievalDao dao = new RetrievalDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
               controller = new RetreiveReqController(GetAllRequisition());
                Dictionary<RequisitionItem, MainRow> dic = controller.GetRow();
                gvRetrieval.RowDataBound += GvRetrieval_RowDataBound;
                gvRetrieval.DataSource = dic;
                gvRetrieval.DataBind();
            }
        }

        private void GvRetrieval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                controller = new RetreiveReqController(GetAllRequisition());
                KeyValuePair<RequisitionItem, MainRow> item = (KeyValuePair<RequisitionItem, MainRow>)e.Row.DataItem;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gvChild = (GridView)e.Row.FindControl("gvChild");
                    gvChild.DataSource = item.Value.DictionaryMap;
                    gvChild.DataBind();

                }
            }
        }

      

        private List<Requisition> GetAllRequisition()
        {
            int id = Convert.ToInt32(Session["retId"]);
           return dao.GetAllRequistion(dao.Find(id));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Store/Clerk/RetrievalForm.aspx");
        }
    }
}