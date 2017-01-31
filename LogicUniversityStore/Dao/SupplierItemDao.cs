using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{

    public class SupplierItemDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public List<SupplierItem> GetSuppliersOfItem(Item item)
        {
            return db.SupplierItems.Where(x => x.Item.ItemID == item.ItemID && x.ActiveSupplier == true).ToList();
        }

        public string GetSupplierNameNumber(int SupplierId)
        {
            Supplier supplier = db.Suppliers.Where(x => x.SupplierID == SupplierId).FirstOrDefault();
            string name = supplier.SupplierName;
            string number = supplier.SupplierPhone;
            return name + " - " + number;
        }

        public Supplier GetSupplierObj(int SupplierId)
        {
            return db.Suppliers.Where(x => x.SupplierID == SupplierId).FirstOrDefault();
        }
    }
}