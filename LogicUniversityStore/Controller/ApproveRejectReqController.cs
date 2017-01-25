﻿using LogicUniversityStore.Dao;
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

        public List<RequisitionItem> getRequisitionItemList(int requisitionId)
        {
            return RequisitionDao.GetRequisitionItemList(requisitionId);
        }

        public void approveRequisition(int requisitionId,String remark)
        {
            RequisitionDao.approveRequisition(requisitionId,remark);
        }

        public void rejectRequisition(int requisitionId,String remark)
        {
            RequisitionDao.rejectRequisition(requisitionId,remark);
        }
    }
}