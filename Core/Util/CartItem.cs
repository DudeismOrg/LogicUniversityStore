using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    [Serializable]
    public class CartItem : IEquatable<CartItem>
    {
        public Category Category { get; set; }

        public SupplierItem  SupplierItem { get; set; }
        public int Quantity { get; set; }

        public bool Equals(CartItem other)
        {
            return (this.Category.CategoryID == other.Category.CategoryID && this.SupplierItem.ItemID == other.SupplierItem.ItemID);
        }

        public override int GetHashCode()
        {
            return this.SupplierItem.ItemID.GetHashCode();
        }
    }
}