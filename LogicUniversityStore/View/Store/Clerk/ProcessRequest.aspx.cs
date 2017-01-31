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

            if( ((Dictionary<Requisition,double>)ViewState["prItems"]).Count < this.processReq.GetApprovedRequistionCount())
            {
                ViewState["prItems"] = processReq.GetMainProcessReqList();
            }
            listRequests = (Dictionary<Requisition, double>)ViewState["prItems"];
            lvSearchResults.DataSource = listRequests;
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