namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    [Serializable]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            SupplierItems = new HashSet<SupplierItem>();
        }

        public int ItemID { get; set; }

        [Required]
        [StringLength(15)]
        public string ItemCode { get; set; }

        [StringLength(30)]
        public string ItemName { get; set; }

        [StringLength(50)]
        public string ItemDesc { get; set; }

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
        public override string ToString()
        {
            return this.ItemName;
        }

        public SupplierItem GetSupplierItem()
        {
            List<SupplierItem> sList = new List<SupplierItem>(this.SupplierItems);
            SupplierItem item = sList.Find(i => i.ActiveSupplier == true && i.SupplierPriority == 1);
            return item;
        }
    }
}
