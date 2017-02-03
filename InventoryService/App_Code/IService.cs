using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/Validate", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    UserResponse ValidateUser(UserRequest userReq);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/Requisition/Create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    bool CreateRequisition(RequisitionRequest request);

    #region Clerk - View Requisitions, Generate Retreival Form
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Requisition/Status/{status}", ResponseFormat = WebMessageFormat.Json)]
    List<RequisitionResponse> GetRequisitionsByStatus(string status);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Requisition/{reqId}", ResponseFormat = WebMessageFormat.Json)]
    List<RequisitionItemResponse> GetReqItemDetailsByReqId(string reqId);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/GenerateRetreival", ResponseFormat = WebMessageFormat.Json)]
    string GenerateRetreivalForm(RetreivalRequest retReq);

    #endregion

    #region UserProfile, HOD - Users, ManageUser
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Users/{deptId}", ResponseFormat = WebMessageFormat.Json)]
    List<UserResponse> GetUsersByDeptId(string deptId);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Roles/{deptType}", ResponseFormat = WebMessageFormat.Json)]
    List<RoleResponse> GetRolesByDeptType(string deptType);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/ManageRole", ResponseFormat = WebMessageFormat.Json)]
    bool UpdateUserRole(ManageRoleRequest roleReq);
    #endregion

    #region Clerk - Outstanding
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Outstanding", ResponseFormat = WebMessageFormat.Json)]
    List<RequisitionItemResponse> GetOutstandingItems();

    #endregion

    #region Clerk - Create PurchaseOrder
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Suppliers", ResponseFormat = WebMessageFormat.Json)]
    List<SupplierResponse> GetSuppliers();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/SupplierItems/{supplierId}", ResponseFormat = WebMessageFormat.Json)]
    List<SupplierItemResponse> GetSupplierItems(string supplierId);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/PurchaseOrder/Create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    bool CreatePurchaseOrder(PurchaseOrderRequest request);


    #endregion

    #region

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/Disbursement/{departmentId}", ResponseFormat = WebMessageFormat.Json)]
    List<DisbursementResponse> GetDisbursements(string departmentId);


    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/Disbursement/Process", ResponseFormat = WebMessageFormat.Json)]
    bool ProcessDisbursement(DisbursementRequest disReq);

    #endregion
}
