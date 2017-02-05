using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    [Serializable]
    public class RequisitionItemDao
    {
        public LogicUniStoreModel db;

        public RequisitionItemDao()
        {
            db = new LogicUniStoreModel();
        }

        public RequisitionItemDao(LogicUniStoreModel context)
        {
            db = context;
        }
        public void deleteRequisitionItem(int reqId, int itemId)
        {
            RequisitionItem item = db.RequisitionItems.Where(s => s.ReqID == reqId && s.SupplierItemID == itemId).First();


            if (item != null)
            {
                db.RequisitionItems.Remove(item);
            }
            db.SaveChanges();


        }

        public void deleteRequisitionItem(int reqId)
        {
            List<RequisitionItem> items = db.RequisitionItems.Where(s => s.ReqID == reqId).ToList();
            if (items != null)
            {
                foreach (RequisitionItem i in items)
                {
                    db.RequisitionItems.Remove(i);
                }
            }
            db.SaveChanges();
        }

        public void updateRequisitionItem(int reqId, int itemId, int qty)
        {
            RequisitionItem item = db.RequisitionItems.Where(s => s.ReqID == reqId && s.SupplierItemID == itemId).First();
            if (item != null)
            {
                item.NeededQuantity = qty;
                db.RequisitionItems.Attach(item);
                var entry = db.Entry(item);
                entry.Property(e => e.NeededQuantity).IsModified = true;
                db.SaveChanges();
            }
        }


        public Boolean InitialApprovedQuantity(RequisitionItem reqItem)
        {
            return true;
        }

        public void addRequisitionItem(RequisitionItem item)
        {
            db.RequisitionItems.Add(item);
            db.SaveChanges();
        }

        public List<RequisitionItem> GetOutstandingItems()
        {
            return db.RequisitionItems.Where(item => (item.IsOutstanding.HasValue ? item.IsOutstanding.Value : false) &&
            ((item.NeededQuantity.HasValue ? item.NeededQuantity.Value : 0) -
            (item.RetirevedQuantity.HasValue ? item.RetirevedQuantity.Value : 0) > 0)).ToList();
        }

        internal void saveApprovedQty(int reqItmId, int? neededQuantity)
        {
            RequisitionItem reqItm;
            try
            {
                reqItm = db.RequisitionItems.Where(y => y.ReqItemID == reqItmId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
            try
            {
                reqItm.ApprovedQuantity = neededQuantity;
            }
            catch (Exception e)
            {
                throw;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<RequisitionItem> GetRequistionItemsFrom(int numOfMonth)
        {
          DateTime today =  DateTime.Now;
          DateTime past = today.AddMonths(-numOfMonth);
          return  db.RequisitionItems.Where(r => r.Requisition.ApprovedDate.Value > past).ToList();
        

        }
    }
}