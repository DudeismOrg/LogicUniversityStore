using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Model;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class DeliveryOrderConfirm : System.Web.UI.Page
    {
        public PurchaseOrder currentPurchaseOrder;
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["POId"] = Convert.ToInt32(Request.QueryString["poid"]);
            if (!IsPostBack)
            {
                PurchaseOrderController poControler = new PurchaseOrderController();
                int poId = Convert.ToInt32(Request.QueryString["poid"]);
                currentPurchaseOrder = poControler.findPOById(poId);
                List<PurchaseOrderItem> mainItem = poControler.FindAllItemsInPurchaseOrder(poId);
                gvPurchaseOrderItems.DataSource = mainItem;
                gvPurchaseOrderItems.DataBind();
            }
        }

        protected void btnSaveDo_click(object sender, EventArgs e)
        {
            PurchaseOrderController poControler = new PurchaseOrderController();
            StockCardController stockCardControl = new StockCardController();
            string doNumber = txtDoNumber.Text;
            foreach (GridViewRow row in gvPurchaseOrderItems.Rows)
            {
                int poItemId = Convert.ToInt32((row.Cells[0].FindControl("idVal") as TextBox).Text);
                int receivedQuantity = Convert.ToInt32((row.Cells[6].FindControl("txtQntyReceived") as TextBox).Text);
                poControler.SaveDoForPOItems(poItemId, receivedQuantity);
                stockCardControl.UpdateStockcardOnStockDelivery(poItemId, receivedQuantity);
            }
            int currentPOId = (int)ViewState["POId"];
            poControler.SaveDODetailsInPO(currentPOId, doNumber);
            Response.Redirect("DeliveryOrder.aspx");
        }
    }
}