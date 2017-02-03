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

        public bool ProcessDisbursement(int disbId, string key, int receivedBy)
        {
            bool result = true;
            if (disbDao.ValidateDisbKey(disbId, key))
            {
                disbDao.AcceptDisbursement(disbId, receivedBy);
            }
            else
            {
                result = false;
            }
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
