using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Core.Controller;
using CoreModel = LogicUniversityStore.Model;
using CoreController = Core.Controller;
using LogicUniversityStore.Controller;
using Core.Util;
using LogicUniversityStore.Util;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public UserResponse ValidateUser(UserRequest userReq)
    {
        UserResponse response = null;
        if (!string.IsNullOrEmpty(userReq.UserName) && !string.IsNullOrEmpty(userReq.Password))
        {
            CoreModel.LUUser user = new UserController().ValidateUser(userReq.UserName, userReq.Password);
            response = Convertor.ConvertUserModelToResponse(user);
        }
        return response;
    }

    #region Requisition

    public bool CreateRequisition(RequisitionRequest request)
    {
        CoreModel.Requisition modelReq = Convertor.ConvertReqDCToReqModel(request);
        Convertor.ConvertReqItemsToModelItems(request, modelReq);
        return new ApplyReqController().CreateRequisition(modelReq);
    }

    public List<RequisitionResponse> GetRequisitionsByStatus(string status)
    {
        List<RequisitionResponse> lstReqResponse = null;
        string msg = string.Empty;

        List<CoreModel.Requisition> lstRequisitions = new ApplyReqController().GetRequisitionsByStatus(status);
        if (lstRequisitions != null && lstRequisitions.Count > 0)
        {
            lstReqResponse = new List<RequisitionResponse>();
            foreach (CoreModel.Requisition req in lstRequisitions)
            {
                lstReqResponse.Add(Convertor.ConvertReqModelToResDC(req));
            }
        }
        return lstReqResponse;
    }

    public List<RequisitionResponse> GetToBeApproveRequisitions(string deptId)
    {
        List<RequisitionResponse> lstReqResponse = null;
        string msg = string.Empty;

        List<CoreModel.Requisition> lstRequisitions = new ApplyReqController().GetToBeApproveRequisitions(Convert.ToInt32(deptId));
        if (lstRequisitions != null && lstRequisitions.Count > 0)
        {
            lstReqResponse = new List<RequisitionResponse>();
            foreach (CoreModel.Requisition req in lstRequisitions)
            {
                lstReqResponse.Add(Convertor.ConvertReqModelToResDC(req));
            }
        }
        return lstReqResponse;
    }


    public List<RequisitionItemResponse> GetReqItemDetailsByReqId(string reqId)
    {
        List<RequisitionItemResponse> lstReqItemResponse = null;
        int requisitionId = 0;
        if (int.TryParse(reqId, out requisitionId))
        {
            List<CoreModel.RequisitionItem> lstRequisitions = new ApplyReqController().GetReqItemsByReqId(requisitionId);
            if (lstRequisitions != null && lstRequisitions.Count > 0)
            {
                lstReqItemResponse = new List<RequisitionItemResponse>();
                foreach (CoreModel.RequisitionItem req in lstRequisitions)
                {
                    lstReqItemResponse.Add(Convertor.ConvertReqItemModelToResItemDC(req));
                }
            }
        }
        return lstReqItemResponse;
    }

    public string GenerateRetreivalForm(RetreivalRequest retReq)
    {
        Tuple<int, List<int>> objReq = Tuple.Create(retReq.UserId, retReq.RequisitionItemIds);
        return new ProcessReqController().GenerateRetreivalForm(objReq);
    }

    #endregion

    #region ManageRole

    public List<UserResponse> GetUsersByDeptId(string deptId)
    {
        List<UserResponse> lstUsers = null;
        List<CoreModel.LUUser> users = new UserController().GetUsersByDeptCode(Convert.ToInt32(deptId));
        if (users.Count > 0)
        {
            lstUsers = new List<UserResponse>();
            foreach (CoreModel.LUUser user in users)
            {
                lstUsers.Add(Convertor.ConvertUserModelToResponse(user));
            }
        }
        return lstUsers;
    }

    public List<RoleResponse> GetRolesByDeptType(string deptType)
    {
        List<RoleResponse> lstResponse = null;
        List<CoreModel.Role> lstRoles = new UserController().GetRolesByDeptType(deptType);
        if (lstRoles.Count > 0)
        {
            lstResponse = new List<RoleResponse>();
            foreach (CoreModel.Role role in lstRoles)
            {
                lstResponse.Add(new RoleResponse()
                {
                    RoleCode = role.RoleCode,
                    RoleName = role.RoleName
                });
            }
        }
        return lstResponse;
    }

    public bool UpdateUserRole(ManageRoleRequest roleReq)
    {
        return new UserController().UpdateUserRole(roleReq.UserId, roleReq.RoleCode);
    }

    #endregion

    #region Outstanding

    public List<RequisitionItemResponse> GetOutstandingItems()
    {
        List<RequisitionItemResponse> lstItems = null;
        List<CoreModel.RequisitionItem> lstCoreReqItems = new ProcessReqController().GetOutstandingItems();
        if (lstCoreReqItems.Count > 0)
        {
            lstItems = new List<RequisitionItemResponse>();
            foreach (CoreModel.RequisitionItem item in lstCoreReqItems)
            {
                lstItems.Add(new RequisitionItemResponse()
                {
                    DeptName = item.Requisition.Department.DepartmentName,
                    ItemName = item.SupplierItem.Item.ItemName,
                    Quantity = ((item.NeededQuantity.HasValue ? item.NeededQuantity.Value : 0) - (item.RetirevedQuantity.HasValue ? item.RetirevedQuantity.Value : 0))
                });
            }
        }
        return lstItems;
    }

    #endregion

    #region PurchaseOrder

    public List<SupplierResponse> GetSuppliers()
    {
        List<SupplierResponse> lstSuppliers = null;
        List<CoreModel.Supplier> lstCoreSup = new PurchaseOrderController().GetSuppliers();
        if (lstCoreSup.Count > 0)
        {
            lstSuppliers = new List<SupplierResponse>();
            foreach (CoreModel.Supplier sup in lstCoreSup)
            {
                lstSuppliers.Add(new SupplierResponse()
                {
                    SupplierCode = sup.SupplierCode,
                    SupplierId = sup.SupplierID,
                    SupplierName = sup.SupplierName,
                    SupplierItems = GetSupplierItems(sup.SupplierID.ToString())

                });
            }
        }
        return lstSuppliers;
    }

    public List<SupplierItemResponse> GetSupplierItems(string supplierId)
    {
        List<SupplierItemResponse> lstSupItem = null;
        CoreModel.Supplier supp = new PurchaseOrderController().GetSuplier(Convert.ToInt32(supplierId));
        if (supp != null)
        {
            lstSupItem = new List<SupplierItemResponse>();
            foreach (CoreModel.SupplierItem item in supp.SupplierItems)
            {
                lstSupItem.Add(new SupplierItemResponse()
                {
                    ItemName = item.Item.ItemName,
                    ItemId = item.ItemID,
                    Description = item.Item.ItemDesc,
                    SupplierId = item.SupplierId
                });
            }
        }
        return lstSupItem;
    }

    public bool CreatePurchaseOrder(PurchaseOrderRequest request)
    {
        PurchaseOrderUtil poUtil = new PurchaseOrderUtil();
        poUtil.OrderedBy = request.CreatedyBy;
        poUtil.SuplierId = request.SupplierId;
        poUtil.PoNumber = "PON" + new Random().Next(1000, 9999).ToString();
        poUtil.OrderDate = DateTime.Now;

        foreach (POItemRequest req in request.Items)
        {
            poUtil.Items.Add(new PurchaseOrderItems()
            {
                ItemId = req.ItemId,
                ReorderQuantity = req.Quantity
            });
        }
        return new PurchaseOrderController().CreatePO(poUtil);
    }

    public List<DisbursementResponse> GetDisbursements(string departmentId)
    {
        List<DisbursementResponse> lstRes = null;
        List<CoreModel.Disbursement> lstDis = new DisbursementController().GetDisbursements(Convert.ToInt32(departmentId));
        if (lstDis.Count > 0)
        {
            lstRes = new List<DisbursementResponse>();

            foreach (CoreModel.Disbursement dsb in lstDis)
            {
                lstRes.Add(new DisbursementResponse()
                {
                    DisbursementNum = dsb.DisbursementNumber,
                    ReqNum = dsb.Requisition.ReqNumber,
                    RequestedDate = dsb.Requisition.ReqDate.ToString()
                });
            }
        }
        return lstRes;
    }

    public bool ProcessDisbursement(DisbursementRequest disReq)
    {
        List<Tuple<int, int>> items = new List<Tuple<int, int>>();
        disReq.Items.ForEach(val => items.Add(new Tuple<int, int>(val.ItemId, val.NeededQuantity)));
        return new DisbursementController().ProcessDisbursement(disReq.DisbId, disReq.Key, disReq.ReceivedBy, items);
    }

    public bool AckRequisition(AckRequisitionRequest roleReq)
    {
        AckRequisition reqCore = new AckRequisition();
        reqCore.AcknowledgedBy = roleReq.AcknowledgedBy;
        reqCore.Remarks = roleReq.Remarks;
        reqCore.ReqId = roleReq.ReqId;
        reqCore.Status = roleReq.Status;
        return new ApproveRejectReqController().AckRequisition(reqCore);
    }
    #endregion
}