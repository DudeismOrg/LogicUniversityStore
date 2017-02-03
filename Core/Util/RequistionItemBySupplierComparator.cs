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
            return x.SupplierItemID == y.SupplierItemID;
        }

        public int GetHashCode(RequisitionItem obj)
        {
           return obj.SupplierItemID.GetHashCode();
        }
    }
}