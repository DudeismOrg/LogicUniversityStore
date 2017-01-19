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
    public partial class RequisitionForm : System.Web.UI.Page
    {
        public ApplyReqController reqController { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            reqController = new ApplyReqController();

            if (!IsPostBack)
            {
                DdlCategories.DataSource = reqController.GetCategories();
                DdlCategories.DataValueField = "CategoryID";
                DdlCategories.DataTextField = "CategoryCode";
                DdlCategories.DataBind();
            }

            int catId = Convert.ToInt32(DdlCategories.SelectedValue);
            Category category = reqController.CategoryDao.GetCategory(catId);
            DdlItems.DataSource = category.Items;
            DdlItems.DataTextField = "ItemName";
            DdlItems.DataValueField = "ItemID";
            DdlItems.DataBind();
        }
    }
}