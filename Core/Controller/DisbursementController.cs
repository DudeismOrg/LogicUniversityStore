using Core.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controller
{
    public class DisbursementController
    {
        public List<Disbursement> GetDisbursements(int deptId)
        {
            return new DisbursementDao().GetDisbursements(deptId);
        }

        public bool ProcessDisbursement(int disbId, string key, int receivedBy, List<Tuple<int, int>> itemQtys)
        {
            bool result = true;
            LogicUniStoreModel dbContext = new LogicUniStoreModel();
            dbContext.Database.Connection.Open();
            using (var txn = dbContext.Database.BeginTransaction())
            {
                DisbursementDao disbDao = new DisbursementDao(dbContext);

                if (disbDao.ValidateDisbKey(disbId, key))
                {
                    disbDao.AcceptDisbursement(disbId, receivedBy);
                    disbDao.UpdateDisbusedQuantity(disbId, itemQtys);
                }
                else
                    result = false;
                txn.Commit();
            }
            dbContext.Database.Connection.Close();
            return result;
        }
    }
}
