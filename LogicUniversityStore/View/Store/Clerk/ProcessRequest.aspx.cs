using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Controller;
using System.Data;
using LogicUniversityStore.Model;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class ProcessRequest : System.Web.UI.Page
    {
        public ProcessReqController processReq { get; set; }
        public ApplyReqController reqController { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            processReq = new ProcessReqController();
            reqController = new ApplyReqController();

            List<Category> cat = reqController.GetCategories();

            var query = (from d in cat


                         select new
                         {
                             d.CategoryCode
                         }).ToList();


            lvSearchResults.DataSource = query.ToList();


            lvSearchResults.DataBind();


        }
    }
}