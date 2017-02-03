using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Model;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class DeliveryOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PurchaseOrderController poc = new PurchaseOrderController();
                List<POBatch> lstPoBatch = new List<POBatch>();
                lstPoBatch.Add(new POBatch() {
                    POBatchID = 0,
                    BatchNumber = "-- Select One Batch Number --",
                });
                lstPoBatch.AddRange(poc.getAllPoBatch());
                DdlBatchNumber.DataSource = lstPoBatch;
                DdlBatchNumber.DataValueField = "POBatchID";
                DdlBatchNumber.DataTextField = "BatchNumber";
                DdlBatchNumber.DataBind();

                SupplierController suppContr = new SupplierController();
                List<Supplier> lstSuppliers = new List<Supplier>(); 
                lstSuppliers.Add(new Supplier()
                {
                    SupplierID = 0,
                    SupplierName = "-- Select One Supplier --"
                });
                lstSuppliers.AddRange(suppContr.getAllSuppliers());
                DdlSupplier.DataSource = lstSuppliers;
                DdlSupplier.DataValueField = "SupplierID";
                DdlSupplier.DataTextField = "SupplierName";
                DdlSupplier.DataBind();

            }
        }

        protected void DdlBatchNumber_Change(object sender, EventArgs e)
        {
            if(Convert.ToInt32(DdlBatchNumber.SelectedValue) != 0) { 
                gvPoBySupplier.Visible = false;
                gvPoByBatchNumb.Visible = true;
                DdlSupplier.SelectedIndex = 0;
                PurchaseOrderController pocont = new PurchaseOrderController();
                int batchId = Convert.ToInt32(DdlBatchNumber.SelectedValue);
                List<PurchaseOrder> poList = pocont.FindAllPurchaseOrderByBatch(batchId);
                gvPoByBatchNumb.DataSource = poList;
                gvPoByBatchNumb.DataBind();
            }
        }

        protected void DdlSupplier_Change(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DdlSupplier.SelectedValue) != 0)
            {
                gvPoByBatchNumb.Visible = false;
                gvPoBySupplier.Visible = true;
                DdlBatchNumber.SelectedIndex = 0;
                PurchaseOrderController pocont = new PurchaseOrderController();
                int suplierId = Convert.ToInt32(DdlSupplier.SelectedValue);
                List<PurchaseOrder> poList = pocont.FindAllPurchaseOrderBySupplier(suplierId);
                gvPoBySupplier.DataSource = poList;
                gvPoBySupplier.DataBind();
            }
        }

    }
}