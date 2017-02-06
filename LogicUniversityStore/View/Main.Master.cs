using Core.Controller;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LUUser user = (LUUser)Session["User"];
                if (user != null)
                {
                    lblEmpName.Text = lblUser.Text = user.FirstName + " " + user.LastName;
                    lblUserName.Text = String.Format("{0} - {1}", user.FirstName, user.Role.RoleName);
                    if (user.Role.RoleCode == Roles.EMP.ToString() || user.Role.RoleCode == Roles.HOD.ToString() || user.Role.RoleCode == Roles.REP.ToString())
                    {
                        lblUserManDoc.NavigateUrl = "~/View/Store/Department.pdf";
                    }
                    else if (user.Role.RoleCode == Roles.CLERK.ToString() || user.Role.RoleCode == Roles.SUPERVISOR.ToString() || user.Role.RoleCode == Roles.MANAGER.ToString())
                    {
                        lblUserManDoc.NavigateUrl = "~/View/Store/Store.pdf";
                    }
                    ShowNotifications();

                }
                else
                {
                    Response.Redirect("~/View/Login.aspx");
                }
            }
        }

        protected void DeleteRow(object sender, GridViewDeleteEventArgs e)
        {
            LUUser user = (LUUser)Session["User"];
            int index = Convert.ToInt32(e.Keys[0]);
            new NotificationController().ChangeNotification(user.UserID, index, Util.NotificationStatus.Cleared);
            ShowNotifications();
        }

        List<Notification> notifications = null;
        private void ShowNotifications()
        {
            LUUser user = (LUUser)Session["User"];
            notifications = new NotificationController().GetNotificationsByRoleCode(user.Role.RoleCode, user.DepartmentID.Value);
            lblNotCount.Text = lblNotShortMsg.Text = notifications.Count().ToString();
            gvNots.DataSource = notifications;
            gvNots.DataBind();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/View/Login.aspx");
        }
    }
}