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

       public ApproveRejectReqController()
        {
            RequisitionDao = new RequisitionDao();
        }

        public List<Requisition> getRequestedRequisition()
        {
            return RequisitionDao.GetRequestedRequisitionList();
        }
    }
}