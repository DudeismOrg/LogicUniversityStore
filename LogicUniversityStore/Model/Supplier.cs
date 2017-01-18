namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            SupplierItems = new HashSet<SupplierItem>();
        }

        public int SupplierID { get; set; }

        [StringLength(10)]
        public string SupplierCode { get; set; }

        [StringLength(30)]
        public string SupplierName { get; set; }

        [StringLength(30)]
        public string SupplierContact { get; set; }

        [StringLength(20)]
        public string SupplierPhone { get; set; }

        [StringLength(20)]
        public string SupplierFax { get; set; }

        [StringLength(100)]
        public string SupplierAddress { get; set; }

        [StringLength(20)]
        public string GSTRegistrationNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierItem> SupplierItems { get; set; }
    }
}
