namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequisitionItem")]
    public partial class RequisitionItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReqItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReqID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }

        public int? NeededQuantity { get; set; }

        public int? RetirevedQuantity { get; set; }

        public int? DisbursedQuantity { get; set; }

        public int? DisbursementID { get; set; }

        public int? RetrievalID { get; set; }

        public bool? IsOutstanding { get; set; }

        public virtual Disbursement Disbursement { get; set; }

        public virtual Requisition Requisition { get; set; }

        public virtual Retrieval Retrieval { get; set; }

        public virtual SupplierItem SupplierItem { get; set; }
    }
}
