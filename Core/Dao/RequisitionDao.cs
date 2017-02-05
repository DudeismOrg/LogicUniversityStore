using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStore.Util;
using Core.Util;

namespace LogicUniversityStore.Dao
{
    [Serializable]
    public class RequisitionDao
    {
        LogicUniStoreModel db;
        public RequisitionDao(LogicUniStoreModel dbContext)
        {
            db = dbContext;
        }

        public RequisitionDao()
        {
            db = new LogicUniStoreModel();
        }

        public StockCardDao StockCardDao = new StockCardDao();

        public List<Requisition> GetApprovedRequisitionList()
        {
            return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Approved.ToString())).ToList();

        }

        public List<Requisition> GetRequestedRequisitionList(int requesterId)
        {
            return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Requested.ToString()) && r.RequesterID == requesterId).ToList();
        }

        public List<Requisition> GetRequestedRequisitionListHod(int depId)
        {
            return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Requested.ToString()) && r.DepartmentID == depId).ToList();
        }

        public List<Requisition> GetRejectedRequisitionList(int requesterId)
        {
            return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Rejected.ToString()) && r.RequesterID == requesterId).ToList();
        }

        public List<Requisition> GetApprovedRejectedRequisitionList(int depId)
        {
            return db.Requisitions.Where(r => ((r.Status.Equals(RequisitionStatus.Approved.ToString())) || (r.Status.Equals(RequisitionStatus.Rejected.ToString()))) && r.DepartmentID == depId).ToList();
        }

        public List<Requisition> GetRequisitionList(int requesterId)
        {
            return db.Requisitions.Where(x => x.RequesterID == requesterId).ToList();
        }

        internal List<RequisitionItem> getAllRequisitionItemsFromReqId(int reqID)
        {
            return db.RequisitionItems.Where(u => u.ReqID == reqID).ToList();
            throw new NotImplementedException();
        }

        public List<Requisition> test(int v)
        {
            return db.Requisitions.Where(f=>f.ReqID == v).ToList();
        }

        public List<Requisition> GetRequisitionListHod(int depId)
        {
            return db.Requisitions.Where(x => x.DepartmentID == depId).ToList();
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

        public void approveRequisition(int reqId, String remark)
        {
            Requisition requisition = db.Requisitions.Find(reqId);

            requisition.Status = RequisitionStatus.Approved.ToString();
            requisition.Remark = remark;
            requisition.ApprovedDate = DateTime.Now;
            db.Requisitions.Attach(requisition);
            var entry = db.Entry(requisition);
            entry.Property(e => e.Status).IsModified = true;
            entry.Property(e => e.Remark).IsModified = true;
            entry.Property(e => e.ApprovedDate).IsModified = true;
            db.SaveChanges();
        }

        public void updateRemark(int reqId, String remark)
        {
            Requisition requisition = db.Requisitions.Find(reqId);
            requisition.Remark = remark;
            db.Requisitions.Attach(requisition);
            var entry = db.Entry(requisition);
            entry.Property(e => e.Remark).IsModified = true;
            db.SaveChanges();
        }

        public void rejectRequisition(int reqId, String remark)
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

        public bool AckRequisition(AckRequisition roleReq)
        {
            Requisition requisition = db.Requisitions.Where(req => req.ReqID == roleReq.ReqId).FirstOrDefault();
            requisition.Status = roleReq.Status;
            requisition.Remark = roleReq.Remarks;
            requisition.ApprovedRejectedByID = roleReq.AcknowledgedBy;
            requisition.ApprovedDate = DateTime.Now;
            return db.SaveChanges() > 0 ? true : false;
        }

        public int GetApprovedRequisitionCount()
        {
            return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Approved.ToString())).Count();
        }

        internal List<RequisitionItem> getAllApprovedRequisitionItemsFromReqId()
        {
            return db.RequisitionItems.Where(r => r.Requisition.Status.Equals(RequisitionStatus.Approved.ToString())).ToList();
            //return db.Requisitions.Where(r => r.Status.Equals(RequisitionStatus.Approved.ToString())).Count();
        }

        public void reapplyRequisition(int reqId, String remark, DateTime reqDate)
        {
            Requisition requisition = db.Requisitions.Find(reqId);

            requisition.Status = RequisitionStatus.Requested.ToString();
            requisition.ReqDate = reqDate;
            requisition.Remark = remark;
            db.Requisitions.Attach(requisition);
            var entry = db.Entry(requisition);
            entry.Property(e => e.Status).IsModified = true;
            entry.Property(e => e.Remark).IsModified = true;
            entry.Property(e => e.ReqDate).IsModified = true;
            db.SaveChanges();

        }

        public Requisition Find(int requisitonID)
        {
            Requisition r = db.Requisitions.Find(requisitonID);
            if (r == null) throw new ArgumentException("Requistion ID not Valid");
            return r;
        }

        public List<Requisition> GetRequisitionListByStatus(RequisitionStatus status)
        {
            return db.Requisitions.Where(r => r.Status == status.ToString()).ToList();
        }

        public List<Requisition> GetToBeApproveRequisitions(int deptId)
        {
            return db.Requisitions.Where(r => r.DepartmentID == deptId && r.Status == RequisitionStatus.Requested.ToString()).ToList();
        }


        public string GenerateRetreivalForm(Tuple<int, List<int>> retReq)
        {
            Retrieval rt = new Retrieval()
            {
                RetrievalDate = DateTime.Now,
                RetrievalNumber = "RTL" + DateTime.Today.ToString("ddMMyyhhmmss"),
                Retriever = retReq.Item1
                //RequisitionItems = db.Requisitions.Where

            };
            db.Retrievals.Add(rt);
            db.SaveChanges();
            return rt.RetrievalNumber;
        }
    }
}