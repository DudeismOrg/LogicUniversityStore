using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicUniversityStore.Controller
{

    public class ProcessReqAlterController
    {
        public List<Requisition> ProcessedRequistions { get; set; }
        public Dictionary<int,int> LockedItem { get; set; }
        public StockCardDao StockCardDao { get; set; }

        public ProcessReqAlterController(List<Requisition> reqs,Dictionary<int,int> lockedItem)
        {
            ProcessedRequistions = reqs;
            LockedItem = lockedItem;
            StockCardDao = new StockCardDao(new LogicUniStoreModel());
        }



        public bool updateRequistionItem(RequisitionItem item, int newApprovedAmount)
        {
            if (item.ApprovedQuantity == newApprovedAmount) return true;
            bool res = false;
            int stockOnhand = StockCardDao.GetProductCountInStock(item.SupplierItem.ItemID) - (LockedItem[item.SupplierItem.ItemID] - item.ApprovedQuantity.Value);
            if (stockOnhand >= newApprovedAmount && item.NeededQuantity >= newApprovedAmount)
            {
                LockedItem[item.SupplierItem.ItemID] -= item.ApprovedQuantity.Value;
                item.ApprovedQuantity = newApprovedAmount;
                LockedItem[item.SupplierItem.ItemID] += newApprovedAmount;
                res = true;
            }
            return res;
        }

    }
}
