using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class AdjustmentDao
    {
        LogicUniStoreModel db;
        public AdjustmentDao(LogicUniStoreModel dbContext)
        {
            db = dbContext;
        }

        public void CreateAdjustment(StockAdjustment adjustment)
        {
            db.StockAdjustments.Add(adjustment);
            db.SaveChanges();
        }

        public void updateStockCard(List<StockAdjustmentItem> adjItems)
        {
            foreach(StockAdjustmentItem adjItem in adjItems)
            {
                StockCard cart = db.StockCards.Where(item => adjItem.ItemID == item.ItemID).FirstOrDefault();
                cart.OnHandQuantity = cart.OnHandQuantity - adjItem.CountQuantity;
                db.SaveChanges();
            }
        }

        public StockAdjustment getAdjustment(String adjustmentNumber)
        {
            return db.StockAdjustments.Where(x => x.SockAdjustmentNumber.Equals(adjustmentNumber)).First();
        }

        public int getOnHandQty(int itemId)
        {
           StockCard card=db.StockCards.Where(x => x.ItemID == itemId).FirstOrDefault();
           return Convert.ToInt32(card.OnHandQuantity);

        }
        
    }
}