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
                int requestIDq = Convert.ToInt32(Request.Form["Id"]);
                Dictionary<int,int> lockedItems = (Dictionary<int, int>)Session["lockedItem"];
                StockCardDao sDao = new StockCardDao();
                List<RequisitionItem> items = processReq.GetRequisitionItems(requestIDq);

                Dictionary<RequisitionItem, int> itemsWithOnhand = new Dictionary<RequisitionItem, int>();
                foreach (var item in items)
                {
                    itemsWithOnhand[item] = sDao.GetProductCountInStock(item.ItemID) - lockedItems[item.ItemID];
                }
                //Label1.Text = requestIDq.ToString();
                var listRequestItems = (from i in processReq.GetRequisitionItems(requestIDq)
                                        join s in processReq.GetAllStockCard() on i.ItemID equals s.ItemID
                                        select new
                                        {
                                            i.ItemID,
                                            i.ReqID,
                                            i.ReqItemID,
                                            i.NeededQuantity,
                                            s.StockCardID,
                                            i.SupplierItem.Item.ItemName,
                                            s.OnHandQuantity,
                                            i.ApprovedQuantity
                                        }).ToList();



                //  lvItemsInReq.DataSource = listRequestItems.ToList();
                lvItemsInReq.DataSource = itemsWithOnhand;
                lvItemsInReq.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           // Response.Redirect("~/View/Store/Clerk/ProcessRequest.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}