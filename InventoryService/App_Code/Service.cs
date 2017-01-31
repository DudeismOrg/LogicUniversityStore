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

    public List<UserResponse> GetUsersByDeptCode(string deptCode)
    {
        List<UserResponse> lstUsers = null;
        List<CoreModel.LUUser> users = new UserController().GetUsersByDeptCode(deptCode);
        if (users.Count > 0)
        {
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

    #endregion

    #region Outstanding

    public List<RequisitionItemResponse> GetOutstandingItems()
    {
        List<RequisitionItemResponse> lstItems = null;
        List<CoreModel.RequisitionItem> lstCoreReqItems = new ProcessReqController().GetOutstandingItems();
        foreach (CoreModel.RequisitionItem item in lstCoreReqItems)
        {
            lstItems.Add(new RequisitionItemResponse()
            {
                DeptName = item.Requisition.Department.DepartmentName,
                ItemName = item.SupplierItem.Item.ItemName,
                Quantity = ((item.NeededQuantity.HasValue ? item.NeededQuantity.Value : 0) - (item.RetirevedQuantity.HasValue ? item.RetirevedQuantity.Value : 0))
            });
        }
        return lstItems;
    }

    public List<SupplierResponse> GetSuppliers()
    {
        List<SupplierResponse> lstSuppliers = null;
        //List<CoreModel.Supplier> lstCoreSup = new POController().GetSuppliers();
        //if (lstCoreSup.Count > 0)
        //{
        //    foreach (CoreModel.Supplier sup in lstCoreSup)
        //    {
        //        lstSuppliers.Add(new SupplierResponse()
        //        {
        //            SupplierCode = sup.SupplierCode,
        //            SupplierId = sup.SupplierID,
        //            SupplierName = sup.SupplierName
        //        });
        //    }
        //}
        return lstSuppliers;
    }

    //public List<> GetSupplierItems(string supplierId)
    //{

    //}

    #endregion
}