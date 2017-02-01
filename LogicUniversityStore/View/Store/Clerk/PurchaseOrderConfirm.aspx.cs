using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Model;
using LogicUniversityStore.Dao;
using System.Data.Entity.Validation;

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

            try
            {
                POBatch batch = new POBatch();
                batch.POBatchDate = DateTime.Now;
                batch.Printed = false;
                dao.db.POBatches.Add(batch);
                dao.db.SaveChanges();

                PersistPO(newPOUlist, batch);
            }
            catch (DbEntityValidationException ea)
            {
                foreach (var eve in ea.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw;
            }
        }


        public void PersistPO(List<PurchaseOrderUtil> newPOUlist, POBatch batch)
        {
            PurchaseOrder po = new PurchaseOrder();
            PurchaseOrderDao pdao = new PurchaseOrderDao();
            PurchaseOrderItemDao poitem = new PurchaseOrderItemDao();

            foreach (PurchaseOrderUtil npo in newPOUlist)
            {
                po = new PurchaseOrder();
                po.PuchaseOrderNo = npo.PoNumber;
                po.OrderDate = npo.OrderDate;
                po.DeliveryAddress = "";
                po.POStatus = "";
                po.SupplierID = npo.Supplier.SupplierID;
                po.DONumber = "";
                po.PORemark = npo.Remark;
                po.ExpectedDeliveryDate = Convert.ToDateTime(npo.ExpectedDeliveryDate);
                po.POBatchID = batch.POBatchID;
                pdao.db.PurchaseOrders.Add(po);
                pdao.db.SaveChanges();

                foreach (PurchaseOrderItems poi in npo.Items)
                {
                    PurchaseOrderItem items = new PurchaseOrderItem();
                    items.PurchaseOrder = po;
                    items.RequestedQuantity = poi.ReorderQuantity;
                    items.ItemID = poi.PoItem.GetSupplierItem().ItemID;
                    poitem.db.PurchaseOrderItems.Add(items);
                    poitem.db.SaveChanges();
                }
            }
            Response.Write("<script language='javascript'> alert('Purchase order saved successfully!!!'); </script>");
        }
    }
}