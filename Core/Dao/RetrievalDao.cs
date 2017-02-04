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
           return  db.Retrievals.ToList();
        }

        public void Create(Retrieval ret)
        {
            if(ret.RetrievalID == 0)
               db.Retrievals.Add(ret);
            db.SaveChanges();
        }

        public List<Requisition> GetAllRequistion(Retrieval ret)
        {
           return  ret.RequisitionItems.Where(item => item.RetrievalID == ret.RetrievalID).Select(item => item.Requisition).Distinct().ToList();
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

        internal void saveCollectedQuantity(int itemId, int retrId, int collectedQty)
        {
            int currentCollectedQty = collectedQty;
            List<Requisition> reqByIdOrdred = db.RequisitionItems.Where(item => item.RetrievalID == retrId && item.SupplierItem.ItemID == itemId).Select(item => item.Requisition).Distinct().ToList();
            reqByIdOrdred = reqByIdOrdred.OrderBy(d => d.ApprovedDate).ToList();
            foreach(Requisition req in reqByIdOrdred)
            {
                List<RequisitionItem> reqItms = db.RequisitionItems.Where(r => r.ReqID == req.ReqID && r.SupplierItemID == itemId).ToList();
                foreach(RequisitionItem rqitm in reqItms)
                {
                    if((currentCollectedQty - rqitm.ApprovedQuantity.Value) >= 0)
                    {
                        rqitm.RetirevedQuantity = rqitm.ApprovedQuantity;
                        db.SaveChanges();
                        currentCollectedQty = currentCollectedQty - rqitm.ApprovedQuantity.Value;
                    }
                    else
                    {
                        if(currentCollectedQty > 0)
                        {
                            rqitm.RetirevedQuantity = currentCollectedQty;
                            db.SaveChanges();
                            currentCollectedQty = 0;
                        }
                        else
                        {
                            rqitm.RetirevedQuantity = 0;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        internal void SetRetrevalAsRetreved(int retrId)
        {
            Retrieval ret = db.Retrievals.Where(r => r.RetrievalID == retrId).FirstOrDefault();
            ret.Retriever = 1;
            db.SaveChanges();
        }
    }
}