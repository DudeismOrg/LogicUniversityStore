using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Hod
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        RequestHistoryController reqController = new RequestHistoryController();
        int reqId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reqId = Convert.ToInt32(Request.QueryString["id"]);
                List<RequisitionItem> items = reqController.getRequisitionItemList(reqId);
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ItemName"), new DataColumn("NeededQuantity"), new DataColumn("UOM") });
                foreach (RequisitionItem i in items)
                {
                    DataRow r = dt.NewRow();
                    r["ItemName"] = i.SupplierItem.Item.ItemName;
                    r["NeededQuantity"] = i.NeededQuantity;
                    r["UOM"] = i.SupplierItem.Item.UOM;
                    dt.Rows.Add(r);
                }
                gvRequisitionDetails.DataSource = dt;
                gvRequisitionDetails.DataBind();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestHistory.aspx");
        }
    }
}