using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Reports
{
    public partial class DisplayDeptUsagePeriod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Dept_Usage_DATE dusprpt = new Dept_Usage_DATE();
            //CrystalReportViewer1.ReportSource = dusprpt;
            //CrystalReportViewer1.Zoom(90);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dept_Reqs_Period depreqperiod = new Dept_Reqs_Period();
                CrystalReportViewer1.ReportSource = depreqperiod;
                Session["Dept_Reqs_Period"] = depreqperiod;
                CrystalReportViewer1.Zoom(90);
            }
            else
            {
                Dept_Reqs_Period doc = (Dept_Reqs_Period)Session["Dept_Reqs_Period"];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
    }
}