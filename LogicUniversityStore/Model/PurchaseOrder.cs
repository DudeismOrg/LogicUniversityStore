namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrder")]
    [Serializable]

    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
        }

        public int PurchaseOrderID { get; set; }

        [Required]
        [StringLength(15)]
        public string PuchaseOrderNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [StringLength(20)]
        public string DeliveryAddress { get; set; }

        [StringLength(10)]
        public string POStatus { get; set; }

        public int? SupplierID { get; set; }

        public int? OrderEmpID { get; set; }

        [StringLength(20)]
        public string DONumber { get; set; }

        [StringLength(10)]
        public string PORemark { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
