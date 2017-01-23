using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class StockCardDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public StockCardDao()
        {
            
        }

        public List<StockCard> GetAllInStock()
        {
            return db.StockCards.ToList();
        }

        public int GetProductCountInStock(int itemID)
        {
            StockCard card = db.StockCards.Where(s => s.ItemID == itemID).FirstOrDefault();
            if(card != null)
            {
                return card.OnHandQuantity.Value;
            }
            return -1;
        }

        public int GetLockedProductCountInStock(int itemID)
        {
            StockCard card = db.StockCards.Where(s => s.ItemID == itemID).FirstOrDefault();
            if (card != null)
            {
                return card.LockedQuantity.Value;
            }
            return 0;
        }


    }
}