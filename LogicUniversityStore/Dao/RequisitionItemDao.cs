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
        
        public Boolean InitialApprovedQuantity(RequisitionItem reqItem)
        {
            
            return true;
        }
    }
}