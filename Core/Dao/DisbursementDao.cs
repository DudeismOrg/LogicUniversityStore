using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
            return db.Disbursements.Where(dis => dis.DepartmentID == deptId && dis.Requisition.Status == RequisitionStatus.Shipped.ToString()).ToList();
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

        internal void GenerateDisbursebents(int retrId)
        {
            List<Requisition> reqsitions = db.RequisitionItems.Where(item => item.RetrievalID == retrId).Select(item => item.Requisition).Distinct().ToList();
            foreach (Requisition req in reqsitions)
            {

                Random rdm = new Random();
                Disbursement dis = new Disbursement();
                dis.DepartmentID = req.DepartmentID;
                dis.DisbursementDate = DateTime.Now;
                dis.DisbursementNumber = "#DES" + req.ReqID + "/" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
                dis.Receiver = req.Department.RepresentativeID;
                dis.Key = req.ReqID.ToString() + rdm.Next(1000, 9999).ToString();
                dis.Requisition = req;
                db.Disbursements.Add(dis);
                db.SaveChanges();


                req.DisbursementID = dis.DisbursementID;
                req.Status = RequisitionStatus.Shipped.ToString();
                db.SaveChanges();
            }
        }

        public void SaveRequsitionAsDelivered(int reqIdInt)
        {
            Requisition req = db.Requisitions.Where(o => o.ReqID == reqIdInt).FirstOrDefault();
            req.Status = RequisitionStatus.Delivered.ToString();
            db.SaveChanges();
        }

        public void saveDeliveredStatusToReq(int reqItemID, int deliverdQuantity)
        {
            RequisitionItem reqItm = db.RequisitionItems.Where(e => e.ReqItemID == reqItemID).FirstOrDefault();
            reqItm.DisbursedQuantity = deliverdQuantity;
            db.SaveChanges();
        }

        public List<RequisitionItem> GetShipedReqItmsByReqId(int reqIdInt)
        {
            return db.RequisitionItems.Where(r=>r.ReqID == reqIdInt && r.Requisition.Status == RequisitionStatus.Shipped.ToString()).ToList();
        }

        public void UpdateDisbusedQuantity(int disbId, List<Tuple<int, int>> itemQtys)
        {
            List<RequisitionItem> itemList = db.RequisitionItems.Where(reqI => reqI.Requisition.Disbursement.DisbursementID == disbId).ToList();
            foreach (RequisitionItem item in itemList)
            {
                var temp = itemQtys.Where(val => val.Item1 == item.SupplierItemID).FirstOrDefault();
                if (temp != null)
                {
                    item.DisbursedQuantity = temp.Item2;
                }
            }
            db.SaveChanges();
        }

    }
}
