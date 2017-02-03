using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    public class RequistionItemBySupplierComparator : IEqualityComparer<RequisitionItem>
    {
        public bool Equals(RequisitionItem x, RequisitionItem y)
        {
            return x.ItemID == y.ItemID;
        }

        public int GetHashCode(RequisitionItem obj)
        {
           return obj.ItemID.GetHashCode();
        }
    }
}