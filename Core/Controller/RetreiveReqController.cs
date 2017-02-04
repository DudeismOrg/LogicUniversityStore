using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using LogicUniversityStore.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class RetreiveReqController
    {
        public RetrievalDao RetrievalDao { get; set; }
        private List<Requisition> retReq;

        public RetreiveReqController(List<Requisition> retrievalReq) // this constructor is used for creating retrivelist from process requisition
        {
            RetrievalDao = new RetrievalDao();
            retReq = retrievalReq;
        }
        public RetreiveReqController() : this(null)  // default constructor for view the retriev list
        {

        }

        public Retrieval GetRetrievalFromId(int retrId)
        {
            RetrievalDao = new RetrievalDao();
            return RetrievalDao.findRetrievalById(retrId);
        }

        public List<Retrieval> GetAllRetrieval()
        {
            return RetrievalDao.FindAll();
        }

        public void CreateRetreival(Retrieval ret)
        {
            RetrievalDao.Create(ret);
        }



        private Dictionary<Department, Pair> GetBreakDownByDepartment(RequisitionItem reqItem)
        {
            if (this.retReq == null) throw new InvalidConstructorException("Use another constructor for this controller");
            Dictionary<Department, Pair> result = new Dictionary<Department, Pair>();

            foreach (Requisition r in this.retReq)
            {
                foreach (RequisitionItem item in r.RequisitionItems)
                {
                    if ((item.SupplierItemID != reqItem.SupplierItemID))
                    {
                        continue;
                    }
                    Department department = item.GetDepartment();
                    if (department == null) throw new DepartmentNotFoundException("Department can not be null ");
                    if (!result.ContainsKey(department))
                    {
                        result.Add(department, new Pair(item.NeededQuantity.Value, item.ApprovedQuantity.Value));
                    }
                    else
                    {
                        result[department].Needed += item.NeededQuantity.Value;
                        result[department].Approved += item.ApprovedQuantity.Value;
                    }
                }

            }
            return result;
        }

        public Retrieval FindRetrieval(int index)
        {
            return RetrievalDao.Find(index);
        }

        public Dictionary<RequisitionItem, MainRow> GetRow()
        {
            if (this.retReq == null) throw new InvalidConstructorException("Use another constructor for this controller");
            Dictionary<RequisitionItem, MainRow> result = new Dictionary<RequisitionItem, MainRow>(new RequistionItemBySupplierComparator());
            foreach (Requisition r in this.retReq)
            {
                foreach (RequisitionItem item in r.RequisitionItems)
                {
                    if (!result.ContainsKey(item))
                    {
                        MainRow row = new MainRow(
                            new Pair(
                                item.NeededQuantity.HasValue ? item.NeededQuantity.Value:0,
                                item.ApprovedQuantity.HasValue ? item.ApprovedQuantity.Value:0
                                ), this.GetBreakDownByDepartment(item));
                        result.Add(item, row);
                    }
                    else
                    {
                        result[item].Pair.Needed += item.NeededQuantity.Value;
                        result[item].Pair.Approved += item.ApprovedQuantity.Value;
                    }
                }
            }
            return result;
        }

        public void saveAsRetreved(int retrId)
        {
            RetrievalDao.SetRetrevalAsRetreved(retrId);
        }

        public void saveRetrevedQuantity(int itemId, int retrId, int collectedQty)
        {
            RetrievalDao.saveCollectedQuantity(itemId, retrId, collectedQty);
        }

        public List<Requisition> GetAllRequistion(Retrieval r)
        {
            return RetrievalDao.GetAllRequistion(r);
        }

        public List<Tuple<string, string, int>> GetRetreivalCounts(string userId)
        {
            List<Requisition> reqs = GetPendingRetreivals(Convert.ToInt32(userId));
            List<Tuple<string, string, int>> lstItems = new List<Tuple<string, string, int>>();
            foreach (Requisition req in reqs)
            {
                foreach (RequisitionItem reqItem in req.RequisitionItems)
                {
                    lstItems.Add(Tuple.Create(reqItem.Requisition.Department.DepartmentName, reqItem.GetItem().ItemName, reqItem.NeededQuantity.Value));
                }
            }
            return lstItems;
        }

        public List<Requisition> GetPendingRetreivals(int userId)
        {
            return new RetrievalDao().GetPendingRetreivalsByUserId(userId);
        }
    }

    public class Pair : IEquatable<Pair>
    {
        static int counter = 1;
        private int id;

        public Pair(int neededQuantity, int approvedQuantity)
        {
            Needed = neededQuantity;
            Approved = approvedQuantity;
            id = counter++;
        }

        public int Needed { get; set; }
        public int Approved { get; set; }

        public bool Equals(Pair other)
        {
            return this.id == other.id;
        }
    }

    public class MainRow
    {
        public Pair Pair { get; set; }
        public Dictionary<Department, Pair> DictionaryMap { get; set; }

        public MainRow(Pair pair, Dictionary<Department, Pair> dictionary)
        {
            this.Pair = pair;
            this.DictionaryMap = dictionary;
        }
    }
}