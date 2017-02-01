namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Retrieval")]
    [Serializable]
    public partial class Retrieval
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Retrieval()
        {
            RequisitionItems = new HashSet<RequisitionItem>();
        }

        public int RetrievalID { get; set; }

        [Required]
        [StringLength(20)]
        public string RetrievalNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RetrievalDate { get; set; }

        public int? Retriever { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }
    }
}
