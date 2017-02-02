using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
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
            foreach(StockCard item in allItemsInStock)
            {
                if (item.OnHandQuantity < item.SupplierItem.Item.ReorderLevel)
                {
                    List<SupplierItem> suppliersItems = SupplierItemDao.GetSuppliersOfItem(item.SupplierItem.Item);
                    StockReorder.Add(item.SupplierItem.Item, suppliersItems);
                    reorderItem.Add(item.SupplierItem.Item);
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

        public List<Supplier> GetSuppliers()
        {
            return new ItemDao().GetSuppliers();
        }
    }
}