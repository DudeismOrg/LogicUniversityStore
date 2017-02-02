using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class PurchaseOrderController
    {
        public ItemDao ItemDao { get; set; }
        public StockCardDao StockCardDao { get; set; }
        public SupplierItemDao SupplierItemDao { get; set; }
        public Dictionary<Item, List<SupplierItem>> StockReorder;

        public PurchaseOrderController()
        {
            ItemDao = new ItemDao();
            StockCardDao = new StockCardDao();
            SupplierItemDao = new SupplierItemDao();
            StockReorder = new Dictionary<Item, List<SupplierItem>>();
        }

        public List<Item> GetItems()
        {
            List<Item> reorderItem = new List<Item>();
            List<StockCard> allItemsInStock = StockCardDao.GetAllInStock();
            foreach (StockCard item in allItemsInStock)
            {
                if (item.OnHandQuantity < item.Item.ReorderLevel)
                {
                    List<SupplierItem> suppliersItems = SupplierItemDao.GetSuppliersOfItem(item.Item);
                    StockReorder.Add(item.Item, suppliersItems);
                    reorderItem.Add(item.Item);
                }
            }

            return reorderItem;
        }

        public string supplierNameNumber(int suplietId)
        {
            String NameNumber = SupplierItemDao.GetSupplierNameNumber(suplietId);
            return NameNumber;
        }

        public Supplier GetSuplier(int suplietId)
        {
            return SupplierItemDao.GetSupplierObj(suplietId);
        }

        public List<SupplierItem> getAllSuplierItems(Item item)
        {
            List<SupplierItem> suppliersItems = SupplierItemDao.GetSuppliersOfItem(item);
            return suppliersItems;
        }

        public void SavePurchaseOrder(List<PurchaseOrderUtil> newPOUlist)
        {
            PoBatchDao dao = new PoBatchDao();
            PurchaseOrderDao pdao = new PurchaseOrderDao();
            PurchaseOrderItemDao poitem = new PurchaseOrderItemDao();

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
            PurchaseOrderDao pdao = new PurchaseOrderDao();
            Dictionary<PurchaseOrder, List<PurchaseOrderItems>> poitemsList = new Dictionary<PurchaseOrder, List<PurchaseOrderItems>>();

            foreach (PurchaseOrderUtil npo in newPOUlist)
            {
                PurchaseOrder po = new PurchaseOrder();
                po.PuchaseOrderNo = npo.PoNumber;
                po.OrderDate = npo.OrderDate;
                po.DeliveryAddress = "";
                po.POStatus = "Requested";
                po.SupplierID = npo.Supplier.SupplierID;
                po.DONumber = "";
                po.PORemark = npo.Remark;
                po.ExpectedDeliveryDate = Convert.ToDateTime(npo.ExpectedDeliveryDate);
                po.POBatchID = batch.POBatchID;
                pdao.db.PurchaseOrders.Add(po);
                pdao.db.SaveChanges();

                poitemsList.Add(po, npo.Items);
            }

            PersistPoItems(poitemsList);

        }


        public void PersistPoItems(Dictionary<PurchaseOrder, List<PurchaseOrderItems>> poitemsList)
        {
            PurchaseOrderItemDao poitem = new PurchaseOrderItemDao();
            foreach (KeyValuePair<PurchaseOrder, List<PurchaseOrderItems>> poi in poitemsList)
            {
                foreach (PurchaseOrderItems itm in poi.Value)
                {
                    PurchaseOrderItem items = new PurchaseOrderItem();
                    items.PurchaseOrderID = poi.Key.PurchaseOrderID;
                    items.RequestedQuantity = itm.ReorderQuantity;
                    items.ItemID = itm.PoItem.GetSupplierItem().ItemID;
                    items.UnitPrice = poitem.GetUnitPrice(itm.PoItem, itm.PoSupplier);
                    poitem.db.PurchaseOrderItems.Add(items);
                    poitem.db.SaveChanges();
                }
            }

        }

    }
}