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

        public int GetProductCountInStock(int itemID)
        {
            StockCard card = db.StockCards.Where(s => s.ItemID == itemID).FirstOrDefault();
            if(card != null)
            {
                return card.OnHandQuantity.Value;
            }
            return -1;
        }
    }
}