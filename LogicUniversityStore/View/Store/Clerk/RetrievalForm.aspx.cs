using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class RetrievalForm : System.Web.UI.Page
    {
        RetreiveReqController controller = new RetreiveReqController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvRetrievList.DataSource = controller.GetAllRetrieval();
                gvRetrievList.DataBind();
            }
               
           
        }

        protected void gvRetrievList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                //  gvRetrievList.Rows[index];


                Retrieval r = controller.FindRetrieval(index);
                List<Requisition> reqList = controller.GetAllRequistion(r);
                Session["retId"] = index;
               Response.Redirect("/View/Store/Clerk/ViewRetrieval.aspx");
            }
        }
    }
}