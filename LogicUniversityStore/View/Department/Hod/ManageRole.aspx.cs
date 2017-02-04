using Core.Controller;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LogicUniversityStore.View.Department.Hod
{
    public partial class ManageRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateEmpList();
                PopulateRolesList();
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
            lblMessage.Text = string.Empty;
        }

        private void PopulateRolesList()
        {
            List<Role> roles = new UserController().GetRolesByDeptType("Faculty");
            lstRoles.DataSource = roles;
            lstRoles.DataBind();
            if (lstEmp.SelectedItem != null)
            {
                int userId = Convert.ToInt32(lstEmp.SelectedItem.Value);
                SetRole(userId);
            }
        }

        private void PopulateEmpList()
        {
            LUUser logUser = (LUUser)Session["user"];
            List<LUUser> users = new UserController().GetUsersByDeptCode(logUser != null && logUser.Department != null ? logUser.Department.DepartmentID : 0);
            lstEmp.DataSource = users;
            lstEmp.DataBind();
            if (users.Count > 0)
                lstEmp.Items[0].Selected = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string roleCode = string.Empty;
            foreach (ListViewItem lstItem in lstRoles.Items)
            {
                CheckBox cbk = (CheckBox)lstItem.FindControl("ckbRole");
                if (cbk.Checked)
                {
                    ListViewItem item = (ListViewItem)cbk.NamingContainer;
                    ListViewDataItem dataItem = (ListViewDataItem)item;
                    roleCode = lstRoles.DataKeys[dataItem.DisplayIndex].Value.ToString();
                }
            }

            if (new UserController().UpdateUserRole(Convert.ToInt32(lstEmp.SelectedItem.Value), roleCode))
                lblMessage.Text = "Role has been updated succesfully";

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PopulateEmpList();
            PopulateRolesList();
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        protected void lstEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearRoleSelection();
            //lstRoles.Items.Select(item => ((CheckBox)item.FindControl("chkRole")).Checked = false);
            int selectedVal = Convert.ToInt32(lstEmp.SelectedItem.Value);
            SetRole(selectedVal);
        }

        private void ClearRoleSelection()
        {
            foreach (ListViewItem item in lstRoles.Items)
            {
                CheckBox cbk = (CheckBox)item.FindControl("ckbRole");
                cbk.Checked = false;
            }
        }

        private void SetRole(int selectedVal)
        {
            LUUser user = new UserController().GetUserProfileByUserId(selectedVal);
            foreach (ListViewItem item in lstRoles.Items)
            {
                CheckBox cbk = (CheckBox)item.FindControl("ckbRole");
                if (user.Role.RoleName == cbk.Text)
                    cbk.Checked = true;
            }
        }

        protected void ckbRole_CheckedChanged(object sender, EventArgs e)
        {
            string code = GetSelectedRoleCode(sender);
            ClearRoleSelection();
            foreach (ListViewItem lstItem in lstRoles.Items)
            {
                ListViewDataItem dItem = (ListViewDataItem)lstItem;
                string itemCode = lstRoles.DataKeys[dItem.DisplayIndex].Value.ToString();
                if (code == itemCode)
                    ((CheckBox)lstItem.FindControl("ckbRole")).Checked = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
        }

        private string GetSelectedRoleCode(object sender)
        {
            CheckBox cb = (CheckBox)sender;
            ListViewItem item = (ListViewItem)cb.NamingContainer;
            ListViewDataItem dataItem = (ListViewDataItem)item;
            return lstRoles.DataKeys[dataItem.DisplayIndex].Value.ToString();
        }
    }
}