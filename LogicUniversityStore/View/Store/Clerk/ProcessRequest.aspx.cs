using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Controller;
using System.Data;
using LogicUniversityStore.Model;
using System.Web.Services;
using System.Web.Script.Services;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class ProcessRequest : System.Web.UI.Page
    {
        public ProcessReqController processReq { get; set; }
        public ApplyReqController reqController { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                /* if (Application["processReq"] == null)
            {
                Application["processReq"] = new ProcessReqController();
            }

            processReq = (ProcessReqController)Application["processReq"]; //in future will think about it. 
            */
                processReq = new ProcessReqController();

                Dictionary<Requisition, double> listRequests;
                if (ViewState["prItems"] == null)
                {
                    ViewState["prItems"] = processReq.GetMainProcessReqList();
                }

                if (((Dictionary<Requisition, double>)ViewState["prItems"]).Count < this.processReq.GetApprovedRequistionCount())
                {
                    ViewState["prItems"] = processReq.GetMainProcessReqList();
                }
                listRequests = (Dictionary<Requisition, double>)ViewState["prItems"];
                // var listRequests = (from r in processReq.GetMainProcessReqList() select new { r.Item1 , r.Item2.ReqNumber, r.Item2.Department.DepartmentName, r.Item2.ReqDate, r.Item2.ReqID }).ToList();
                gvRequisitions.DataSource = listRequests;

                gvRequisitions.DataBind();
            }
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetInt(string id)
        {           
            return id;
        }

        protected void btnGenRetrival_Click(object sender, EventArgs e)
        {
            List<Requisition> reqList = new List<Requisition>();
            RequisitionDao dao = new RequisitionDao();
            foreach (GridViewRow row in gvRequisitions.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("cbReq");

                if (check.Checked)
                {
                   reqList.Add( dao.Find(Convert.ToInt32(row.Cells[1].Text)));
                    //string name = row.Cells[1].;
                }
                
            }

            Session["reqListRetrieval"] = reqList;

            string page = "/View/Store/Clerk/Modal/RetrievalForm.aspx";

          // ClientScript.RegisterClientScriptBlock(this.GetType(), "Popup", "ShowPopup('" + page + "');", true);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Popup", "HideControl();", true);


            // ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert('fjjfa')", true);

            //// Response.Write("  <script language='javascript'> window.open('/View/Store/Clerk/Modal/RetrievalForm.aspx','','width=1020,Height=720,fullscreen=1,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");

            Popup.Show(this, page);
        }
    }


}