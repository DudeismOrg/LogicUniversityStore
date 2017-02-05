using Core.Controller;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Employee
{
    public partial class RequisitionForm : System.Web.UI.Page
    {
        public ApplyReqController reqController = new ApplyReqController();
        private List<CartItem> items;
        private Category category;
        private Item item;
        private ItemDao itemDao;
        static string requisitionNum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["items"] == null)
                {
                    items = new List<CartItem>();
                    ViewState["items"] = items;
                    gvReqItems.DataSource = items;
                    gvReqItems.DataBind();
                }
                lblReqNum.Text = requisitionNum = "DDS/" + DateTime.Now.Month + "/" + DateTime.Now.ToString("HHmm");
                itemDao = new ItemDao();
                DdlCategories.DataSource = reqController.GetCategories();
                DdlCategories.DataValueField = "CategoryID";
                DdlCategories.DataTextField = "CategoryCode";
                DdlCategories.DataBind();
            }


            if (ViewState["items"] != null)
            {
                items = (List<CartItem>)ViewState["items"];
                for (int i = 0; i < items.Count; i++)
                {
                    GridViewRow row = gvReqItems.Rows[i];
                    string amount = ((TextBox)row.FindControl("tbQuantity")).Text;
                    items[i].Quantity = (amount != null || !amount.Equals("")) ? Convert.ToInt32(amount) : items[i].Quantity;

                }
                ViewState["items"] = items;
            }

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            Item item = null;
            if (DdlCategories.SelectedValue != null && !DdlCategories.SelectedValue.Equals(""))
            {
                int catId = Convert.ToInt32(DdlCategories.SelectedValue);
                category = reqController.CategoryDao.GetCategory(catId);

                if (DdlItems.SelectedValue != null && !DdlItems.SelectedValue.Equals(""))
                {
                    item = new ItemDao().GetItem(Convert.ToInt32(DdlItems.SelectedValue));
                    lblUnit.Text = item.UOM;
                }
            }
            if (item == null) throw new InvalidOperationException("Item is not selected here");


            CartItem rItem = new CartItem();

            rItem.SupplierItem = item.GetSupplierItem();
            rItem.Quantity = Convert.ToInt32(tbAmount.Text);
            rItem.Category = item.Category;
            items = (ViewState["items"] == null ? new List<CartItem>() : (List<CartItem>)ViewState["items"]);
            if (items.Contains(rItem))
            {
                items.Find(i => i.SupplierItem.ItemID == rItem.SupplierItem.ItemID).Quantity += rItem.Quantity;
            }
            else
            {
                items.Add(rItem);

            }
            ViewState["items"] = items;
            gvReqItems.DataSource = items;
            gvReqItems.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LUUser user = (LUUser)Session["User"];
            if (user == null) throw new InvalidOperationException("User Is not valid");
            if (ViewState["items"] != null)
            {
                items = (List<CartItem>)ViewState["items"];
                RequisitionItemDao dao = new RequisitionItemDao();
                Requisition requisition = new Requisition();
                requisition.ReqDate = System.DateTime.Now;
                requisition.ReqNumber = requisitionNum; //Todo 
                requisition.Status = RequisitionStatus.Requested.ToString();
                requisition.RequesterID = user.UserID; // Todo: need to change later once login up
                requisition.DepartmentID = user.DepartmentID.Value; // Todo: same
                requisition.RecieveByID = user.Department.HodID;  //Todo: same
                requisition.Remark = tbRemarks.Text;
                dao.db.Requisitions.Add(requisition);
                foreach (var cartItem in items)
                {
                    RequisitionItem item = new RequisitionItem();
                    item.SupplierItemID = cartItem.SupplierItem.SupplierItemId;
                    item.NeededQuantity = cartItem.Quantity;
                    item.ReqID = requisition.ReqID;
                    item.IsOutstanding = false;
                    dao.db.RequisitionItems.Add(item);
                }
                dao.db.SaveChanges();

                #region Send Notifications

                NotificationController ctl = new NotificationController();
                ctl.CreateNotification(
                    user.UserID, string.Format("New approval Requisition request {0}", requisition.ReqNumber), NotificationStatus.Created, Roles.HOD, user.DepartmentID.Value
                    );
                string toEmailIds = new UserController().GetToEmailIds(Roles.HOD, user.DepartmentID.Value); //To which role the email should be sent
                ctl.SendEmail("vasu4dworld@gmail.com", toEmailIds, "New requisition approval request", "New Requisition has been for approval : " + requisition.ReqNumber);

                #endregion

                reset();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alertRedirect('Requested Submited for Approval !!!','EmpMain.aspx')", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void gvReqItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            if (ViewState["items"] != null)
            {
                items = (List<CartItem>)ViewState["items"];
                items.Remove(items[index]);
                ViewState["items"] = items;
                gvReqItems.DataSource = items;
                gvReqItems.DataBind();
            }
        }

        protected void DdlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catId = Convert.ToInt32(DdlCategories.SelectedValue);
            category = reqController.CategoryDao.GetCategory(catId);

            // item = new ItemDao().GetItem(Convert.ToInt32(DdlItems.SelectedValue));
            // lblUnit.Text = item.UOM;


            DdlItems.DataSource = category.Items;
            DdlItems.DataTextField = "ItemName";
            DdlItems.DataValueField = "ItemID";
            DdlItems.DataBind();

            if (DdlItems.SelectedValue != null && !DdlItems.SelectedValue.Equals(""))
            {
                item = new ItemDao().GetItem(Convert.ToInt32(DdlItems.SelectedValue));
                lblUnit.Text = item.UOM;
            }

        }

        protected void DdlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlItems.SelectedValue != null && !DdlItems.SelectedValue.Equals(""))
            {
                item = new ItemDao().GetItem(Convert.ToInt32(DdlItems.SelectedValue));
                lblUnit.Text = item.UOM;
            }


        }

        private void reset()
        {
            ViewState["items"] = new List<CartItem>();
            gvReqItems.DataSource = null;
            gvReqItems.DataBind();


            DdlCategories.DataSource = reqController.GetCategories();
            DdlCategories.DataValueField = "CategoryID";
            DdlCategories.DataTextField = "CategoryCode";
            DdlCategories.DataBind();

            if (DdlCategories.SelectedValue != null && !DdlCategories.SelectedValue.Equals(""))
            {
                int catId = Convert.ToInt32(DdlCategories.SelectedValue);
                category = reqController.CategoryDao.GetCategory(catId);
                DdlItems.DataSource = category.Items;
                DdlItems.DataBind();
            }
            tbAmount.Text = "";

        }
    }
}