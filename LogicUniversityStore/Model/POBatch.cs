namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POBatch")]
    [Serializable]
    public partial class POBatch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POBatch()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int POBatchID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? POBatchDate { get; set; }

        public bool? Printed { get; set; }

        public int? GeneratedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
