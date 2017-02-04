using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    public class PurchaseOrderItems
    {
        private Item poItem;
        private int reorderQuantity;
        private Supplier poSupplier;
        private int createdBy;
        private DateTime createdDate;

        private int itemId;
        public int ItemId
        {
            get { return poItem.ItemID; }
            set { this.ItemId = value; }
        }
        private string itemName;
        public string ItemName
        {
            get { return poItem.ItemDesc; }
        }
        private string catagory;
        public string Catagory
        {
            get { return poItem.Category.ToString(); }
        }


        public Item PoItem
        {
            get { return poItem; }
            set { poItem = value; }
        }


        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }


        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public Supplier PoSupplier
        {
            get { return poSupplier; }
            set { poSupplier = value; }
        }

        public int ReorderQuantity
        {
            get { return reorderQuantity; }
            set { reorderQuantity = value; }
        }

    }
}