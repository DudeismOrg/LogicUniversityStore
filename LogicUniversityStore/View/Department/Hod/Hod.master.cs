using Core.Controller;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Hod
{
    public partial class Hod : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LUUser user = (LUUser)Session["user"];
            List<Requisition> req = new List<Requisition>();
            req = new CancelUpdateUnallocatedController().GetRequestedRequisitionListHod(user.DepartmentID.Value);
            lblAckReqs.Text = req.Count.ToString();
            
            List<Requisition>  recUnalo = new CancelUpdateUnallocatedController().GetApprovedRequisition(user.DepartmentID.Value);
            lblUpdateReqs.Text = recUnalo.Count.ToString();
        }

        private void ShowNotifications()
        {
            LUUser user = (LUUser)Session["User"];
        }
    }
}