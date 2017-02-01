namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    [Serializable]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            LUUsers = new HashSet<LUUser>();
        }

        public int RoleID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleCode { get; set; }

        [StringLength(30)]
        public string RoleName { get; set; }

        public string DepType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUUser> LUUsers { get; set; }
    }
}
