using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStore.Controller;
using LogicUniversityStore.Model;
using LogicUniversityStore.Dao;

namespace LogicUniversityStore.View.Store.Clerk.Modal
{
    public partial class RequestFormAlterItems : System.Web.UI.Page
    {
        public ApplyReqController reqController { get; set; }
        public ProcessReqController processReq { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            processReq = new ProcessReqController();
            if (!IsPostBack)
            {
                int reqId = Convert.ToInt32(Request.Form["Id"]);
                ViewState["reqId"] = reqId;
                List<Requisition> reqList =  (List<Requisition>) Session["reqList"];
                StockCardDao sDao = new StockCardDao();
                Requisition req = reqList.Find(r=>r.ReqID == reqId);
                Dictionary<RequisitionItem, int> itemsWithOnhand = new Dictionary<RequisitionItem, int>();
                foreach (var item in req.RequisitionItems.ToList())
                {
                    itemsWithOnhand[item] = sDao.GetProductCountInStock(item.SupplierItem.ItemID);
                }

                gvAlter.DataSource = itemsWithOnhand;
                gvAlter.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int reqId = (int)ViewState["reqId"];
            List<Requisition> reqList = (List<Requisition>)Session["reqList"];
            Dictionary<int,int> lockedItem = (Dictionary<int, int>)Session["lockedItem"];
            if(reqList == null || lockedItem == null)
            {
                processReq.Reset();
                reqList = processReq.ProcessedRequistions;
                lockedItem = processReq.LockedItem;
            }
            ProcessReqAlterController controller = new ProcessReqAlterController(reqList, lockedItem);
            Requisition req = reqList.Find(r => r.ReqID == reqId);
            List<RequisitionItem> items = req.RequisitionItems.ToList();
            RequisitionItem item;
            int id , value;
            bool IsUpdate = true;
            for(int i =0; i < gvAlter.Rows.Count; i++)
            {
                GridViewRow row = gvAlter.Rows[i];
               
                value = Convert.ToInt32(((TextBox)row.FindControl("tbAmount")).Text);
                item =  items[i];
                if (item.ApprovedQuantity == value) continue;
                bool flag = controller.updateRequistionItem(item, value);
                if (!flag)
                {
                    IsUpdate = false;
                }
            }
            Response.Redirect("~/View/Store/Clerk/ProcessRequest.aspx?IsAlter="+IsUpdate.ToString());
        }

       
        protected void btnCancell_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Store/Clerk/ProcessRequest.aspx?IsAlter=cancell");

        }
    }
}