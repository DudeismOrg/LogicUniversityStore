namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IssueTran")]
    public partial class IssueTran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TransactionID { get; set; }

        [StringLength(4)]
        public string CustomerID { get; set; }

        public short? VideoCode { get; set; }

        public DateTime? DateIssue { get; set; }

        public DateTime? DateDue { get; set; }

        public DateTime? DateActualReturn { get; set; }

        [StringLength(3)]
        public string RentalStatus { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }
    }
}
