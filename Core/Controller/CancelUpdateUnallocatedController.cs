using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class CancelUpdateUnallocatedController
    {
        public RequisitionDao RequisitionDao { get; set; }
        public ItemDao iDao { get; set; }
        public RequisitionItemDao riDao {get; set;}
    public CancelUpdateUnallocatedController()
        {
            RequisitionDao = new RequisitionDao();
            riDao = new RequisitionItemDao();
            iDao = new ItemDao();
        }

        public List<Requisition> GetApprovedRejectedRequisition(int depId)
        {
            return RequisitionDao.GetApprovedRejectedRequisitionList(depId);
        }

        public List<Requisition> GetApprovedRequisition(int depId)
        {
            return RequisitionDao.GetApprovedRequisitionList(depId);
        }

        public List<RequisitionItem> getRequisitionItemList(int requisitionId)
        {
            return RequisitionDao.GetRequisitionItemList(requisitionId);
        }

        public void approveRequisition(int requisitionId,String remark)
        {
            RequisitionDao.approveRequisition(requisitionId,remark);
        }

        public void rejectRequisition(int requisitionId, String remark)
        {
            RequisitionDao.rejectRequisition(requisitionId,remark);
        }


        public Item GetItem(String itemName)
        {
            return iDao.GetItem(itemName);
        }

        public void deleteRequisitionItem(int reqId, int itemId)
        {
            riDao.deleteRequisitionItem(reqId,itemId);
        }

        public void updateRequisitionItem(int reqId, int itemId,int qty)
        {
            riDao.updateRequisitionItem(reqId,itemId,qty);
        }

        public void removeRequisitionItems(int reqId)
        {
            riDao.deleteRequisitionItem(reqId);
        }

        public void addRequisitionItem(RequisitionItem item)
        {
            riDao.addRequisitionItem(item);
        }

        public List<Requisition> GetRequestedRequisitionListHod(int depId)
        {
            return RequisitionDao.GetRequestedRequisitionListHod(depId);
        }

    }
}