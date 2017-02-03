using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dao
{
    public class DisbursementDao
    {
        LogicUniStoreModel db;

        public DisbursementDao()
        {
            db = new LogicUniStoreModel();
        }

        public DisbursementDao(LogicUniStoreModel dbContext)
        {
            db = dbContext;
        }

        public List<Disbursement> GetDisbursements(int deptId)
        {
            return db.Disbursements.Where(dis => dis.DepartmentID == deptId && !dis.Receiver.HasValue).ToList();
        }

        public bool ValidateDisbKey(int disbId, string key)
        {
            return (db.Disbursements.Where(dis => dis.DisbursementID == disbId).FirstOrDefault().Key == key);
        }

        public bool AcceptDisbursement(int disbId, int receivedBy)
        {
            Disbursement dsb = db.Disbursements.Where(db => db.DisbursementID == disbId).FirstOrDefault();
            dsb.Requisition.Status = RequisitionStatus.Delivered.ToString();
            dsb.Requisition.RecieveByID = receivedBy;
            return db.SaveChanges() > 0 ? true : false;
        }

        internal List<Requisition> getShipedReqByDept(int deptId)
        {
            return db.Requisitions.Where(r => r.DepartmentID == deptId && r.Status == RequisitionStatus.Shipped.ToString()).ToList();
        }
    }
}
