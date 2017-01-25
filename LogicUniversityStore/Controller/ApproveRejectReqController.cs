using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class ApproveRejectReqController
    {
        public RequisitionDao RequisitionDao { get; set; }
        public StockCardDao StockCardDao { get; set; }

        public ApproveRejectReqController()
        {
            RequisitionDao = new RequisitionDao();
            StockCardDao = new StockCardDao();
        }

        public List<Requisition> getRequestedRequisition()
        {
            return RequisitionDao.GetRequestedRequisitionList();
        }

        public List<RequisitionItem> getRequisitionItemList(int requisitionId)
        {
            return RequisitionDao.GetRequisitionItemList(requisitionId);
        }

        public void approveRequisition(int requisitionId)
        {
            RequisitionDao.approveRequisition(requisitionId);
           
        }

        public void rejectRequisition(int requisitionId)
        {
            RequisitionDao.rejectRequisition(requisitionId);
        }

       
    }
}