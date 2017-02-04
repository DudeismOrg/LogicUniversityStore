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
    public class StockCardController
    {
        public SupplierItemDao supplierItemDao { get; set; }
        public PurchaseOrderItemDao poItemDao { get; set; }
        public StockCardDao stockCardDao { get; set; }

        public StockCardController()
        {
            supplierItemDao = new SupplierItemDao();
            poItemDao = new PurchaseOrderItemDao();
            stockCardDao = new StockCardDao();
        }

        public void UpdateStockcardOnStockDelivery(int poItemId, int receivedQuantity)
        {
            Item item = poItemDao.getTheItemFromPOItem(poItemId);
            stockCardDao.updateStockCardByPurchaseDelivery(item, receivedQuantity);
        }

        public void UpdateStockItemOnRetreval(int itemId, int collectedQty)
        {
            stockCardDao.UpdateStockItemOnRetrieval(itemId, collectedQty);
        }
    }
}
