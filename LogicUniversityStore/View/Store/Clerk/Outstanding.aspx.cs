using Core.Controller;
using LogicUniversityStore.Controller;
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
            List<CoreModel.RequisitionItem> lstCoreReqItems = new ProcessReqController().GetOutstandingItems();
            StringBuilder text = new StringBuilder();
            foreach (CoreModel.RequisitionItem item in lstCoreReqItems)
            {
                text.Append(item.SupplierItem.Item.ItemName);
                text.Append(item.Requisition.Department.DepartmentName);
                text.Append(((item.NeededQuantity.HasValue ? item.NeededQuantity.Value : 0) - (item.RetirevedQuantity.HasValue ? item.RetirevedQuantity.Value : 0)));
            }

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

            // new DisbursementController().ProcessDisbursement(1, "vas", 1);
        }
    }
}