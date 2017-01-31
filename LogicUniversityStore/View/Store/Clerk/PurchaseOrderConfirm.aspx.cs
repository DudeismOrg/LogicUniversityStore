using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Model;
using LogicUniversityStore.Dao;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class PurchaseOrderConfirm : System.Web.UI.Page
    {
        List<PurchaseOrderUtil> finalPO;
        protected void Page_Load(object sender, EventArgs e)
        {
            finalPO = Session["selectedPO"] as List<PurchaseOrderUtil>;
            if (!IsPostBack)
            {
                fillGridView();
            }
        }


        public void fillGridView()
        {
            gvPurchaseOrders.DataSource = finalPO;
            gvPurchaseOrders.DataBind();
        }

        public void POnfirmPo_Click(object sender, EventArgs e)
        {
            List<PurchaseOrderUtil> newPOUlist = new List<PurchaseOrderUtil>();
            PoBatchDao dao = new PoBatchDao();
            PurchaseOrderDao pdao = new PurchaseOrderDao();
            PurchaseOrderItemDao poitem = new PurchaseOrderItemDao();

            foreach (GridViewRow row in gvPurchaseOrders.Rows)
            {
                int SuplierId = Convert.ToInt32((row.Cells[0].FindControl("idVal") as TextBox).Text);
                PurchaseOrderUtil pou = finalPO.Where(f => f.Supplier.SupplierID == SuplierId).FirstOrDefault();
                pou.Remark = (row.Cells[7].FindControl("supRemark") as TextBox).Text;
                pou.OrderDate = DateTime.Now;
                pou.PoNumber = SuplierId.ToString();
                newPOUlist.Add(pou);
            }

            POBatch batch = new POBatch();
            batch.POBatchDate = DateTime.Now;
            batch.Printed = false;
            dao.db.POBatches.Add(batch);
            dao.db.SaveChanges();

            foreach (PurchaseOrderUtil npo in newPOUlist)
            {
                PurchaseOrder po = new PurchaseOrder();
                po.ExpectedDeliveryDate = Convert.ToDateTime(npo.ExpectedDeliveryDate);
                po.OrderDate = npo.OrderDate;
                po.POBatch = batch;
                po.POBatchID = batch.POBatchID;
                po.PORemark = npo.Remark;
                po.PuchaseOrderNo = npo.PoNumber;
                po.Supplier = npo.Supplier;
                po.SupplierID = npo.Supplier.SupplierID;
                pdao.db.PurchaseOrders.Add(po);
                pdao.db.SaveChanges();

                foreach (PurchaseOrderItems poi in npo.Items)
                {
                    PurchaseOrderItem items = new PurchaseOrderItem();
                    items.PurchaseOrder = po;
                    items.RequestedQuantity = poi.ReorderQuantity;
                    items.SupplierItem = poi.PoItem.GetSupplierItem();
                    poitem.db.PurchaseOrderItems.Add(items);
                    poitem.db.SaveChanges();

                }
            }
            
            
        }

    }
}