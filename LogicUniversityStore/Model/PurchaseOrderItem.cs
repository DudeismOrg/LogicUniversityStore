namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderItem")]
    public partial class PurchaseOrderItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaeOrderItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseOrderID { get; set; }

        public int? RequestedQuantity { get; set; }

        public int? ActualQuantity { get; set; }

        public int? ReceivedQuantity { get; set; }

        public double? UnitPrice { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual SupplierItem SupplierItem { get; set; }
    }
}
