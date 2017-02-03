using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class SpotAdjustment : System.Web.UI.Page
    {
        public ApplyReqController reqController = new ApplyReqController();
        private List<AdjustmentItem> lstAdjItems;
        private List<Category> lstCategories;
        private List<Item> lstItems;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setAdjustmentId();
                DdlCategories.DataSource = lstCategories = reqController.GetCategories();
                DdlCategories.DataValueField = "CategoryID";
                DdlCategories.DataTextField = "CategoryCode";
                DdlCategories.DataBind();
            }
            else
            {
                lstAdjItems = (List<AdjustmentItem>)ViewState["items"];
            }
        }

        private void setAdjustmentId()
        {
            lblAdjId.Text = "ADJ/" + (new Random().Next(10000, 99999)).ToString();
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (btnAddItem.Text == "Add Item")
            {
                if (ValidateItem())
                {
                    AdjustmentItem item = new AdjustmentItem(parseInt(DdlCategories.SelectedValue), DdlCategories.SelectedItem.Text,
                        parseInt(DdlItems.SelectedValue), DdlItems.SelectedItem.Text, parseInt(tbAmount.Text), tbRemarks.Text, lblUnits.Text);

                    lstAdjItems = (List<AdjustmentItem>)ViewState["items"];
                    if (lstAdjItems == null)
                        lstAdjItems = new List<AdjustmentItem>();
                    lstAdjItems.Add(item);
                }
                else
                {
                    lblMessage.Text = "Item has been already added.";
                }
            }
            else if (btnAddItem.Text == "Update")
            {
                AdjustmentItem item = lstAdjItems.Where(i => i.CategoryId == Convert.ToInt32(DdlCategories.SelectedValue) && i.ItemId == Convert.ToInt32(DdlItems.SelectedValue)).FirstOrDefault();
                item.CategoryId = Convert.ToInt32(DdlCategories.SelectedItem.Value);
                item.CategoryName = DdlCategories.SelectedItem.Text;
                item.ItemId = Convert.ToInt32(DdlItems.SelectedItem.Value);
                item.ItemName = DdlItems.SelectedItem.Text;
                item.Quantity = Convert.ToInt32(tbAmount.Text);
                item.Remarks = tbRemarks.Text;
            }
            ViewState["items"] = lstAdjItems;
            PopulateData();
            clearFields();
        }

        private bool ValidateItem()
        {
            return (lstAdjItems != null && lstAdjItems.Where(i => i.CategoryId == Convert.ToInt32(DdlCategories.SelectedValue) && i.ItemId == Convert.ToInt32(DdlItems.SelectedValue)).FirstOrDefault() != null) ? false : true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ViewState["items"] != null)
            {
                lstAdjItems = (List<AdjustmentItem>)ViewState["items"];
                AdjustmentController ctrl = new AdjustmentController();
                Adjustment adjustment = new Adjustment()
                {
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    Items = lstAdjItems,
                    Number = lblAdjId.Text
                };
                ctrl.CreateSpotAdjustment(adjustment);
                clearFields();
                gvReqItems.DataSource = null;
                gvReqItems.DataBind();
            }
        }

        private void clearFields()
        {
            DdlCategories.SelectedIndex = 0;
            DdlItems.ClearSelection();
            DdlItems.DataSource = null;
            DdlItems.DataBind();
            tbRemarks.Text = "";
            tbAmount.Text = "";
        }

        protected void DeleteRow(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = gvReqItems.Rows[index];
            lstAdjItems.Remove(lstAdjItems.Where(i => i.ItemId == Convert.ToInt32(gvReqItems.DataKeys[index].Value)).FirstOrDefault());
            ViewState["items"] = lstAdjItems;
            PopulateData();
            clearFields();
        }

        private void PopulateData()
        {
            gvReqItems.DataSource = lstAdjItems;
            gvReqItems.DataBind();
        }

        protected void EditRow(object sender, GridViewEditEventArgs e)
        {
            int index = Convert.ToInt32(e.NewEditIndex);
            GridViewRow row = gvReqItems.Rows[index];
            AdjustmentItem item = lstAdjItems.Where(i => i.CategoryName == row.Cells[0].Text && i.ItemName == row.Cells[1].Text).FirstOrDefault();

            DdlCategories.SelectedValue = item.CategoryId.ToString();
            DdlItems.SelectedValue = item.ItemId.ToString();
            tbAmount.Text = item.Quantity.ToString();
            lblUnits.Text = item.UnitOfMeasure.ToString();
            tbRemarks.Text = item.Remarks;
            btnAddItem.Text = "Update";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ViewState["items"] = null;
            gvReqItems.DataSource = null;
            gvReqItems.DataBind();
        }

        protected void DdlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstItems = reqController.GetItemsByCategoryId(parseInt(DdlCategories.SelectedItem.Value));
            DdlItems.DataSource = lstItems;
            DdlItems.DataValueField = "ItemID";
            DdlItems.DataTextField = "ItemName";
            DdlItems.DataBind();
            setUnitOfMeasure(lstItems);
        }

        private void setUnitOfMeasure(List<Item> items)
        {
            if (items.Count > 0)
            {
                lblUnits.Text = items[0].UOM;
            }
        }

        private int parseInt(string val)
        {
            int result;
            return int.TryParse(val, out result) ? result : 0;
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            PopulateData();
            clearFields();
        }
    }
}