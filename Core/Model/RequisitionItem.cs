namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequisitionItem")]
    [Serializable]
    public partial class RequisitionItem : IEquatable<RequisitionItem>
    {
        [Key]
        public int ReqItemID { get; set; }

        public int ReqID { get; set; }

        public int SupplierItemID { get; set; }

        public int? NeededQuantity { get; set; }

        public int? ApprovedQuantity { get; set; }
        public int? RetirevedQuantity { get; set; }

        public int? DisbursedQuantity { get; set; }

     //   public int? DisbursementID { get; set; }
        public int? RetrievalID { get; set; }

        public bool? IsOutstanding { get; set; }

      //  public virtual Disbursement Disbursement { get; set; }

        public virtual Requisition Requisition { get; set; }

        //public string ItemName
        //{
        //    get
        //    {
        //        return SupplierItem.Item.ItemName;
        //    }
        //}

        public string DepartmentName
        {
            get
            {
                return this.Requisition.Department.DepartmentName;
            }
        }

        public int OutstandingQty
        {
            get
            {
                return ((NeededQuantity.HasValue ? NeededQuantity.Value : 0) - (RetirevedQuantity.HasValue ? RetirevedQuantity.Value : 0));
            }
        }

        public virtual SupplierItem SupplierItem { get; set; }

        public virtual Retrieval Retrieval { get; set; }

        public Category GetCategory()
        {
            return this.SupplierItem.Item.Category;
        }

        public Item GetItem()
        {
            return this.SupplierItem.Item;
        }
        public Department GetDepartment()
        {
            return this.Requisition.Department;
        }

        public bool Equals(RequisitionItem other)
        {
            return this.ReqItemID.Equals(other.ReqItemID);
        }
        public override int GetHashCode()
        {
            return this.ReqItemID.GetHashCode();
        }
        public override string ToString()
        {
            return this.GetItem().ItemName;
        }
    }
}
