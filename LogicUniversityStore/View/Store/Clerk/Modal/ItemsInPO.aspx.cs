using LogicUniversityStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStore.View.Store.Clerk.Modal
{
    public partial class ItemsInPO : System.Web.UI.Page
    {
        public List<PurchaseOrderItems> finalPoItems;
        public List<PurchaseOrderItems> showItemsList;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                int suplierId = Convert.ToInt32(Request.Form["Id"]);
                finalPoItems = Session["ItemsInPO"] as List<PurchaseOrderItems>;
                this.showItemsList = finalPoItems.Where(x => x.PoSupplier.SupplierID == suplierId).ToList();
                lvItemsInPO.DataSource = showItemsList;
                lvItemsInPO.DataBind();
            }
        }

    }
}