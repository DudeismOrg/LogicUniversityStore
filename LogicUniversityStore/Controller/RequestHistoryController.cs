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

        public List<Requisition> getRequisitionList()
        {
            return RequisitionDao.GetRequisitionList();
        }

        public List<RequisitionItem> getRequisitionItemList(int requisitionId)
        {
            return RequisitionDao.GetRequisitionItemList(requisitionId);
        }
    }
}