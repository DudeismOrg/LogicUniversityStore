namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockCard")]
    [Serializable]

    public partial class StockCard
    {
        public int ItemID { get; set; }

        public int? OnHandQuantity { get; set; }

        [StringLength(10)]
        public string Remarks { get; set; }

        [StringLength(10)]
        public string BinNumber { get; set; }

        public int StockCardID { get; set; }

        public int? LockedQuantity { get; set; }

        public virtual SupplierItem SupplierItem { get; set; }
    }
}
