using LogicUniversityStore.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Hod
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        ApproveRejectReqController reqController = new ApproveRejectReqController();
        int reqId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reqId = Convert.ToInt32(Request.QueryString["id"]);
                gvRequisitionDetails.DataSource=reqController.getRequisitionItemList(reqId);
                gvRequisitionDetails.DataBind();
            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            reqId= Convert.ToInt32(Request.QueryString["id"]);
            reqController.approveRequisition(reqId);
            Response.Redirect("ApproveReject.aspx");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            reqId = Convert.ToInt32(Request.QueryString["id"]);
            reqController.rejectRequisition(reqId);
            Response.Redirect("ApproveReject.aspx");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveReject.aspx");
        }
    }
}