using LogicUniversityStore.Model;
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
                    lblUser.Text = user.FirstName + " " + user.LastName;
                    lblUserName.Text = String.Format("{0} - {1}", user.FirstName, user.Role.RoleName);
                }
                else
                {
                    Response.Redirect("~/View/Login.aspx");
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/View/Login.aspx");
        }
    }
}