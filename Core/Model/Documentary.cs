namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Documentary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short VideoCode { get; set; }

        [StringLength(50)]
        public string VideoTitle { get; set; }

        [StringLength(30)]
        public string MovieType { get; set; }

        [StringLength(3)]
        public string Rating { get; set; }

        public float? Price { get; set; }

        [StringLength(50)]
        public string Producer { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        [StringLength(50)]
        public string Media { get; set; }

        public short? TotalStock { get; set; }

        public short? NumberRented { get; set; }

        public short? PreviousEpisode { get; set; }
    }
}
