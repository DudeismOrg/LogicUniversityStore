using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class CancelUpdatePendingApprovalController
    {
        public RequisitionDao RequisitionDao { get; set; }
        public RequisitionItemDao RequisitionItemDao { get; set; }
        public CancelUpdatePendingApprovalController()
        {
            RequisitionDao = new RequisitionDao();
            RequisitionItemDao = new RequisitionItemDao();
        }

        public List<Requisition> getRequestedRequisition()
        {
            return RequisitionDao.GetRequestedRequisitionList();
        }

        public void removeRequisitionItems(int reqId)
        {
            RequisitionItemDao.deleteRequisitionItem(reqId);
        }

        public bool removeRequisition(int reqId)
        {
            return RequisitionDao.Remove(reqId);
        }

    }
}