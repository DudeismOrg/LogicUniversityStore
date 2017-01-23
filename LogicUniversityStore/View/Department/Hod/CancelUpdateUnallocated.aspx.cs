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

namespace LogicUniversityStore.View.Department.Hod
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        public CancelUpdateUnallocatedController reqController = new CancelUpdateUnallocatedController();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                List<Requisition> req = new List<Requisition>();
                req = reqController.GetApprovedRejectedRequisition();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ReqID"), new DataColumn("ReqNumber"), new DataColumn("ReqDate"),new DataColumn("Status") });
                foreach (Requisition i in req)
                {
                    DataRow r = dt.NewRow();
                    r["ReqID"] = i.ReqID;
                    r["ReqNumber"] = i.ReqNumber;
                    r["ReqDate"] = i.ReqDate.ToLongDateString();
                    r["Status"] = i.Status;
                    dt.Rows.Add(r);
                }
                gvRequisition.DataSource = dt;
                gvRequisition.DataBind();

                
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvRequisition, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvRequisition_SelectedIndexChanged(object sender, EventArgs e)
        {

            int reqId = Convert.ToInt32(gvRequisition.SelectedRow.Cells[0].Text);


            Response.Redirect("CancelUpdateUnallocatedDetails.aspx?id=" + reqId + "");
        }

    }
}