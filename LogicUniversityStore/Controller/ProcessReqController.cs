using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class ProcessReqController
    {
        public RequisitionDao RequisitionDao { get; set; }
        public StockCardDao StockCardDao { get; set; }
        public ProcessReqController()
        {
            RequisitionDao = new RequisitionDao();
            StockCardDao = new StockCardDao();
        }

        public List<Tuple<int, Requisition>> GetMainProcessReqList()
        {
            List<Tuple<int, Requisition>> mainList = new List<Tuple<int, Requisition>>();
            foreach (var requisition in RequisitionDao.getApprovedRequisitionList())
            {
                int? unfullfilledItem = 0;
                foreach(RequisitionItem rItem in requisition.RequisitionItems)
                {
                    unfullfilledItem = unfullfilledItem + ((rItem.NeededQuantity - StockCardDao.GetProductCountInStock(rItem.SupplierItem.BaseItemID)) > 0 ? 1 : 0);
                }
                if(unfullfilledItem.Value == 0)
                {
                    requisition.Status = RequisitionStatus.Allocated.ToString();
                }
                mainList.Add(new Tuple<int,Requisition>(unfullfilledItem.Value, requisition));
            }

            return mainList;
            
        }
        
    }
}