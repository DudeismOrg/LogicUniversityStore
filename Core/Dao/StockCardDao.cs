using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class StockCardDao
    {
        public LogicUniStoreModel db;

        public StockCardDao()
        {
            db = new LogicUniStoreModel();
        }

        public StockCardDao(LogicUniStoreModel context)
        {
            db = context;
        }

        public List<StockCard> GetAllInStock()
        {
            return db.StockCards.ToList();
        }

        public int GetProductCountInStock(int itemID)
        {
            StockCard card = db.StockCards.Where(s => s.ItemID == itemID).FirstOrDefault();
            if (card == null)
            {
                Item item = db.Items.Find(itemID);
                if ( item != null)
                {
                    StockCard c = new StockCard();
                    c.ItemID = itemID;
                    c.OnHandQuantity = 0;
                    c.Remarks = "Valid";
                    db.StockCards.Add(c);
                    db.SaveChanges();
                }else
                {
                    throw new ArgumentException("Item Id  is not Valid");
                }
            }
                return card.OnHandQuantity.Value;
          
        }

        internal void UpdateStockItemOnRetrieval(int itemId, int collectedQty)
        {
            StockCard stock = db.StockCards.Where(s => s.ItemID == itemId).FirstOrDefault();
            stock.OnHandQuantity = stock.OnHandQuantity - collectedQty;
            db.SaveChanges();
        }

        internal void updateStockCardByPurchaseDelivery(Item item, int receivedQuantity)
        {
            StockCard stock = db.StockCards.Where(i => i.ItemID == item.ItemID).FirstOrDefault();
            int currentOnhandQty = stock.OnHandQuantity.HasValue ? stock.OnHandQuantity.Value : 0;
            stock.OnHandQuantity = currentOnhandQty + receivedQuantity;
            db.SaveChanges();
        }

        public void UpdateItemInStock(int itemID, int Quantity)
        {
            StockCard card = GetStockCardByItemId(itemID);
            if(card == null) throw new ArgumentException("Item Id  is not Valid");
            card.OnHandQuantity += Quantity;
            if (card.OnHandQuantity < 0) throw new InvalidOperationException("On hand quanity for SupplierItemID " + itemID + " is going negative. ItemName: " + card.Item.ItemName);
            db.SaveChanges();
        }

      
        public StockCard GetStockCardByItemId(int ItemId)
        {
            StockCard card = db.StockCards.Where(s => s.ItemID == ItemId).FirstOrDefault();
            return card;
        }

        public void updateStockCardByAdjustment(int itemId, int adjustQuantity)
        {
            StockCard card = db.StockCards.Where(x => x.ItemID == itemId).FirstOrDefault();
            int onhandQty = card.OnHandQuantity.Value + adjustQuantity; 
            card.OnHandQuantity =onhandQty;           
            if (card.OnHandQuantity < 0) throw new InvalidOperationException("On hand quanity for SupplierItemID " + itemId + " is going negative. ItemName: " + card.Item.ItemName);
            db.SaveChanges();
            
        }

    }
}