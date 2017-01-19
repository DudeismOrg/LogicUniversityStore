namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Requisition")]
    [Serializable]

    public partial class Requisition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requisition()
        {
            RequisitionItems = new HashSet<RequisitionItem>();
        }

        [Key]
        public int ReqID { get; set; }

        [Required]
        [StringLength(10)]
        public string ReqNumber { get; set; }

        public int RequesterID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReqDate { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public int? ApprovedRejectedByID { get; set; }

        public int? RecieveByID { get; set; }

        public int DapartmentID { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }
    }
}
