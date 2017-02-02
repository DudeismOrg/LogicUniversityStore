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

        public bool ProcessDisbursement(int disbId, string key, int receivedBy)
        {
            bool result = true;
            DisbursementDao disbDao = new DisbursementDao();
            if (disbDao.ValidateDisbKey(disbId, key))
            {
                disbDao.AcceptDisbursement(disbId, receivedBy);
            }
            else
                result = false;
            return result;
        }
    }
}
