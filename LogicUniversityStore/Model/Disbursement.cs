namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Disbursement")]
    [Serializable]
    public partial class Disbursement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disbursement()
        {
            RequisitionItems = new HashSet<RequisitionItem>();
        }

        public int DisbursementID { get; set; }

        [Required]
        [StringLength(20)]
        public string DisbursementNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisbursementDate { get; set; }

        public int? Receiver { get; set; }

        public int? DepartmentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }
    }
}
