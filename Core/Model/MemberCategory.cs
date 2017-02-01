namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberCategory
    {
        [Key]
        [Column("MemberCategory", Order = 0)]
        [StringLength(2)]
        public string MemberCategory1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string MemberCatDescription { get; set; }
    }
}
