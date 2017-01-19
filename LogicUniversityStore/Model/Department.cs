namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    [Serializable]

    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Requisitions = new HashSet<Requisition>();
            LUUsers = new HashSet<LUUser>();
        }

        public int DepartmentID { get; set; }

        [Required]
        [StringLength(10)]
        public string DepartmentCode { get; set; }

        [StringLength(20)]
        public string DepartmentName { get; set; }

        [StringLength(20)]
        public string ContactName { get; set; }

        [StringLength(10)]
        public string DepartmentPhone { get; set; }

        [StringLength(10)]
        public string DepartmentFax { get; set; }

        public int? HodID { get; set; }

        public int? CollectionPointID { get; set; }

        public int? RepresentativeID { get; set; }

        public virtual CollectionPoint CollectionPoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requisition> Requisitions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUUser> LUUsers { get; set; }
    }
}
