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

            //if ( Request.Params.Get("IsAlter") == null)
            //{
            //    processReq = new ProcessReqController();

            //    listRequests = processReq.GetMainProcessReqList();
            //    Session["mainList"] = listRequests;
            //    Session["lockedItem"] = processReq.LockedItem;
            //    Session["reqList"] = processReq.ProcessedRequistions;
            //}
            //else if (Request.Params.Get("IsAlter") != null)
            //{
            //    listRequests =(Dictionary<Requisition, double>)Session["mainList"];

            //    if (Request.Params.Get("IsAlter").Equals("True"))
            //    {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alertBox('Amount Saved  successfully!!!')", true);
            //    }
            //    else if (Request.Params.Get("IsAlter").Equals("False"))
            //    {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alertBox('Amount Invalid !!! Please enter a valid amount.')", true);
            //    }
            //}

            if (Request.Params.Get("IsAlter") == null)
            {
                processReq = new ProcessReqController();

                listRequests = processReq.GetMainProcessReqList();
                Session["mainList"] = listRequests;
                Session["lockedItem"] = processReq.LockedItem;
                Session["reqList"] = processReq.ProcessedRequistions;
            }
            else if (Request.Params.Get("IsAlter") != null)
            {
                if (Session["reqList"] != null)
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
                else if (Request.Params.Get("IsAlter").Equals("False"))
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
                    TextBox reqIdText = (TextBox)row.Cells[1].FindControl("reqIdHiden");
                    int reqId = Convert.ToInt32(reqIdText.Text);
                    reqList.Add(sesReq.Find(r => r.ReqID == reqId));
                }
            }
            Session["reqListRetrieval"] = reqList;
            string page = "/View/Store/Clerk/Modal/CreateRetreivalForm.aspx";
            Response.Redirect(page);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }


}