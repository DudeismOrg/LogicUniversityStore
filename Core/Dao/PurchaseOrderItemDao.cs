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

    }
}