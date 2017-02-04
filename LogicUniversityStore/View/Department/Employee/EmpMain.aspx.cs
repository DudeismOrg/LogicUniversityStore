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
    public partial class EmpMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LUUser user = (LUUser)Session["user"];
            List<Requisition> req = new List<Requisition>();
            req = new ApproveRejectReqController().getRequestedRequisitionHod(user.DepartmentID.Value);
            lblPendingApproval.Text = req.Count.ToString();
        }
    }
}