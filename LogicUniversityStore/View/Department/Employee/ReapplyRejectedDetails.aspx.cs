using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Employee
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        ReapplyRejectedController reqController = new ReapplyRejectedController();
        RequisitionItem ri = new RequisitionItem();

        DataTable dt;
        DataRow r;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int reqId = Convert.ToInt32(Request.QueryString["id"]);
                List<RequisitionItem> items = reqController.getRequisitionItemList(reqId);

                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ItemName"), new DataColumn("NeededQuantity"), new DataColumn("UOM") });
                foreach (RequisitionItem i in items)
                {
                    r = dt.NewRow();
                    r["ItemName"] = i.SupplierItem.Item.ItemName;
                    r["NeededQuantity"] = i.NeededQuantity;
                    r["UOM"] = i.SupplierItem.Item.UOM;
                    dt.Rows.Add(r);
                }
                ViewState["dt"] = dt;
                bindGrid();
            }
        }

        protected void bindGrid()
        {
            gvRequisitionDetails.DataSource = (DataTable)ViewState["dt"];
            gvRequisitionDetails.DataBind();
        }
    }
}