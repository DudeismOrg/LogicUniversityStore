using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class ReapplyRejectedController
    {
        public RequisitionDao RequisitionDao { get; set; }
        public RequisitionItemDao RequisitionItemDao { get; set; }

        public ItemDao ItemDao { get; set; }

        public List<RequisitionItem> getRequisitionItemList(int requisitionId)
        {
            return RequisitionDao.GetRequisitionItemList(requisitionId);
        }

        public ReapplyRejectedController()
        {
            RequisitionDao = new RequisitionDao();
            RequisitionItemDao = new RequisitionItemDao();
            ItemDao = new ItemDao();
        }

        public List<Requisition> getRejectedRequisition(int requesterId)
        {
            return RequisitionDao.GetRejectedRequisitionList(requesterId);
        }

        public bool removeRequisition(int reqId)
        {
            return RequisitionDao.Remove(reqId);
        }

        public void removeRequisitionItems(int reqId)
        {
            RequisitionItemDao.deleteRequisitionItem(reqId);
        }

        public void reapplyRequisition(int reqId, String remark, DateTime reqDate)
        {
            RequisitionDao.reapplyRequisition(reqId, remark, reqDate);
        }

        public Item GetItem(String itemName)
        {
            return ItemDao.GetItem(itemName);
        }

        public void addRequisitionItem(RequisitionItem item)
        {
            RequisitionItemDao.addRequisitionItem(item);
        }

    }

}