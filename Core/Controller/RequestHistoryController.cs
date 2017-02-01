using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class RequestHistoryController
    {
        public RequisitionDao RequisitionDao { get; set; }

        public RequestHistoryController()
        {
            RequisitionDao = new RequisitionDao();
        }

        public List<Requisition> getRequisitionList(int requestorId)
        {
            return RequisitionDao.GetRequisitionList(requestorId);
        }
        public List<Requisition> getRequisitionListHod(int depId)
        {
            return RequisitionDao.GetRequisitionListHod(depId);
        }

        public List<RequisitionItem> getRequisitionItemList(int requisitionId)
        {
            return RequisitionDao.GetRequisitionItemList(requisitionId);
        }
    }
}