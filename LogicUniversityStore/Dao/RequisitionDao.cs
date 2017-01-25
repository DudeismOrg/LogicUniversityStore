using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.Dao
{
    public class RequisitionDao
    {
        public LogicUniStoreModel db = new LogicUniStoreModel();
        public StockCardDao StockCardDao = new StockCardDao();

        public List<Requisition> GetApprovedRequisitionList()
        {
            return  db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Approved.ToString())).ToList();
            
        }

        public List<Requisition> GetRequestedRequisitionList()
        {
            return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Requested.ToString())).ToList();
        }

        public List<Requisition> GetRejectedRequisitionList()
        {
            return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Rejected.ToString())).ToList();
        }

        public List<Requisition> GetApprovedRejectedRequisitionList()
        {
            return db.Requisitions.Where(r => (r.Status.Equals(RequisitionStatus.Approved.ToString())) || (r.Status.Equals(RequisitionStatus.Rejected.ToString()))).ToList();
        }

        public List<Requisition> GetRequisitionList()
        {
            return db.Requisitions.ToList();
        }

        public List<RequisitionItem> GetRequisitionItemList(int requisitionID)
        {
            Requisition req = db.Requisitions.Find(requisitionID);
            if (req != null)
            {
                return req.RequisitionItems.ToList();
            }
            return null;
        }

        public void Create(Requisition requistion)
        {
            db.Requisitions.Add(requistion);
            db.SaveChanges();
        }

        public bool Remove(int reqID)
        {
            Requisition requisition = db.Requisitions.Find(reqID);
            if (requisition != null)
            {
                db.Requisitions.Remove(requisition);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void approveRequisition(int reqId,String remark)
        {
            Requisition requisition = db.Requisitions.Find(reqId);
            
                requisition.Status = RequisitionStatus.Approved.ToString();
                requisition.Remark = remark;
                db.Requisitions.Attach(requisition);
                var entry = db.Entry(requisition);
                entry.Property(e => e.Status).IsModified = true;
                entry.Property(e => e.Remark).IsModified = true;            
                db.SaveChanges();
        }

        public void rejectRequisition(int reqId,String remark)
        {
            Requisition requisition = db.Requisitions.Find(reqId);

            requisition.Status = RequisitionStatus.Rejected.ToString();
            requisition.Remark = remark;
            db.Requisitions.Attach(requisition);
            var entry = db.Entry(requisition);
            entry.Property(e => e.Status).IsModified = true;
            entry.Property(e => e.Remark).IsModified = true;
            db.SaveChanges();

        }

        public int GetApprovedRequisitionCount()
        {
          return  db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Approved.ToString())).Count();
        }
    }
}