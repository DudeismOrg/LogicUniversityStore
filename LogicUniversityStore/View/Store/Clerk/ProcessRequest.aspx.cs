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

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class ProcessRequest : System.Web.UI.Page
    {
        public ProcessReqController processReq { get; set; }
        public ApplyReqController reqController { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            processReq = new ProcessReqController();
            var listRequests = (from r in processReq.GetMainProcessReqList() select new { r.Item1 , r.Item2.ReqNumber, r.Item2.Department.DepartmentName, r.Item2.ReqDate, r.Item2.ReqID }).ToList();
            lvSearchResults.DataSource = listRequests.ToList();
            lvSearchResults.DataBind();
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetInt(string id)
        {           
            return id;
        }
    }


}