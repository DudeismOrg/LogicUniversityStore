using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    [Serializable]
    public class AdjustmentItem
    {

        public AdjustmentItem(int categoryId, string categoryName, int itemId, string itemName, int quantity, string remarks, string unitOfMeasure)
        {
            this.CategoryId = categoryId;
            this.ItemId = itemId;
            this.Quantity = quantity;
            this.Remarks = remarks;
            this.CategoryName = categoryName;
            this.ItemName = itemName;
            this.UnitOfMeasure = unitOfMeasure;
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }


        private int itemId;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string unitOfMeasure;

        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

    }
}