using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Model;
using LogicUniversityStore.Dao;
using System.Data.Entity.Validation;
using LogicUniversityStore.Controller;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class PurchaseOrderConfirm : System.Web.UI.Page
    {
        public PurchaseOrderController PurchaseOrderController { get; set; }
        List<PurchaseOrderUtil> finalPO;
        protected void Page_Load(object sender, EventArgs e)
        {
            finalPO = Session["selectedPO"] as List<PurchaseOrderUtil>;
            if (!IsPostBack)
            {
                fillGridView();
            }
        }


        public void fillGridView()
        {
            gvPurchaseOrders.DataSource = finalPO;
            gvPurchaseOrders.DataBind();
        }

        public void POnfirmPo_Click(object sender, EventArgs e)
        {
            PurchaseOrderController POController = new PurchaseOrderController();

            List<PurchaseOrderUtil> newPOUlist = new List<PurchaseOrderUtil>();
            PoBatchDao dao = new PoBatchDao();
            PurchaseOrderDao pdao = new PurchaseOrderDao();
            PurchaseOrderItemDao poitem = new PurchaseOrderItemDao();


            foreach (GridViewRow row in gvPurchaseOrders.Rows)
            {
                int SuplierId = Convert.ToInt32((row.Cells[0].FindControl("idVal") as TextBox).Text);
                PurchaseOrderUtil pou = finalPO.Where(f => f.Supplier.SupplierID == SuplierId).FirstOrDefault();
                pou.Remark = (row.Cells[7].FindControl("supRemark") as TextBox).Text;
                pou.OrderDate = DateTime.Now;
                pou.PoNumber = SuplierId.ToString();
                newPOUlist.Add(pou);
            }

            POController.SavePurchaseOrder(newPOUlist);

            Response.Write("<script language='javascript'> alert('Purchase order saved successfully!!!'); </script>");
            Response.Redirect("ClrkMain.aspx");

        }

    }
}