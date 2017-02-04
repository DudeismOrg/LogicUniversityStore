using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class ApplyReqController
    {
        public CategoryDao CategoryDao { get; set; }

        public ApplyReqController()
        {
            CategoryDao = new CategoryDao();
        }

        public List<Category> GetCategories()
        {
            return CategoryDao.GetCategories();
        }

        public List<Item> GetItemsByCategoryId(int categoryId)
        {
            return CategoryDao.GetItemsByCategoryId(categoryId);
        }

        public bool CreateRequisition(Requisition modelReq)
        {
            bool isSuccessful = false;

            LogicUniStoreModel dbContext;
            try
            {
                dbContext = new LogicUniStoreModel();
                dbContext.Database.Connection.Open();
                using (var txn = dbContext.Database.BeginTransaction())
                {
                    //Create Adjustment and Items
                    RequisitionDao dao = new RequisitionDao(dbContext);
                    dao.Create(modelReq);
                    RequisitionItemDao itemDao = new RequisitionItemDao(dbContext);
                    foreach (RequisitionItem item in modelReq.RequisitionItems)
                    {
                        itemDao.addRequisitionItem(item);
                    }
                    txn.Commit();
                    isSuccessful = true;
                }
                dbContext.Database.Connection.Close();
            }
            catch (Exception ex)
            {

                //   throw;
            }
            return isSuccessful;
        }

        public List<Requisition> GetRequisitionsByStatus(string status)
        {
            List<Requisition> lstReqs = null;
            RequisitionStatus val;
            if (Enum.TryParse(status, true, out val))
                lstReqs = new RequisitionDao().GetRequisitionListByStatus(val);
            return lstReqs;
        }

        public List<Requisition> GetToBeApproveRequisitions(int deptId)
        {
            return new RequisitionDao().GetToBeApproveRequisitions(deptId);
        }

        public List<RequisitionItem> GetReqItemsByReqId(int reqId)
        {
            return new RequisitionDao().GetRequisitionItemList(reqId);
        }
    }
}