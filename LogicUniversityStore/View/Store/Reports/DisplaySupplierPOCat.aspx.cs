using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Reports
{
    public partial class DisplaySupplierPOCat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PO_Supplier_Category posuppcat = new PO_Supplier_Category();
                CrystalReportViewer1.ReportSource = posuppcat;
                Session["PO_Supplier_Category"] = posuppcat;
                CrystalReportViewer1.Zoom(90);
            }
            else
            {
                PO_Supplier_Category doc = (PO_Supplier_Category)Session["PO_Supplier_Category"];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
    }
}