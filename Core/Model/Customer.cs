namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [StringLength(4)]
        public string CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(2)]
        public string MemberCategory { get; set; }

        [StringLength(65)]
        public string Address { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(4)]
        public string OldPostalCode { get; set; }

        [StringLength(6)]
        public string PostalCode { get; set; }

        [StringLength(3)]
        public string CountryCode { get; set; }

        [StringLength(2)]
        public string ContactTitle { get; set; }

        [StringLength(9)]
        public string PhoneNumber { get; set; }

        [StringLength(5)]
        public string Extension { get; set; }

        [StringLength(30)]
        public string FaxNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }
    }
}
