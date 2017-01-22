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

        public CancelUpdateUnallocatedController()
        {
            RequisitionDao = new RequisitionDao();
        }

        public List<Requisition> GetApprovedRejectedRequisition()
        {
            return RequisitionDao.GetApprovedRejectedRequisitionList();
        }

    }
}