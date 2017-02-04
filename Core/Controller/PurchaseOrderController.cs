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
        public PoBatchDao POBatchDao { get; set; }
        public PurchaseOrderDao PODao { get; set; }
        public PurchaseOrderItemDao POItemDao { get; set; }

        public Dictionary<Item, List<SupplierItem>> StockReorder;

        public List<PurchaseOrderItem> FindAllItemsInPurchaseOrder(int poId)
        {
            return POItemDao.FindAllItemsByPOId(poId);
        }

        public PurchaseOrder findPOById(int poId)
        {
            return PODao.getPoById(poId);
        }

        public PurchaseOrderController()
        {
            ItemDao = new ItemDao();
            StockCardDao = new StockCardDao();
            SupplierItemDao = new SupplierItemDao();
            POBatchDao = new PoBatchDao();
            StockReorder = new Dictionary<Item, List<SupplierItem>>();
            PODao = new PurchaseOrderDao();
            POItemDao = new PurchaseOrderItemDao();
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

        public void SaveDODetailsInPO(int currentPOId, string doNumber)
        {
            PODao.SaveDOInPO(currentPOId, doNumber);
        }

        public void SaveDoForPOItems(int poItemId, int receivedQuantity)
        {
            POItemDao.SaveDOForPOItems(poItemId, receivedQuantity);
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

        public void SavePurchaseOrder(List<PurchaseOrderUtil> newPOUlist, LUUser user)
        {
            PurchaseOrderItemDao poitem = new PurchaseOrderItemDao();

            try
            {
                POBatch batch = new POBatch();
                batch.POBatchDate = DateTime.Now;
                batch.Printed = false;
                batch.GeneratedBy = user.UserID;
                POBatchDao.db.POBatches.Add(batch);
                POBatchDao.db.SaveChanges();

                PersistPO(newPOUlist, batch, user);
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

        

        public void PersistPO(List<PurchaseOrderUtil> newPOUlist, POBatch batch, LUUser user)
        {
            Dictionary<PurchaseOrder, List<PurchaseOrderItems>> poitemsList = new Dictionary<PurchaseOrder, List<PurchaseOrderItems>>();
            foreach (PurchaseOrderUtil npo in newPOUlist)
            {
                PurchaseOrder po = new PurchaseOrder();
                po.PuchaseOrderNo = npo.PoNumber;
                po.OrderEmpID = user.UserID;
                po.OrderDate = npo.OrderDate;
                po.DeliveryAddress = "Store Address";
                po.POStatus = PurchaseOrderStatus.Requested.ToString();
                po.SupplierID = npo.Supplier.SupplierID;
                po.DONumber = "";
                po.PORemark = npo.Remark;
                po.ExpectedDeliveryDate = Convert.ToDateTime(npo.ExpectedDeliveryDate);
                po.POBatchID = batch.POBatchID;
                PODao.db.PurchaseOrders.Add(po);
                PODao.db.SaveChanges();

                poitemsList.Add(po, npo.Items);
            }

            PersistPoItems(poitemsList,user);

        }


        public void PersistPoItems(Dictionary<PurchaseOrder, List<PurchaseOrderItems>> poitemsList, LUUser user)
        {
            foreach (KeyValuePair<PurchaseOrder, List<PurchaseOrderItems>> poi in poitemsList)
            {
                foreach (PurchaseOrderItems itm in poi.Value)
                {
                    PurchaseOrderItem items = new PurchaseOrderItem();
                    items.PurchaseOrderID = poi.Key.PurchaseOrderID;
                    items.RequestedQuantity = itm.ReorderQuantity;
                    items.ItemID = itm.PoItem.GetSupplierItem().ItemID;
                    items.UnitPrice = POItemDao.GetUnitPrice(itm.PoItem, itm.PoSupplier);
                    POItemDao.db.PurchaseOrderItems.Add(items);
                    POItemDao.db.SaveChanges();
                }
            }

        }

        public List<POBatch> getAllPoBatch()
        {
            return POBatchDao.GetAllPoBatch();
        }

        public bool CreatePO(POBatch poBactch, PurchaseOrder Order)
        {
            bool result = false;
            LogicUniStoreModel db = new LogicUniStoreModel();
            db.POBatches.Add(poBactch);
            db.SaveChanges();
            Order.POBatchID = poBactch.POBatchID;
            db.PurchaseOrders.Add(Order);
            result = db.SaveChanges() > 0 ? true : false;
            return result;
        }

        public List<PurchaseOrder> FindAllPurchaseOrderBySupplier(int suplierId)
        {
            return PODao.findPoBySupplierId(suplierId);
        }

        public List<PurchaseOrder> FindAllPurchaseOrderByBatch(int batchId)
        {
            return PODao.findPoByBatchId(batchId);
        }


        public Supplier GetSupplierById(int supplierId)
        {
            return SupplierItemDao.GetSupplierObj(supplierId);
        }

        public double GetUnitPrice(Item item, Supplier sup)
        {
            return new PurchaseOrderItemDao().GetUnitPrice(item, sup);
        }

        public Item GetItemByItemId(int itemId)
        {
            return new ItemDao().GetItem(itemId);
        }

        public List<Supplier> GetSuppliers()
        {
            return new ItemDao().GetSuppliers();
        }
    }
}