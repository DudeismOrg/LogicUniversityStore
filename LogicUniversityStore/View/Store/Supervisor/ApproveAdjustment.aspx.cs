using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Supervisor
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public AdjustmentVoucherSupervisorController ctrl = new AdjustmentVoucherSupervisorController(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<StockAdjustmentItem> items = new List<StockAdjustmentItem>();
                items = ctrl.getAdjustmentItemsSupervisor();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("StockAdjustmentNumber"), new DataColumn("ItemName"), new DataColumn("CountQuantity"), new DataColumn("AdjustQuantity"), new DataColumn("Remark"), new DataColumn("AdjustmentAmount") });
                if (items != null)
                {
                    foreach (StockAdjustmentItem i in items)
                    {
                        DataRow r = dt.NewRow();
                        r["StockAdjustmentNumber"] = i.StockAdjustment.SockAdjustmentNumber;
                        r["ItemName"] = i.SupplierItem.Item.ItemName;
                        r["CountQuantity"] = i.CountQuantity;
                        r["AdjustQuantity"] = i.AdjustQuantity;
                        r["Remark"] = i.Remark;
                        r["AdjustmentAmount"] = (i.SupplierItem.Item.BasePrice) * (i.AdjustQuantity);
                        dt.Rows.Add(r);
                    }
                    gvAdjustmentItemList.DataSource = dt;
                    gvAdjustmentItemList.DataBind();
                }
            }
        }

        protected void gvAdjustmentItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String adjustmentNumber = gvAdjustmentItemList.SelectedRow.Cells[0].Text;
            int adjustmentId = ctrl.getAdjustment(adjustmentNumber).StockAdjustmentID;
            String itemName = gvAdjustmentItemList.SelectedRow.Cells[1].Text;
            Item item = ctrl.GetItem(itemName);
            int itemId = item.ItemID;
            ctrl.approveAdjustmentItem(adjustmentId, itemId);
            int adjustQuantity = Convert.ToInt32(gvAdjustmentItemList.SelectedRow.Cells[3].Text);
            //update stock card
            ctrl.updateStockCardByAdjustment(itemId, adjustQuantity);
            Response.Redirect("ApproveAdjustment.aspx");
        }       
        protected void gvAdjustmentItemList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String adjustmentNumber = gvAdjustmentItemList.Rows[e.RowIndex].Cells[0].Text;
            int adjustmentId = ctrl.getAdjustment(adjustmentNumber).StockAdjustmentID;
            String itemName = gvAdjustmentItemList.Rows[e.RowIndex].Cells[1].Text;
            Item item = ctrl.GetItem(itemName);
            int itemId = item.ItemID;
            //update status
            ctrl.rejectAdjustmentItem(adjustmentId, itemId);
            Response.Redirect("ApproveAdjustment.aspx");
        }
    }
}