using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Model;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Util;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class DisbursementsMain : System.Web.UI.Page
    {
        public List<Requisition> requisition { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ReqIdSess"] != null)
            {
                string reqID = Session["ReqIdSess"].ToString();
                SaveDeliveredItems(reqID);
            }
            requisition = new List<Requisition>();
            if (!IsPostBack)
            {
                DisbursementController disbursControl = new DisbursementController();
                List<Model.Department> depts = new List<Model.Department>();
                depts.Add(new Model.Department()
                {
                    DepartmentID = 0,
                    DepartmentName = "-- Select One Department --"
                });
                depts.AddRange(disbursControl.GetAllDepartments());
                DdlDepartment.DataValueField = "DepartmentID";
                DdlDepartment.DataTextField = "DepartmentName";
                DdlDepartment.DataSource = depts;
                DdlDepartment.DataBind();


            }
        }


        [System.Web.Services.WebMethod]
        public static string GetSetSessionValue(string ReqIdSess)
        {
            if (ReqIdSess.Length > 0)
            {
                HttpContext.Current.Session["ReqIdSess"] = ReqIdSess;
            }
            if (HttpContext.Current.Session["ReqIdSess"] != null)
            {
                ReqIdSess = Convert.ToString(HttpContext.Current.Session["ReqIdSess"]);
            }
            return ReqIdSess;
        }

        protected void DdlDepartment_Change(object sender, EventArgs e)
        {
            DisbursementController disbursControl = new DisbursementController();
            if (Convert.ToInt32(DdlDepartment.SelectedValue) != 0)
            {
                int DeptId = Convert.ToInt32(DdlDepartment.SelectedValue);
                requisition = disbursControl.GetAllShipedRequsitionByDept(DeptId);
            }
        }

        public void SaveDeliveredItems(string reqId)
        {
            DisbursementController disbursControl = new DisbursementController();
            int reqIdInt = Convert.ToInt32(reqId);
            List<RequisitionItem> reqItms = disbursControl.GetShipedReqItmsByReqId(reqIdInt);
            foreach (RequisitionItem reqitm in reqItms)
            {
                int deliverdQuantity = Convert.ToInt32(Request.Form["delivered-"+ reqitm.ReqItemID]);
                disbursControl.saveDeliveredStatusToReq(reqitm.ReqItemID, deliverdQuantity);
            }
            disbursControl.SaveRequsitionAsDelivered(reqIdInt);
            Session["ReqIdSess"] = null;
            Response.Redirect("DisbursementsMain.aspx");
        }

        public string ReqIdColumnDetail()
        {
            string html = String.Empty;
            foreach (Requisition req in requisition)
            {
                html = (html + Eval(req.ReqID.ToString()));
            }
            return html;
        }

        public List<RequisitionItem> getAllRequsitionByItemId(string ReqId)
        {
            List<RequisitionItem> reqItmList = new List<RequisitionItem>();
            ProcessReqController ReqControl = new ProcessReqController();


            if (ReqId == "")
            {
                ReqId = "0";
            }
            int id = Convert.ToInt32(ReqId);
            reqItmList = ReqControl.GetRequisitionItems(id);
            if (reqItmList == null)
            {
                reqItmList = ReqControl.GetRequisitionItems(1);
                return reqItmList;
            }
            else
            {
                return reqItmList;
            }

        }


    }
}