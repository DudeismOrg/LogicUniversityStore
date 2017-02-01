using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class AdjustmentVoucherSupervisorController
    {
        public AdjustmentItemDao adj;
        public AdjustmentDao adao;
        public ItemDao idao;
        public StockCardDao sdao;

        public AdjustmentVoucherSupervisorController()
        {
            adj = new AdjustmentItemDao();
            adao = new AdjustmentDao();
            idao = new ItemDao();
            sdao = new StockCardDao();
        }
        public List<StockAdjustmentItem> getAdjustmentItemsSupervisor()
        {
            return adj.getAdjustmentItemsSupervisor();
        }

        public Item GetItem(String itemName)
        {
            return idao.GetItem(itemName);
        }

        public StockAdjustment getAdjustment(String adjustmentNumber)
        {
            return adao.getAdjustment(adjustmentNumber);
        }

        public void approveAdjustmentItem(int adjustmentId,int itemId)
        {
            adj.approveAdjustmentItem(adjustmentId, itemId);
        }

        public void updateStockCardByAdjustment(int itemId,int adjustQuantity)
        {
            sdao.updateStockCardByAdjustment(itemId, adjustQuantity); 
        }
    }
}