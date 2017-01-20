using LogicUniversityStore.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Hod
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public ApproveRejectReqController reqController = new ApproveRejectReqController();
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                gvRequestedRequisition.DataSource = reqController.getRequestedRequisition();
                gvRequestedRequisition.DataBind();
            }
        }
    }
}