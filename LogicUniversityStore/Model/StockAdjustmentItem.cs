namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockAdjustmentItem")]
    [Serializable]

    public partial class StockAdjustmentItem
    {
        public int StockAdjustmentItemID { get; set; }

        public int StockAdjustmentID { get; set; }

        public int ItemID { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Required]
        [StringLength(20)]
        public string AdjustType { get; set; }

        public int CountQuantity { get; set; }

        [Required]
        [StringLength(30)]
        public string CountPerson { get; set; }

        [Column(TypeName = "date")]
        public DateTime CountDate { get; set; }

        [Required]
        [StringLength(60)]
        public string Remark { get; set; }

        public int AdjustQuantity { get; set; }

        public virtual StockAdjustment StockAdjustment { get; set; }

        public virtual SupplierItem SupplierItem { get; set; }
    }
}
