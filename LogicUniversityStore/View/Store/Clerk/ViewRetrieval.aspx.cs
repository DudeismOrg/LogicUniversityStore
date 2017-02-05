using LogicUniversityStore.Controller;
using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        RetreiveReqController controller;
        RetrievalDao dao = new RetrievalDao();
        StockCardController stockController;
        DisbursementController disbController;
        public Retrieval ret;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                controller = new RetreiveReqController(GetAllRequisition());
                int retrId = getSession();
                ret = controller.GetRetrievalFromId(retrId);
                Dictionary<RequisitionItem, MainRow> dic = controller.GetRow();
                gvRetrieval.DataSource = dic;
                gvRetrieval.DataBind();

                List<Requisition> reqistions = GetAllRequisition();
                gvRequisition.DataSource = reqistions;
                gvRequisition.DataBind();
            }
        }

        private void GvRetrieval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                controller = new RetreiveReqController(GetAllRequisition());
                KeyValuePair<RequisitionItem, MainRow> item = (KeyValuePair<RequisitionItem, MainRow>)e.Row.DataItem;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gvChild = (GridView)e.Row.FindControl("gvChild");
                    gvChild.DataSource = item.Value.DictionaryMap;
                    gvChild.DataBind();

                }
            }
        }

        private List<Requisition> GetAllRequisition()
        {
            int id = Convert.ToInt32(Session["retId"]);
            return dao.GetAllRequistion(dao.Find(id));
        }

        private int getSession()
        {
            return Convert.ToInt32(Session["retId"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Store/Clerk/RetrievalForm.aspx");
        }

        protected void btnCollected_Click(object sender, EventArgs e)
        {
            LUUser user = (LUUser)Session["User"];
            controller = new RetreiveReqController(GetAllRequisition());
            stockController = new StockCardController();
            disbController = new DisbursementController();
            int retrId = getSession();
            foreach (GridViewRow row in gvRetrieval.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox collectedQtyTxt = (row.Cells[4].FindControl("txtRetrevedQuantity") as TextBox);
                    TextBox approvedQtyTxt = (row.Cells[4].FindControl("approvedQuantity") as TextBox);
                    TextBox ItemIdTxt = (row.Cells[4].FindControl("txtItemId") as TextBox);
                    int collectedQty = Convert.ToInt32(collectedQtyTxt.Text);
                    int approvedQty = Convert.ToInt32(approvedQtyTxt.Text);
                    int ItemId = Convert.ToInt32(ItemIdTxt.Text);
                    controller.saveRetrevedQuantity(ItemId, retrId, collectedQty);
                    stockController.UpdateStockItemOnRetreval(ItemId, collectedQty);
                    controller.saveAsRetreved(retrId);
                    disbController.GenerateDisbursement(retrId, user);
                }
            }
            Response.Redirect("/View/Store/Clerk/RetrievalForm.aspx");
        }
    }
}