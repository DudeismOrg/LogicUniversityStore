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
                itemDao = new ItemDao();
                DdlCategories.DataSource = reqController.GetCategories();
                DdlCategories.DataValueField = "CategoryID";
                DdlCategories.DataTextField = "CategoryCode";
                DdlCategories.DataBind();
            }

            int catId = Convert.ToInt32(DdlCategories.SelectedValue);
            category = reqController.CategoryDao.GetCategory(catId);
            if (DdlItems.SelectedValue != null && !DdlItems.SelectedValue.Equals(""))
            {
                item = new ItemDao().GetItem(Convert.ToInt32(DdlItems.SelectedValue));
                lblUnit.Text = item.UOM;
            }
            else
            {
                DdlItems.DataSource = category.Items;
                DdlItems.DataTextField = "ItemName";
                DdlItems.DataValueField = "ItemID";
                DdlItems.DataBind();
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
            LUUser user = (LUUser) Session["User"];
            if (user == null) throw new InvalidOperationException("User Is not valid");
            if (ViewState["items"] != null)
            {
                items = (List<CartItem>)ViewState["items"];
                RequisitionItemDao dao = new RequisitionItemDao();
                Requisition requisition = new Requisition();
                requisition.ReqDate = System.DateTime.Now;
                requisition.ReqNumber = new Random().Next().ToString(); //Todo 
                requisition.Status = RequisitionStatus.Requested.ToString();
                requisition.RequesterID = user.UserID; // Todo: need to change later once login up
                requisition.DepartmentID = user.DepartmentID.Value; // Todo: same
                requisition.RecieveByID =user.Department.HodID;  //Todo: same
                dao.db.Requisitions.Add(requisition);
                foreach (var cartItem in items)
                {
                    RequisitionItem item = new RequisitionItem();
                    item.ItemID = cartItem.SupplierItem.SupplierItemId;
                    item.NeededQuantity = cartItem.Quantity;
                    item.ReqID = requisition.ReqID;
                    item.IsOutstanding = false;
                    dao.db.RequisitionItems.Add(item);
                }
                dao.db.SaveChanges();
                ViewState["items"] = new List<CartItem>();
                gvReqItems.DataSource = null;
                gvReqItems.DataBind();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ViewState["items"] = new List<CartItem>();
            gvReqItems.DataSource = null;
            gvReqItems.DataBind();
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
    }
}