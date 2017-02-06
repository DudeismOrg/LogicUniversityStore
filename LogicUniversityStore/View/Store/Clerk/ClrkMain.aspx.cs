using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.View.Store.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class ClrkMain : System.Web.UI.Page
    {
        ClerkMainController controller = new ClerkMainController();
        public Dictionary<Item, double> freqCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            LUUser user = (LUUser)Session["user"];
            
            lblReqsCount.Text = new RequisitionDao().GetApprovedRequisitionCount().ToString();


            //PO_Supplier posupp = new PO_Supplier();
            //CrystalReportViewer1.ReportSource = posupp;
            //CrystalReportViewer1.Zoom(50);
            //freqCount =  controller.GetFrequentOrderedReqItem();
            //gvFrequent.DataSource = freqCount;
            //gvFrequent.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PO_Supplier posuppp = new PO_Supplier();
                CrystalReportViewer1.ReportSource = posuppp;
                Session["PO_Supplier"] = posuppp;
                CrystalReportViewer1.Zoom(80);
                CrystalReportViewer1.DisplayToolbar = false;
                CrystalReportViewer1.DisplayStatusbar = false;
                CrystalReportViewer1.HasDrilldownTabs = false;
                CrystalReportViewer1.HasExportButton = false;
                CrystalReportViewer1.HasGotoPageButton = false;
                CrystalReportViewer1.HasPrintButton = false;
                CrystalReportViewer1.HasZoomFactorList = false;
                CrystalReportViewer1.HasToggleGroupTreeButton = false;

            }
            else
            {
                PO_Supplier doc = (PO_Supplier)Session["PO_Supplier"];
                CrystalReportViewer1.ReportSource = doc;
            }
            PO_Supplier posupp = new PO_Supplier();
            CrystalReportViewer1.ReportSource = posupp;
            CrystalReportViewer1.Zoom(50);
            freqCount =  controller.GetFrequentOrderedReqItem();
            //gvFrequent.DataSource = freqCount;
            //gvFrequent.DataBind();
        }

        
    }
}