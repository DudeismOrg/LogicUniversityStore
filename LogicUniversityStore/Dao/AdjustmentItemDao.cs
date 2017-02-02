using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class AdjustmentItemDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public List<StockAdjustmentItem> getAdjustmentItemsSupervisor()
        {
            try
            {
                return db.StockAdjustmentItems.Where(x => (((x.SupplierItem.Item.BasePrice) * (x.AdjustQuantity)) <= 250) && (x.Status.Equals(AdjustmentStatus.Created.ToString()))).ToList();
            }
            catch(Exception ex)
            {
                return null;
            } 
        }

        public List<StockAdjustmentItem> getAdjustmentItemsManager()
        {
            try
            {
                return db.StockAdjustmentItems.Where(x => (((x.SupplierItem.Item.BasePrice) * (x.AdjustQuantity)) > 250) && (x.Status.Equals(AdjustmentStatus.Created.ToString()))).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void approveAdjustmentItem(int adjustmentId,int itemId)
        {
            StockAdjustmentItem item = db.StockAdjustmentItems.Where(x => x.StockAdjustmentID == adjustmentId && x.ItemID == itemId).FirstOrDefault();
            item.Status = AdjustmentStatus.Approved.ToString();         
            db.StockAdjustmentItems.Attach(item);
            var entry = db.Entry(item);
            entry.Property(e => e.Status).IsModified = true;            
            db.SaveChanges();
        }

        public void rejectAdjustmentItem(int adjustmentId, int itemId)
        {
            StockAdjustmentItem item = db.StockAdjustmentItems.Where(x => x.StockAdjustmentID == adjustmentId && x.ItemID == itemId).FirstOrDefault();
            item.Status = AdjustmentStatus.Rejected.ToString();
            db.StockAdjustmentItems.Attach(item);
            var entry = db.Entry(item);
            entry.Property(e => e.Status).IsModified = true;
            db.SaveChanges();
        }

    }
}