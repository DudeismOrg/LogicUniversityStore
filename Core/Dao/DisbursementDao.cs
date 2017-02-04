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

        public void UpdateDisbusedQuantity(int disbId, List<Tuple<int, int>> itemQtys)
        {
            List<RequisitionItem> itemList = db.RequisitionItems.Where(reqI => reqI.Requisition.Disbursement.DisbursementID == disbId).ToList();
            foreach (RequisitionItem item in itemList)
            {
                var temp = itemQtys.Where(val => val.Item1 == item.ItemID).FirstOrDefault();
                if (temp != null)
                {
                    item.DisbursedQuantity = temp.Item2;
                }
            }
            db.SaveChanges();
        }
    }
}
