namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        [Key]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [StringLength(20)]
        public string CountryName { get; set; }

        [StringLength(4)]
        public string Currency { get; set; }

        public int? TimeZone { get; set; }
    }
}
