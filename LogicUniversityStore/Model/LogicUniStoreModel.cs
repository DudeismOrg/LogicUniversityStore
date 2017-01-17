namespace LogicUniversityStore.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogicUniStoreModel : DbContext
    {
        public LogicUniStoreModel()
            : base("name=LogicUniStoreModel")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CollectionPoint> CollectionPoints { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Disbursement> Disbursements { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<Retrieval> Retrievals { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StockAdjustment> StockAdjustments { get; set; }
        public virtual DbSet<StockAdjustmentItem> StockAdjustmentItems { get; set; }
        public virtual DbSet<StockCard> StockCards { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierItem> SupplierItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual DbSet<RequisitionItem> RequisitionItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryCode)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.Remarks)
                .IsFixedLength();

            modelBuilder.Entity<CollectionPoint>()
                .Property(e => e.CollectionPoint1)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.DeparmentCode)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentName)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.ContactName)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentPhone)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentFax)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Requisitions)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DapartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.DisbursementNumber)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.BaseItemCode)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.BaseItemName)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.UOM)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.PuchaseOrderNo)
                .IsFixedLength();

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.DeliveryAddress)
                .IsFixedLength();

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.POStatus)
                .IsFixedLength();

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.DONumber)
                .IsFixedLength();

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.PORemark)
                .IsFixedLength();

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderItems)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.ReqNumber)
                .IsFixedLength();

            modelBuilder.Entity<Requisition>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Requisition>()
                .HasMany(e => e.RequisitionItems)
                .WithRequired(e => e.Requisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Retrieval>()
                .Property(e => e.RetrievalNumber)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleCode)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockAdjustment>()
                .Property(e => e.SockAdjustmentNumber)
                .IsFixedLength();

            modelBuilder.Entity<StockAdjustment>()
                .HasMany(e => e.StockAdjustmentItems)
                .WithRequired(e => e.StockAdjustment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockAdjustmentItem>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<StockAdjustmentItem>()
                .Property(e => e.AdjustType)
                .IsFixedLength();

            modelBuilder.Entity<StockAdjustmentItem>()
                .Property(e => e.CountPerson)
                .IsFixedLength();

            modelBuilder.Entity<StockAdjustmentItem>()
                .Property(e => e.Remark)
                .IsFixedLength();

            modelBuilder.Entity<StockCard>()
                .Property(e => e.Remarks)
                .IsFixedLength();

            modelBuilder.Entity<StockCard>()
                .Property(e => e.BinNumber)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierCode)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierName)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierContact)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierPhone)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierFax)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierAddress)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .Property(e => e.Price)
                .IsFixedLength();

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.StockCards)
                .WithRequired(e => e.SupplierItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.PurchaseOrderItems)
                .WithRequired(e => e.SupplierItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.RequisitionItems)
                .WithRequired(e => e.SupplierItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsFixedLength();
        }
    }
}
