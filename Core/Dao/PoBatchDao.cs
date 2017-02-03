using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Dao
{
    public class PoBatchDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();

        public PoBatchDao()
        {
            
        }

        public List<POBatch> GetAllPoBatch()
        {
            return db.POBatches.ToList();
        }

    }
}