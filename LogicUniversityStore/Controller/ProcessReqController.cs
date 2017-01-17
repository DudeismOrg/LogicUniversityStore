using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Controller
{
    public class ProcessReqController
    {
        public RequisitionDao RequisitionDao { get; set; }
        public ProcessReqController()
        {
            RequisitionDao = new RequisitionDao();
        }

        public List<Requisition> getApprovedRequisitionList()
        {
            RequisitionDao.db
        }
    }
}