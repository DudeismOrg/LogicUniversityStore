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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public ReapplyRejectedController reqController = new ReapplyRejectedController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LUUser user = (LUUser)Session["User"];
                int requestorId = user.UserID;
                List<Requisition> items = reqController.getRejectedRequisition(requestorId);
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ReqID"), new DataColumn("ReqNumber"), new DataColumn("ReqDate"), new DataColumn("Remark") });
                foreach(Requisition i in items)
                {
                    DataRow r = dt.NewRow();
                    r["ReqID"] = i.ReqID;
                    r["ReqNumber"] = i.ReqNumber;
                    r["ReqDate"] = i.ReqDate.ToLongDateString();               
                    r["Remark"] = i.Remark;
                    dt.Rows.Add(r);
                }
                ViewState["dt"] = dt;
                gvRejectedRequests.DataSource = dt;
                gvRejectedRequests.DataBind();
            }
        }

        protected void gvRejectedRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            int rowIndex = e.RowIndex;
            int reqId = Convert.ToInt32(gvRejectedRequests.Rows[rowIndex].Cells[1].Text);
            DataTable dt = (DataTable)ViewState["dt"];            
            DataRow dr = dt.Rows[rowIndex];
            reqController.removeRequisitionItems(reqId);
            bool result=reqController.removeRequisition(reqId);
            dt.Rows[rowIndex].Delete();
            ViewState["dt"] = dt;
            gvRejectedRequests.DataSource = (DataTable)ViewState["dt"];
            gvRejectedRequests.DataBind();
        }
        protected void gvRejectedRequisition_SelectedIndexChanged(object sender, EventArgs e)
        {
            int reqId = Convert.ToInt32(gvRejectedRequests.SelectedRow.Cells[1].Text);
            Response.Redirect("ReapplyRejectedDetails.aspx?id=" + reqId + ""); 
        }       
    }
}