using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class AdjustmentController
    {
        AdjustmentDao dao;
        public AdjustmentController()
        {
            dao = new AdjustmentDao();
        }
        public bool CreateSpotAdjustment(Adjustment adjustment)
        {
            bool isSuccessful = false;
            LogicUniStoreModel dbContext;
            try
            {
                StockAdjustment objAdjustment = new StockAdjustment()
                {
                    CreatedBy = adjustment.CreatedBy,
                    CreatedDate = DateTime.Now,
                    SockAdjustmentNumber = adjustment.Number,
                    //Status = AdjustmentStatus.Created.ToString(),
                    Type = StockCheckType.OnSpot.ToString()
                };
                objAdjustment.StockAdjustmentItems = new List<StockAdjustmentItem>();
                foreach (AdjustmentItem item in adjustment.Items)
                {
                    StockAdjustmentItem objAdjItem = new StockAdjustmentItem()
                    {
                        CountDate = DateTime.Now,
                        CountPerson = adjustment.CreatedBy.ToString(), //TODO: Change to Id
                        CountQuantity = item.Quantity,
                        ItemID = item.ItemId,
                        Remark = item.Remarks,
                        Status = AdjustmentStatus.Created.ToString(),
                        AdjustQuantity = dao.getOnHandQty(item.ItemId) - (item.Quantity),
                        StockAdjustment = objAdjustment
                    };
                    
                    objAdjustment.StockAdjustmentItems.Add(objAdjItem);
                }

                dbContext = new LogicUniStoreModel();
                dbContext.Database.Connection.Open();
                using (var txn = dbContext.Database.BeginTransaction())
                {
                    //Create Adjustment and Items
                    AdjustmentDao dao = new AdjustmentDao();
                    dao.CreateAdjustment(objAdjustment);
                    //Update stock card
                    //dao.updateStockCard(objAdjustment.StockAdjustmentItems.ToList());
                    txn.Commit();
                    isSuccessful = true;
                }
                dbContext.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                   throw ex;
            }
            return isSuccessful;
        }
    }
}