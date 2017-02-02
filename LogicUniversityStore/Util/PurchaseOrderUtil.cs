using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    public class PurchaseOrderUtil
    {
        private List<PurchaseOrderItems> items;
        private string poNumber;
        private Supplier supplier;
        private DateTime orderDate;
        private string deliveryAddress;
        private int orderedBy;
        private string remark;

        private int suplierId;
        public int SuplierId
        {
            get { return supplier.SupplierID; }  
        }
        private string suplierName;
        public string SuplierName
        {
            get { return supplier.SupplierName; }
        }
        private string supplierContact;
        public string SupplierContact
        {
            get { return supplier.SupplierContact; }
        }
        private string supplierPhone;
        public string SupplierPhone
        {
            get { return supplier.SupplierPhone; }
        }
        private string supplierAddress;
        public string SupplierAddress
        {
            get { return supplier.SupplierAddress; }
        }
        private string registration;
        public string Registration
        {
            get { return supplier.GSTRegistrationNumber; }
        }
        private String expectedDeliveryDate;
        public String ExpectedDeliveryDate
        {
            get { return DateTime.Now.AddDays(Convert.ToDouble(supplier.MinDeliveryDay)).ToString(); }
        }


        public List<PurchaseOrderItems> Items
        {
            get { return items; }
            set { items = value; }
        }
        public string PoNumber
        {
            get { return poNumber; }
            set { poNumber = value; }
        }
        public Supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        public string DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }
        public int OrderedBy
        {
            get { return orderedBy; }
            set { orderedBy = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

    }
}