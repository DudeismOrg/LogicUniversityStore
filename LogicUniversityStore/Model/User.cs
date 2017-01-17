namespace LogicUniversityStore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Password { get; set; }

        public int RoleID { get; set; }

        [StringLength(15)]
        public string Email { get; set; }

        [StringLength(25)]
        public string Address { get; set; }

        public int? DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        public virtual Role Role { get; set; }
    }
}
