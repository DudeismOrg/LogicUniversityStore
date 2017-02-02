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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public RequestHistoryController reqController = new RequestHistoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LUUser user = (LUUser)Session["User"];
                int depId = user.DepartmentID.Value;
                List<Requisition> items = reqController.getRequisitionList(depId);
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ReqID"), new DataColumn("ReqNumber"),new DataColumn("ReqDate"),new DataColumn("Status"), new DataColumn("Remark") });
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
        protected void gvRequestHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int reqId = Convert.ToInt32(gvRequestHistory.SelectedRow.Cells[0].Text);
            Response.Redirect("RequestHistoryDetails.aspx?id=" + reqId + "");
        }        
    }
}
    
