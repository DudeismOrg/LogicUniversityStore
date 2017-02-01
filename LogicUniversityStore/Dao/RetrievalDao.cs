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

        internal List<Retrieval> FindAll()
        {
           return  db.Retrievals.ToList();
        }

        internal void Create(Retrieval ret)
        {
            if(ret.RetrievalID == 0)
               db.Retrievals.Add(ret);
            db.SaveChanges();
        }

        public List<Requisition> GetAllRequistion(Retrieval ret)
        {
           return  ret.RequisitionItems.Where(item => item.RetrievalID == ret.RetrievalID).Select(item => item.Requisition).Distinct().ToList();
        }

        internal Retrieval Find(int index)
        {
            Retrieval r = db.Retrievals.Find(index);
            if (r == null) throw new Exception("Retrieval Id not valid");
            return r;
        }
    }
}