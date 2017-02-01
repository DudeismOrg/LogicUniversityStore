namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerContact")]
    public partial class CustomerContact
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CustomeName { get; set; }

        [StringLength(10)]
        public string TelephoneNo { get; set; }
    }
}
