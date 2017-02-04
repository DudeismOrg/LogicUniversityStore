using Core.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicUniversityStore.Dao;

namespace LogicUniversityStore.Controller
{
    public class DisbursementController
    {
        UserDao userDao { get; set; }
        DisbursementDao disbDao { get; set; }
        public DisbursementController()
        {
            userDao = new UserDao();
            disbDao = new DisbursementDao();
        }

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

        public List<Department> GetAllDepartments()
        {
            return userDao.getAllDepartments();
        }

        public List<Requisition> GetAllShipedRequsitionByDept(int deptId)
        {
            return disbDao.getShipedReqByDept(deptId);
        }
    }
}
