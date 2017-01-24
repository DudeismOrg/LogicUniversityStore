using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Department.Employee
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public RequestHistoryController reqController = new RequestHistoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //gvRequestHistory.DataSource = reqController.getRequisitionList();
                //gvRequestHistory.DataBind();
                List<Requisition> items = reqController.getRequisitionList();

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ReqID"), new DataColumn("ReqNumber"), new DataColumn("ReqDate"), new DataColumn("Status"), new DataColumn("Remark") });
                foreach (Requisition i in items)
                {
                    DataRow r = dt.NewRow();
                    r["ReqID"] = i.ReqID;
                    r["ReqNumber"] = i.ReqNumber;
                    r["ReqDate"] = i.ReqDate.ToLongDateString();
                    r["Status"] = i.Status;
                    r["Remark"] = i.Remark;
                    dt.Rows.Add(r);

                }
                gvRequestHistory.DataSource = dt;
                gvRequestHistory.DataBind();


            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[3].Text == RequisitionStatus.Requested.ToString())
                {
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Brown;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                }
                else if (e.Row.Cells[3].Text == RequisitionStatus.Approved.ToString())
                {
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                }
                else if (e.Row.Cells[3].Text == RequisitionStatus.Rejected.ToString())
                {
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvRequestHistory, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }



        }

        protected void gvRequestHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int reqId = Convert.ToInt32(gvRequestHistory.SelectedRow.Cells[0].Text);


            Response.Redirect("RequestHistoryDetails.aspx?id=" + reqId + "");
        }
    }
}