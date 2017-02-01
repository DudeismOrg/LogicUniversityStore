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
        public int StockCardID { get; set; }
        [Index(IsUnique = true)]
        public int ItemID { get; set; }

        public int? OnHandQuantity { get; set; }

        [StringLength(10)]
        public string Remarks { get; set; }

        [StringLength(10)]
        public string BinNumber { get; set; }



        public virtual Item Item { get; set; }
    }
}
