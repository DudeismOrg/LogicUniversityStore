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
    public partial class WebForm5 : System.Web.UI.Page
    {
        public CancelUpdatePendingApprovalController reqController = new CancelUpdatePendingApprovalController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int requesterId = 2;//todo while login
                List<Requisition> items = reqController.getRequestedRequisition(requesterId);
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ReqID"), new DataColumn("ReqNumber"), new DataColumn("ReqDate"), new DataColumn("Remark") });
                foreach (Requisition i in items)
                {
                    DataRow r = dt.NewRow();
                    r["ReqID"] = i.ReqID;
                    r["ReqNumber"] = i.ReqNumber;
                    r["ReqDate"] = i.ReqDate.ToLongDateString();
                    r["Remark"] = i.Remark;
                    dt.Rows.Add(r);
                }
                ViewState["dt"] = dt;
                gvPendingRequests.DataSource = dt;
                gvPendingRequests.DataBind();
            }
        }

        protected void gvPendingRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int reqId = Convert.ToInt32(gvPendingRequests.Rows[rowIndex].Cells[0].Text);
            DataTable dt = (DataTable)ViewState["dt"];
            DataRow dr = dt.Rows[rowIndex];
            reqController.removeRequisitionItems(reqId);
            bool result = reqController.removeRequisition(reqId);
            dt.Rows[rowIndex].Delete();
            ViewState["dt"] = dt;
            gvPendingRequests.DataSource = (DataTable)ViewState["dt"];
            gvPendingRequests.DataBind();
        }

        protected void gvPendingRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            int reqId = Convert.ToInt32(gvPendingRequests.SelectedRow.Cells[0].Text);
            Response.Redirect("CancelUpdatePendingDetails.aspx?id=" + reqId + "");
        }
    }
}

