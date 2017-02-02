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

        [Key, ForeignKey("Requisition")]
        public int DisbursementID { get; set; }

        [Required]
        [StringLength(20)]
        public string DisbursementNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisbursementDate { get; set; }

        public int? Receiver { get; set; }

        public int? DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Key { get; set; }

        public virtual Requisition Requisition { get; set; }

    }
}
