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
            //DeptUsageNEW dusagerpt = new DeptUsageNEW();
            //CrystalReportViewer1.ReportSource = dusagerpt;
            //CrystalReportViewer1.Zoom(90);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dept_Usage_Category dusagerpt = new Dept_Usage_Category();
                CrystalReportViewer1.ReportSource = dusagerpt;
                Session["Dept_Usage_Category"] = dusagerpt;
                CrystalReportViewer1.Zoom(90);
            }
            else
            {
                Dept_Usage_Category doc = (Dept_Usage_Category)Session["Dept_Usage_Category"];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
    }
}