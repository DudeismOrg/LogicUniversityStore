using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
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
                gvRetrieval.DataSource =dic;
                gvRetrieval.DataBind();
            }
        }
    }
}