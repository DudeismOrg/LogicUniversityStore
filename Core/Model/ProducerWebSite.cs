namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProducerWebSite")]
    public partial class ProducerWebSite
    {
        [Key]
        [StringLength(50)]
        public string Producer { get; set; }

        [StringLength(200)]
        public string Website { get; set; }
    }
}
