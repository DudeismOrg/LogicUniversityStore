using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    [Serializable]
    public class CartItem
    {
        public Category Category { get; set; }

        public SupplierItem  SupplierItem { get; set; }
        public int Quantity { get; set; }
    }
}