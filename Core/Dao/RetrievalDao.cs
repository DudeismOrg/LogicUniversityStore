using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class RetrievalDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public List<Retrieval> FindAll()
        {
            return db.Retrievals.ToList();
        }

        public void Create(Retrieval ret)
        {
            if (ret.RetrievalID == 0)
                db.Retrievals.Add(ret);
            db.SaveChanges();
        }

        public List<Requisition> GetAllRequistion(Retrieval ret)
        {
            return ret.RequisitionItems.Where(item => item.RetrievalID == ret.RetrievalID).Select(item => item.Requisition).Distinct().ToList();
        }

        public List<Requisition> GetPendingRetreivalsByUserId(int userId)
        {
            return db.Retrievals.Where(ret => ((ret.Retriever.HasValue && ret.Retriever.Value == userId)
                                && !ret.IsCollected.Value)).SelectMany(ret => ret.RequisitionItems)
                                .Select(reqI => reqI.Requisition).Distinct().ToList();
        }

        public Retrieval Find(int index)
        {
            Retrieval r = db.Retrievals.Find(index);
            if (r == null) throw new Exception("Retrieval Id not valid");
            return r;
        }

        internal Retrieval findRetrievalById(int retrId)
        {
            return db.Retrievals.Where(r => r.RetrievalID == retrId).FirstOrDefault();
        }

        internal void saveCollectedQuantityWithMismatch(int itemId, int retrId, int collectedQty)
        {
            List<Requisition> reqByIdOrdred = db.RequisitionItems.Where(item => item.RetrievalID == retrId && item.SupplierItem.ItemID == itemId).Select(item => item.Requisition).Distinct().ToList();
            reqByIdOrdred = reqByIdOrdred.OrderBy(d => d.ReqDate).ToList();
            int x = 0;
            throw new NotImplementedException();
        }

        internal void saveCollectedQuantityWithoutMismatch(int itemId, int retrId, int collectedQty)
        {
            List<Requisition> reqByIdOrdred = db.RequisitionItems.Where(item => item.RetrievalID == retrId && item.SupplierItem.ItemID == itemId).Select(item => item.Requisition).Distinct().ToList();
            reqByIdOrdred = reqByIdOrdred.OrderBy(d => d.ReqDate).ToList();
            int x = 0;
            throw new NotImplementedException();
            throw new NotImplementedException();
        }
    }
}