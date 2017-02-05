using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Employee
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LUUser user = (LUUser)Session["user"];
            if (user != null)
            {
                List<Requisition> req = new List<Requisition>();
                req = new ApproveRejectReqController().getRequestedRequisitionHod(user.DepartmentID.Value);
                lblPendingApprovalM.Text = req.Count.ToString();
            }
        }
    }
}