using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    public enum RequisitionStatus
    {
        Requested, Submitted, Cancelled, Approved, Rejected, Allocated, Shipped, Delivered
    }

    public enum PurchaseOrderStatus
    {
        Requested, Delivered
    }
    public enum AdjustmentType
    {
        Positive, Negative
    }

    public enum StockCheckType
    {
        OnSpot, Monthly
    }

    public enum AdjustmentStatus
    {
        Created, Approved, Rejected
    }

    public enum Roles
    {
        HOD,
        REP,
        CLERK,
        SUPERVISOR,
        MANAGER,
        EMP
    }

    public enum NotificationStatus
    {
        Created,
        Working,
        Cleared
    }

    public enum NotificationType
    {
        RequisitionCreated, // HOD
        Re
    }
}