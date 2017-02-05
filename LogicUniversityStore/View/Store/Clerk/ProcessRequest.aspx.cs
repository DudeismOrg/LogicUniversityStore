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
        Dictionary<Requisition, double> listRequests;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["reqListRetrieval"] = null;

            if ( Request.Params.Get("IsAlter") == null)
            {
                processReq = new ProcessReqController();

                listRequests = processReq.GetMainProcessReqList();
                Session["mainList"] = listRequests;
                Session["lockedItem"] = processReq.LockedItem;
                Session["reqList"] = processReq.ProcessedRequistions;
                // var listRequests = (from r in processReq.GetMainProcessReqList() select new { r.Item1 , r.Item2.ReqNumber, r.Item2.Department.DepartmentName, r.Item2.ReqDate, r.Item2.ReqID }).ToList();
               

            }
            else if (Request.Params.Get("IsAlter") != null)
            {
                if (Session["reqList"] != null )
                {
                    ProcessReqController alteredCon = new ProcessReqController((List<Requisition>)Session["reqList"]);
                    listRequests = alteredCon.GetMainProcessReqListAltered();
                }
                else
                {
                    listRequests = (Dictionary<Requisition, double>)Session["mainList"];

                }

                if (Request.Params.Get("IsAlter").Equals("True"))
                    Response.Write("<script language='javascript'> alert('saved successfully!!!'); </script>");
                else if(Request.Params.Get("IsAlter").Equals("False"))
                {
                    Response.Write("<script language='javascript'> alert('Amount Invalid !!!'); </script>");
                }

            }
            if (!IsPostBack)
            {
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
            List<Requisition> sesReq = (List<Requisition>)Session["reqList"];
            foreach (GridViewRow row in gvRequisitions.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("cbReq");

                if (check.Checked)
                {
                   int reqId =  Convert.ToInt32(row.Cells[1].Text);
                   
                   reqList.Add(sesReq.Find(r => r.ReqID == reqId));
                    //string name = row.Cells[1].;
                }
                
            }

            Session["reqListRetrieval"] = reqList;

            string page = "/View/Store/Clerk/Modal/CreateRetreivalForm.aspx";

            // ClientScript.RegisterClientScriptBlock(this.GetType(), "Popup", "ShowPopup('" + page + "');", true);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Popup", "HideControl();", true);


            // ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert('fjjfa')", true);

            //// Response.Write("  <script language='javascript'> window.open('/View/Store/Clerk/Modal/RetrievalForm.aspx','','width=1020,Height=720,fullscreen=1,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");

            //Popup.Show(this, page);
            Response.Redirect(page);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }


}