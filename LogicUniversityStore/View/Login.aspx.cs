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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LUUser user = new UserController().ValidateUser(txtEmail.Text, txtPwd.Text);
            if (user == null)
            {
                lblMsg.Text = "Please check credentials";
                return;
            }
            Session["User"] = user;
            Roles userROle = (Roles)Enum.Parse(typeof(Roles), user.Role.RoleCode);
            switch (userROle)
            {
                case Roles.EMP:
                    Response.Redirect("~/View/Department/Employee/EmpMain.aspx");
                    break;
                case Roles.REP:
                    Response.Redirect("~/View/Department/Employee/EmpMain.aspx");
                    break;
                case Roles.HOD:
                    Response.Redirect("~/View/Department/Hod/HodMain.aspx");
                    break;
                case Roles.CLERK:
                    Response.Redirect("~/View/Store/Clerk/ClrkMain.aspx");
                    break;
                case Roles.MANAGER:
                    Response.Redirect("~/View/Store/Manager/ManagerMain.aspx");
                    break;
                case Roles.SUPERVISOR:
                    Response.Redirect("~/View/Store/Supervisor/SupervisorMain.aspx");
                    break;
            }
        }
    }
}