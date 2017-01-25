using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    public class Adjustment
    {
        private int adjustmentId;
        private string number;
        private DateTime createdDate;
        private int createdBy;
        private AdjustmentType type;
        private List<AdjustmentItem> items;

        public List<AdjustmentItem> Items
        {
            get { return items; }
            set { items = value; }
        }


        public AdjustmentType Type
        {
            get { return type; }
            set { type = value; }
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

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public int AdjustmentId
        {
            get { return adjustmentId; }
            set { adjustmentId = value; }
        }


    }
}