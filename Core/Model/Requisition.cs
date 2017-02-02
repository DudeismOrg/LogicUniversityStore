namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Requisition")]
    [Serializable]
    public partial class Requisition :IEquatable<Requisition>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requisition()
        {
            RequisitionItems = new HashSet<RequisitionItem>();
        }

        [Key, ForeignKey("Disbursement")]
        public int ReqID { get; set; }

        [Required]
        [StringLength(10)]
        public string ReqNumber { get; set; }

        public int RequesterID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReqDate { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public int ApprovedRejectedByID { get; set; }

        public int? RecieveByID { get; set; }

        public int DepartmentID { get; set; }

        [StringLength(120)]
        public string Remark { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public int? DisbursementID { get; set; }

        public virtual Department Department { get; set; }

        public virtual Disbursement Disbursement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }

        public bool Equals(Requisition other)
        {
            return this.ReqID.Equals(other.ReqID);
        }

        public override int GetHashCode()
        {
            return ReqID;
        }
    }
}
