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

        public List<Tuple<double, Requisition>> GetMainProcessReqList()
        {
            List<Tuple<double, Requisition>> mainList = new List<Tuple<double, Requisition>>();
            foreach (var requisition in RequisitionDao.GetApprovedRequisitionList())
            {
                int? unfullfilledItem = 0;
                double percentage = 100;
                int countReqItem = requisition.RequisitionItems.Count();



                foreach (RequisitionItem rItem in requisition.RequisitionItems)
                {
                    unfullfilledItem = unfullfilledItem + ((rItem.NeededQuantity - (StockCardDao.GetProductCountInStock(rItem.SupplierItem.ItemID) - StockCardDao.GetLockedProductCountInStock(rItem.SupplierItem.Item.ItemID))) >= 0 ? 1 : 0);
                }
                if (unfullfilledItem.Value == 0)
                {
                    requisition.Status = RequisitionStatus.Allocated.ToString();
                    percentage = 100;
                }
                else
                {
                    double value = (1 / Convert.ToDouble(unfullfilledItem));
                    percentage = value * 100;
                }

                mainList.Add(new Tuple<double, Requisition>((double)unfullfilledItem, requisition));
            }

            return mainList;

        }

        public List<StockCard> GetAllStockCard()
        {
            return StockCardDao.GetAllInStock();
        }

        public List<RequisitionItem> GetRequisitionItems(int requisitionID)
        {
            return RequisitionDao.GetRequisitionItemList(requisitionID);
        }

        public Boolean InitialInsertToApprovedQuantity(int reqId)
        {
            List<RequisitionItem> items = this.GetRequisitionItems(reqId);
            foreach (RequisitionItem item in items)
            {

            }
            return true;
        }
    }
}