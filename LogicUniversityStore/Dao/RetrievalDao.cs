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
    }
}