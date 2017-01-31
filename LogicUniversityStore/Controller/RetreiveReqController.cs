using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
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

        public RetreiveReqController(List<Requisition> retrievalReq)
        {
            RetrievalDao = new RetrievalDao();
            retReq = retrievalReq;
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
            Dictionary<Department, Pair> result = new Dictionary<Department, Pair>();

            foreach (Requisition r in this.retReq)
            {
                foreach (RequisitionItem item in r.RequisitionItems)
                {
                    if (!item.Equals(reqItem))
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

        public Dictionary<RequisitionItem,MainRow> GetRow()
        {
            Dictionary<RequisitionItem, MainRow> result = new Dictionary<RequisitionItem, MainRow>();
            foreach (Requisition r in this.retReq)
            {
                foreach (RequisitionItem item in r.RequisitionItems)
                {
                   if(!result.ContainsKey(item))
                    {
                        MainRow row = new MainRow(new Pair(item.NeededQuantity.Value, item.ApprovedQuantity.Value), this.GetBreakDownByDepartment(item));
                        result.Add(item, row);
                    }else
                    {
                        result[item].Pair.Needed += item.NeededQuantity.Value;
                        result[item].Pair.Approved += item.ApprovedQuantity.Value;
                    }
                }
            }
            return result;
        }
    }

  public  class Pair : IEquatable<Pair>
    {
        static int counter = 1;
        private int id;
        private int neededQuantity;
        private int approvedQuantity;

        public Pair(int neededQuantity, int approvedQuantity)
        {
            this.neededQuantity = neededQuantity;
            this.approvedQuantity = approvedQuantity;
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

        public MainRow(Pair pair,Dictionary<Department,Pair> dictionary)
        {
            this.Pair = pair;
            this.DictionaryMap = dictionary;
        }
    }
}