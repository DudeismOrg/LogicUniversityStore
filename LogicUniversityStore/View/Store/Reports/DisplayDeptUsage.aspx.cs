using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Reports
{
    public partial class DisplayDeptUsage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DeptUsage dusagerpt = new DeptUsage();
            //CrystalReportViewer1.ReportSource = dusagerpt;
            //CrystalReportViewer1.Zoom(90);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeptUsage dusagerpt = new DeptUsage();                
                CrystalReportViewer1.ReportSource = dusagerpt;
                Session["DeptUsage"] = dusagerpt;
                CrystalReportViewer1.Zoom(90);
            }
            else
            {
                DeptUsage doc = (DeptUsage)Session["DeptUsage"];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
    }
}