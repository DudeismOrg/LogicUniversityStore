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

        public int GetProductCountInStock(int supplierItemId)
        {
            StockCard card = db.StockCards.Where(s => s.ItemID == supplierItemId).FirstOrDefault();
            if (card == null) throw new ArgumentException("supplierItemID is not Valid");

                return card.OnHandQuantity.Value;
          
        }

        public int GetLockedProductCountInStock(int supplierItemId)
        {
            StockCard card = db.StockCards.Where(s => s.ItemID == supplierItemId).FirstOrDefault();
            if (card == null) throw new ArgumentException("supplierItemID is not Valid");
            if (card.LockedQuantity == null)
            {
                card.LockedQuantity = 0;
                db.SaveChanges();
            }
                return card.LockedQuantity.Value;
           
        }

        public void AddLockedQuantityToStock(int  supplierItemID,int quantity)
        {
            StockCard card = db.StockCards.Find(supplierItemID);
            if (card == null) throw new ArgumentException("supplierItemID is not Valid");
            if (card.LockedQuantity == null) card.LockedQuantity = 0;
            if(card.LockedQuantity <= card.OnHandQuantity)
            {
                card.LockedQuantity = +quantity;
            }

            db.SaveChanges();
        }


    }
}