namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Producer
    {
        [Key]
        [Column("Producer")]
        [StringLength(50)]
        public string Producer1 { get; set; }

        [StringLength(50)]
        public string ProducerName { get; set; }

        [StringLength(3)]
        public string CountryCode { get; set; }
    }
}
