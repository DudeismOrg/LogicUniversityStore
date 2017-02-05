using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    [Serializable]
    public class ProcessReqController
    {
        public RequisitionDao RequisitionDao { get; set; }
        public RequisitionItemDao RequisitionItemDao { get; set; }
        public StockCardDao StockCardDao { get; set; }
        private List<Requisition> _reqs;

        public Dictionary<Requisition, double> mainList;  // will hold requisition and unfullfilItemNumbers

        private Dictionary<int, double> meter = new Dictionary<int, double>(); //hold reqId and meter of unfullfiled items
        public List<Requisition> ProcessedRequistions
        {
            get
            {
                if (_reqs == null)
                    _reqs =  GetReqItemForProcess();
                return _reqs;
            }
            
        } // will hold processrequisitions
        public Dictionary<int,int> LockedItem { get; set; }


        public ProcessReqController()
        {
            LogicUniStoreModel db = new LogicUniStoreModel();
            RequisitionDao = new RequisitionDao(db);
            StockCardDao = new StockCardDao(db);
            RequisitionItemDao = new RequisitionItemDao(db);
            mainList = new Dictionary<Requisition, double>();
            LockedItem = new Dictionary<int, int>();
        }

        public Dictionary<Requisition, double> GetMainProcessReqList()
        {
            //  ProcessedRequistions = GetReqItemForProcess();
            foreach (var req in ProcessedRequistions)
            {
                mainList[req] = meter[req.ReqID];
            }
            return mainList;
        }

        //public Dictionary<Requisition, double> GetMainProcessReqList()
        //{
        //    LogicUniStoreModel db = new LogicUniStoreModel();
        //    List<Requisition> rList = db.Requisitions.Where(r => r.Status == RequisitionStatus.Approved.ToString()).ToList();
        //    foreach (var requisition in rList)
        //    {

        //        if (mainList.ContainsKey(requisition))
        //        {
        //            continue;
        //        }

        //        int? unfullfilledItem = 0;
        //        double percentage = 100;
        //        //  int countReqItem = requisition.RequisitionItems.Count();
        //        double progrssMeter = 0.0;


        //        foreach (RequisitionItem item in requisition.RequisitionItems)
        //        {
        //            RequisitionItem rItem = RequisitionItemDao.db.RequisitionItems.Find(item.ReqItemID);

        //            if (!lockedItemsCountForProcess.ContainsKey(rItem.SupplierItem.ItemID))
        //            {
        //                lockedItemsCountForProcess.Add(rItem.SupplierItem.ItemID, 0);
        //            }
        //            int actualQuantityInStock = (StockCardDao.GetProductCountInStock(rItem.SupplierItem.ItemID) - lockedItemsCountForProcess[rItem.SupplierItem.ItemID]);

        //            if ((actualQuantityInStock - rItem.NeededQuantity) >= 0)
        //            {
        //                lockedItemsCountForProcess[rItem.SupplierItem.ItemID] += rItem.NeededQuantity.Value;
        //                rItem.ApprovedQuantity = rItem.NeededQuantity;
        //                progrssMeter += 1;
        //            }
        //            else
        //            {
        //                lockedItemsCountForProcess[rItem.SupplierItem.ItemID] += actualQuantityInStock;
        //                rItem.ApprovedQuantity = actualQuantityInStock;
        //                unfullfilledItem += 1;
        //                progrssMeter += (double)rItem.ApprovedQuantity / (double)rItem.NeededQuantity;
        //            }
        //        }
        //        db.SaveChanges();

        //        //if (unfullfilledItem.Value == 0)
        //        //{
        //        //    percentage = 100;
        //        //}
        //        //else
        //        //{
        //        //    double value = (requisition.RequisitionItems.Count - Convert.ToDouble(unfullfilledItem)) / requisition.RequisitionItems.Count;
        //        //    percentage = value * 100;
        //        //}

        //        //   mainList.Add(requisition, percentage);
        //        mainList.Add(requisition, (progrssMeter / requisition.RequisitionItems.Count) * 100);
        //    }
        //    return mainList;
        //}

        internal Requisition GetRequisition(int requisitonID)
        {
            return RequisitionDao.Find(requisitonID);
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

        public int GetApprovedRequistionCount()
        {
            return RequisitionDao.GetApprovedRequisitionCount();
        }

        public List<RequisitionItem> GetOutstandingItems()
        {
            return new RequisitionItemDao().GetOutstandingItems();
        }

        public string GenerateRetreivalForm(Tuple<int, List<int>> retReq)
        {
            return new RequisitionDao().GenerateRetreivalForm(retReq);
        }

        public List<Requisition> GetReqItemForProcess()
        {
            LogicUniStoreModel db = new LogicUniStoreModel();
            List<Requisition> reqs = db.Requisitions.Where(r => r.Status == RequisitionStatus.Approved.ToString()).ToList();
            int pId, stockCount,approveQnty;
            double progrssMeter;
            foreach (var req in reqs.ToList())
            {
                progrssMeter = 0.0;
                foreach (var item in req.RequisitionItems.ToList())
                {
                     pId = item.SupplierItem.ItemID;
                     approveQnty = item.NeededQuantity.Value; 
                     stockCount = StockCardDao.GetProductCountInStock(pId);

                    if (!LockedItem.ContainsKey(pId))
                    {
                      if( approveQnty > stockCount)
                        {
                           approveQnty  = (stockCount - approveQnty > 0 )? stockCount-approveQnty : stockCount;
                        }
                            LockedItem.Add(pId, approveQnty);
                    }
                    else
                    {
                        stockCount = (stockCount - LockedItem[pId]);
                        if (approveQnty > stockCount )
                        {
                            approveQnty = (stockCount - approveQnty > 0 )? stockCount - approveQnty : stockCount;
                        }
                        LockedItem[pId] += approveQnty;
                    }
                    item.ApprovedQuantity = approveQnty;

                    if (item.ApprovedQuantity == item.NeededQuantity)
                    {
                        progrssMeter += 1; // add 1 on scale of item.count()
                    }else
                    {
                        progrssMeter += (double)item.ApprovedQuantity / (double)item.NeededQuantity; // add fraction on scale of item.count()

                    }
                   
                }
                meter[req.ReqID] = (progrssMeter / req.RequisitionItems.Count) * 100;
                reqs.Add(req);

            }
            return reqs;
        }

        public void Reset()
        {
            this._reqs = null;
        }

    }
}