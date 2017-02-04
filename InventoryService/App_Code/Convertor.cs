using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Controller;
using CoreModel = LogicUniversityStore.Model;
using LogicUniversityStore.Controller;

/// <summary>
/// Summary description for Convertor
/// </summary>
public class Convertor
{
    public Convertor()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static UserResponse ConvertUserModelToResponse(CoreModel.LUUser user)
    {
        UserResponse response = null;
        if (user != null)
        {
            response = new UserResponse(
               user.UserID,
               user.FirstName,
               user.Email,
               user.LastName,
               user.DepartmentID.Value,
               user.Department.DepartmentName,
               user.RoleID,
               user.Role.RoleName,
               user.Role.RoleCode);
        }
        return response;
    }

    public static void ConvertReqItemsToModelItems(RequisitionRequest request, CoreModel.Requisition modelReq)
    {
        modelReq.RequisitionItems = new List<CoreModel.RequisitionItem>();
        foreach (RequisitionItemRequest item in request.Items)
        {
            modelReq.RequisitionItems.Add(
            new CoreModel.RequisitionItem()
            {
                ItemID = item.ItemId,
                NeededQuantity = item.NeededQuantity
            });
        }
    }

    public static CoreModel.Requisition ConvertReqDCToReqModel(RequisitionRequest request)
    {
        return new LogicUniversityStore.Model.Requisition()
        {
            DepartmentID = request.DepartmentId,
            Remark = request.Remarks,
            ReqDate = request.CreatedDate,
            RequesterID = request.CreatedBy
        };
    }

    public static RequisitionResponse ConvertReqModelToResDC(CoreModel.Requisition req)
    {
        UserController uCtrl = new UserController();
        return new RequisitionResponse()
        {
            ApprovedBy = uCtrl.GetUserNameByUserId(req.ApprovedRejectedByID),
            ApprovedDate = req.ApprovedDate.HasValue ? req.ApprovedDate.Value.ToString("dd-MMM-yy") : DateTime.Now.ToString("dd-MMM-yy"),
            CreatedBy = uCtrl.GetUserNameByUserId(req.RequesterID),
            DepartmentCode = req.Department.DepartmentCode,
            DepartmentName = req.Department.DepartmentName,
            RequisitionDate = req.ReqDate.ToString("dd-MMM-yy"),
            RequisitionNum = req.ReqNumber,
            UserId = req.RequesterID,
            RequisitionId = req.ReqID
        };
    }

    public static RequisitionItemResponse ConvertReqItemModelToResItemDC(CoreModel.RequisitionItem req)
    {
        return new RequisitionItemResponse()
        {
            ItemName = req.SupplierItem.Item.ItemName,
            Quantity = req.NeededQuantity.HasValue ? req.NeededQuantity.Value : 0
        };
    }
}