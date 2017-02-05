using Core.Controller;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoreModel = LogicUniversityStore.Model;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class Outstanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CoreModel.LUUser user = new UserController().ValidateUser("clerk", "clerk");

            //List<CoreModel.Supplier> sup = 

            new ApplyReqController().GetToBeApproveRequisitions(1);

            List<CoreModel.RequisitionItem> lstCoreReqItems = new ProcessReqController().GetOutstandingItems();
            gvItems.DataSource = lstCoreReqItems;
            gvItems.DataBind();

            //Testing controllers code for WCF

            //List<CoreModel.Supplier> lstCoreSup = new PurchaseOrderController().GetSuppliers();
            //if (lstCoreSup.Count > 0)
            //{
            //    foreach (CoreModel.Supplier sup in lstCoreSup)
            //    {

            //        text.Append(sup.SupplierCode);
            //        text.Append(sup.SupplierID);
            //        text.Append(sup.SupplierName);

            //    }
            //}

            //CoreModel.Supplier supp = new PurchaseOrderController().GetSuplier(Convert.ToInt32(1));
            //if (supp != null)
            //{
            //    foreach (CoreModel.SupplierItem item in supp.SupplierItems)
            //    {
            //        text.Append(item.Item.ItemCode);

            //        text.Append(item.ItemID);

            //        text.Append(item.SupplierId);

            //    }
            //}

            // Disbursement
            #region Disbursement
            // new DisbursementController().GetDisbursements(1);
            // List<Tuple<int, int>> items = new List<Tuple<int, int>>();
            // items.Add(new Tuple<int, int>(5, 5));
            // items.Add(new Tuple<int, int>(8, 6));
            // new DisbursementController().ProcessDisbursement(1, "100", 1, items);

            //List<CoreModel.LUUser> users = new UserController().GetUsersByDeptCode(3);
            #endregion

            #region RetrevialForm
            //Retreival Form
            //List<Tuple<string, string, int>> reqs = new RetreiveReqController().GetRetreivalCounts("1");
            #endregion

            #region PO
            //PO
            //  CoreModel.POBatch poBatch = new LogicUniversityStore.Model.POBatch()
            //  {
            //      GeneratedBy = 1,
            //      POBatchDate = DateTime.Now
            //  };
            //  CoreModel.Supplier sup = new PurchaseOrderController().GetSupplierById(1);
            //  CoreModel.PurchaseOrder order = new LogicUniversityStore.Model.PurchaseOrder()
            //  {
            //      OrderEmpID = 1,
            //      SupplierID = 1,
            //      PuchaseOrderNo = "#" + 1.ToString() + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Month + "/" + DateTime.Now.Hour + DateTime.Now.Minute,
            //      OrderDate = DateTime.Now,
            //      DeliveryAddress = "",
            //      ExpectedDeliveryDate = DateTime.Now.AddDays(Convert.ToDouble(sup.MinDeliveryDay)),
            //      POStatus = "Requested"
            //  };
            //
            //  CoreModel.Item coreItem = new PurchaseOrderController().GetItemByItemId(1);
            //  order.PurchaseOrderItems.Add(
            //      new CoreModel.PurchaseOrderItem()
            //      {
            //          ItemID = 1,
            //          RequestedQuantity = 10,
            //          UnitPrice = new PurchaseOrderController().GetUnitPrice(coreItem, sup)
            //      }
            //      );
            //
            //  new PurchaseOrderController().CreatePO(poBatch, order);
            #endregion
        }

    }
}