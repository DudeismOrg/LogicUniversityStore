using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Hod
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        CancelUpdateUnallocatedController reqController = new CancelUpdateUnallocatedController();
        RequisitionItem ri = new RequisitionItem();

        DataTable dt;
        DataRow r;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //reqId = Convert.ToInt32(Request.QueryString["id"]);
                //gvRequisitionDetails.DataSource=reqController.getRequisitionItemList(reqId);
                //gvRequisitionDetails.DataBind();

                int reqId = Convert.ToInt32(Request.QueryString["id"]);
                List<RequisitionItem> items = reqController.getRequisitionItemList(reqId);

                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ItemName"), new DataColumn("NeededQuantity"), new DataColumn("UOM") });
                foreach (RequisitionItem i in items)
                {
                    r = dt.NewRow();
                    r["ItemName"] = i.SupplierItem.Item.ItemName;
                    r["NeededQuantity"] = i.NeededQuantity;
                    r["UOM"] = i.SupplierItem.Item.UOM;
                    dt.Rows.Add(r);
                }
                ViewState["dt"] = dt;
                bindGrid();
            }
        }

        protected void bindGrid()
        {
            gvRequisitionDetails.DataSource = (DataTable)ViewState["dt"];
            gvRequisitionDetails.DataBind();
        }

        protected void gvRequisitionDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            dt = (DataTable)ViewState["dt"];

            int reqId = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = dt.Rows[rowIndex];
            String itemName = dr["ItemName"].ToString();
            Item i = reqController.GetItem(itemName);
            int ItemId = i.ItemID;
            reqController.deleteRequisitionItem(reqId, ItemId);
            dt.Rows[rowIndex].Delete();
            ViewState["dt"] = dt;
            bindGrid();


        }



        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int reqId = Convert.ToInt32(Request.QueryString["id"]);
            String remark = txtRemark.Text;
            int rowNum = gvRequisitionDetails.Rows.Count;
            for (int i = 0; i < rowNum; i++)
            {
                String itemName = gvRequisitionDetails.Rows[i].Cells[0].Text.ToString();
                Item item = reqController.GetItem(itemName);
                int itemId = item.ItemID;
                TextBox tb = gvRequisitionDetails.Rows[i].FindControl("txtQty") as TextBox;
                int qty=Convert.ToInt32(tb.Text);
                reqController.updateRequisitionItem(reqId, itemId, qty);
               
            }
            reqController.approveRequisition(reqId,remark);
            Response.Redirect("CancelUpdateUnallocated.aspx");

            

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
           int reqId = Convert.ToInt32(Request.QueryString["id"]);
            String remark = txtRemark.Text;
            reqController.rejectRequisition(reqId,remark);
            Response.Redirect("CancelUpdateUnallocated.aspx");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("CancelUpdateUnallocated.aspx");
        }
    }
}