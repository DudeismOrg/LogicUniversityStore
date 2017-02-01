namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ControlTable")]
    public partial class ControlTable
    {
        [Key]
        [StringLength(10)]
        public string NumberType { get; set; }

        public int? FirstFreeNo { get; set; }
    }
}
