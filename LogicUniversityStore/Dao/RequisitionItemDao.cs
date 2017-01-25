using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class RequisitionItemDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();
 
      


        public void deleteRequisitionItem(int reqId,int itemId)
        {
            RequisitionItem item = db.RequisitionItems.Where(s => s.ReqID == reqId && s.ItemID==itemId).First();


            if (item!=null)
            {
                db.RequisitionItems.Remove(item);
            }
            db.SaveChanges();


        }

        public void updateRequisitionItem(int reqId,int itemId,int qty)
        {
            RequisitionItem item = db.RequisitionItems.Where(s => s.ReqID == reqId && s.ItemID == itemId).First();
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


    }
}