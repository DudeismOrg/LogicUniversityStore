using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class AdjustmentVoucherManagerController
    {
        public AdjustmentItemDao adj;
        public AdjustmentDao adao;
        public ItemDao idao;
        public StockCardDao sdao;

        public AdjustmentVoucherManagerController()
        {
            LogicUniStoreModel db = new LogicUniStoreModel();
            adj = new AdjustmentItemDao();
            adao = new AdjustmentDao(db);
            idao = new ItemDao();
            sdao = new StockCardDao();
        }

        public List<StockAdjustmentItem> getAdjustmentItemsManager()
        {
            return adj.getAdjustmentItemsManager();
        }

        public StockAdjustment getAdjustment(String adjustmentNumber)
        {
            return adao.getAdjustment(adjustmentNumber);
        }

        public Item GetItem(String itemName)
        {
            return idao.GetItem(itemName);
        }

        public void approveAdjustmentItem(int adjustmentId, int itemId)
        {
            adj.approveAdjustmentItem(adjustmentId, itemId);
        }

        public void rejectAdjustmentItem(int adjustmentId, int itemId)
        {
            adj.rejectAdjustmentItem(adjustmentId, itemId);
        }

        public void updateStockCardByAdjustment(int itemId, int adjustQuantity)
        {
            sdao.updateStockCardByAdjustment(itemId, adjustQuantity);
        }
    }
}