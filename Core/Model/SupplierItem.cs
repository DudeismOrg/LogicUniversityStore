namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupplierItem")]
    [Serializable]
    public partial class SupplierItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierItem()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
            RequisitionItems = new HashSet<RequisitionItem>();
            StockAdjustmentItems = new HashSet<StockAdjustmentItem>();
         
        }

        public int SupplierItemId { get; set; }

        public int ItemID { get; set; }

        public int SupplierID { get; set; }

        public double? Price { get; set; }

        public bool? ActiveSupplier { get; set; }

        public int? SupplierPriority { get; set; }

        public virtual Item Item { get; set; }

        public virtual String SupplierName { get { return SupplierNameNumber(); } }
        
        public virtual int SupplierId { get { return GetSupplierId(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockAdjustmentItem> StockAdjustmentItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual Supplier Supplier { get; set; }

        public virtual String SupplierNameNumber()
        {
            return this.Supplier.SupplierName + " - " + this.Supplier.SupplierPhone;
        }

        public virtual int GetSupplierId()
        {
            return this.Supplier.SupplierID;
        }

        public override string ToString()
        {
            return this.Item.ItemName;
        }


    }
}
