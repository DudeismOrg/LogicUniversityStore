namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderItem")]
    [Serializable]
    public partial class PurchaseOrderItem
    {
        [Key]
        public int PurchaeOrderItemID { get; set; }

        public int ItemID { get; set; }

        public int PurchaseOrderID { get; set; }

        public int? RequestedQuantity { get; set; }

        public int? ActualQuantity { get; set; }

        public int? ReceivedQuantity { get; set; }

        public double? UnitPrice { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual SupplierItem SupplierItem { get; set; }
    }
}
