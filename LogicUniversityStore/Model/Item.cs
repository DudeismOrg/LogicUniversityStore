namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            SupplierItems = new HashSet<SupplierItem>();
        }

        [Key]
        public int BaseItemID { get; set; }

        [Required]
        [StringLength(15)]
        public string BaseItemCode { get; set; }

        [StringLength(30)]
        public string BaseItemName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(10)]
        public string UOM { get; set; }

        public double? BasePrice { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public int? CategoryID { get; set; }

        public int? ReorderLevel { get; set; }

        public int? ReorderQuantity { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierItem> SupplierItems { get; set; }
    }
}
