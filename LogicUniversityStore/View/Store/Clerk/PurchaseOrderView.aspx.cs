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
using System.Web.Services;
using System.Web.Script.Services;

namespace LogicUniversityStore.View.Store.Clerk
{
    public partial class PurchaseOrderView : System.Web.UI.Page
    {
        public PurchaseOrderController PurchaseOrderController { get; set; }
        public ApplyReqController reqController = new ApplyReqController();
        public string removeItemID;
        public List<Item> ItemsToPurchase;
        private List<CartItem> items;
        private Category category;
        private Item item;
        private ItemDao itemDao;
        protected void Page_Load(object sender, EventArgs e)
        {
            PurchaseOrderController purchaseOrder = new PurchaseOrderController();

            if (!IsPostBack)
            {
                if (ViewState["purxhaseOrderItems"] == null)
                {
                    ViewState["purxhaseOrderItems"] = purchaseOrder.GetItems();
                    ItemsToPurchase = (List<Item>)ViewState["purxhaseOrderItems"];
                    fillGridView();
                }
                else
                {
                    ItemsToPurchase = (List<Item>)ViewState["purxhaseOrderItems"];
                    fillGridView();
                }

                itemDao = new ItemDao();
                DdlCategories.DataSource = reqController.GetCategories();
                DdlCategories.DataValueField = "CategoryID";
                DdlCategories.DataTextField = "CategoryCode";
                DdlCategories.DataBind();
            }
            else
            {
                if (ViewState["purxhaseOrderItems"] != null)
                {
                    ItemsToPurchase = (List<Item>)ViewState["purxhaseOrderItems"];
                    //fillGridView();
                }
            }

            
        }

        protected void DdlCategories_Change(object sender, EventArgs e)
        {
            int catId = Convert.ToInt32(DdlCategories.SelectedValue);
            category = reqController.CategoryDao.GetCategory(catId);
            if (DdlItems.SelectedValue != null && !DdlItems.SelectedValue.Equals(""))
            {
                item = new ItemDao().GetItem(Convert.ToInt32(DdlItems.SelectedValue));
            }
            DdlItems.DataSource = category.Items;
            DdlItems.DataTextField = "ItemName";
            DdlItems.DataValueField = "ItemID";
            DdlItems.DataBind();
        }


        protected void DeleteRow(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = gvReqItems.Rows[index];
            ItemsToPurchase.Remove(ItemsToPurchase.Where(i => i.ItemID == Convert.ToInt32(gvReqItems.DataKeys[index].Value)).FirstOrDefault());
            ViewState["items"] = ItemsToPurchase;
            fillGridView();
        }

        public void fillGridView()
        {
            gvReqItems.DataSource = ItemsToPurchase;
            gvReqItems.DataBind();
        }


        public string getSupplierNameNumber(int suplierId)
        {
            PurchaseOrderController purchaseOrder = new PurchaseOrderController();
            return purchaseOrder.supplierNameNumber(suplierId);
        }



        public List<SupplierItem> getAllSupplierItems(Item item)
        {
            PurchaseOrderController purchaseOrder = new PurchaseOrderController();
            return purchaseOrder.getAllSuplierItems(item);
        }



        protected void btnAddPurchaseOrderItem_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(DdlItems.SelectedValue);
            Item item = new ItemDao().GetItem(itemId);
            List<Item> itemList = (List<Item>)ViewState["purxhaseOrderItems"];
            itemList.Add(item);
            ViewState["purxhaseOrderItems"] = itemList;
            fillGridView();
        }


        protected void gvItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (!IsPostBack)
            //{
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlSupplier");
                    ddl.DataSource = ((Item)e.Row.DataItem).SupplierItems;
                    ddl.DataBind();
                }
            //}
        }

        protected void ConfirmItems_Click(object sender, EventArgs e)
        {
            List<PurchaseOrderItems> finalPoItems = new List<PurchaseOrderItems>();
            List<PurchaseOrderUtil> finalPurchaseOrders = new List<PurchaseOrderUtil>();
            foreach (GridViewRow row in gvReqItems.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        PurchaseOrderController purchaseOrder = new PurchaseOrderController();
                        int itemId = Convert.ToInt32(row.Cells[1].Text);
                        Item itm = ItemsToPurchase.Where(i => i.ItemID == itemId).FirstOrDefault();
                        DropDownList supp = (row.Cells[6].FindControl("ddlSupplier") as DropDownList);
                        int supId = Convert.ToInt32(supp.SelectedItem.Value);
                        Supplier selectedSup = purchaseOrder.GetSuplier(supId);

                        PurchaseOrderItems checkedPoItems = new PurchaseOrderItems()
                        {
                            PoItem = itm,
                            PoSupplier = selectedSup,
                            ReorderQuantity = Convert.ToInt32((row.Cells[0].FindControl("txtReorder") as TextBox).Text),
                            CreatedDate = DateTime.Now,
                        };
                        finalPoItems.Add(checkedPoItems);
                    }
                }
            }

            List<PurchaseOrderItems> distSupp = finalPoItems.GroupBy(z => z.PoSupplier.SupplierID).Select(y => y.First()).ToList();
            foreach(PurchaseOrderItems poi in distSupp)
            {
                PurchaseOrderUtil pou = new PurchaseOrderUtil() {
                    Supplier = poi.PoSupplier,
                    OrderDate = DateTime.Now,
                    Items = finalPoItems.Where(q => q.PoSupplier.SupplierID == poi.PoSupplier.SupplierID).ToList(),
                };
                finalPurchaseOrders.Add(pou);
            }
            Session["selectedPO"] = finalPurchaseOrders;
            Session["ItemsInPO"] = finalPoItems;
            Response.Redirect("PurchaseOrderConfirm.aspx");
        }
    }
}