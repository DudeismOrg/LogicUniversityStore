using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class PurchaseOrderItemDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public PurchaseOrderItemDao()
        {
            
        }


        public double GetUnitPrice(Item itm, Supplier supp)
        {
            SupplierItem supplierItems = db.SupplierItems.Where(d => d.ItemID == itm.ItemID && d.SupplierID == supp.SupplierID).FirstOrDefault();
            double price = supplierItems.Price.HasValue ?  supplierItems.Price.Value : 0;
            return price;
        }

        internal List<PurchaseOrderItem> FindAllItemsByPOId(int poId)
        {
            List<Item> itemList = new List<Item>();
            List<PurchaseOrderItem> poItems = db.PurchaseOrderItems.Where(e => e.PurchaseOrderID == poId).ToList();
            foreach(PurchaseOrderItem p in poItems)
            {
                itemList.Add(p.SupplierItem.Item);
            }
            return poItems;
        }

        internal Item getTheItemFromPOItem(int poItemId)
        {
            PurchaseOrderItem poitm = db.PurchaseOrderItems.Where(o => o.PurchaeOrderItemID == poItemId).FirstOrDefault();
            return poitm.SupplierItem.Item;
        }

        internal void SaveDOForPOItems(int poItemId, int receivedQuantity)
        {
            PurchaseOrderItem poItm = db.PurchaseOrderItems.Where(p => p.PurchaeOrderItemID == poItemId).FirstOrDefault();
            poItm.ReceivedQuantity = receivedQuantity;
            db.SaveChanges();
        }
    }
}