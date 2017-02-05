using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Reports
{
    public partial class DisplaySupplierPOPeriod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PO_Supplier_Period posupprpt = new PO_Supplier_Period();
                CrystalReportViewer1.ReportSource = posupprpt;
                Session["PO_Supplier_Period"] = posupprpt;
                CrystalReportViewer1.Zoom(90);
            }
            else
            {
                PO_Supplier_Period doc = (PO_Supplier_Period)Session["PO_Supplier_Period"];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
    }
}