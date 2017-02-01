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
        public virtual DbSet<LUUser> LUUsers { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<POBatch> POBatches { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<RequisitionItem> RequisitionItems { get; set; }
        public virtual DbSet<Retrieval> Retrievals { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StockAdjustment> StockAdjustments { get; set; }
        public virtual DbSet<StockAdjustmentItem> StockAdjustmentItems { get; set; }
        public virtual DbSet<StockCard> StockCards { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierItem> SupplierItems { get; set; }

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
                .Property(e => e.DepartmentCode)
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
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.DisbursementNumber)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemCode)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemName)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemDesc)
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

            modelBuilder.Entity<LUUser>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<LUUser>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<LUUser>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<LUUser>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<LUUser>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<LUUser>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<LUUser>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.LUUser)
                .HasForeignKey(e => e.SenderUserID);

            modelBuilder.Entity<LUUser>()
                .HasMany(e => e.Notifications1)
                .WithOptional(e => e.LUUser1)
                .HasForeignKey(e => e.ReciverUserID);

            modelBuilder.Entity<Notification>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.status)
                .IsFixedLength();

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
                .Property(e => e.Remark)
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
                .HasMany(e => e.LUUsers)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockAdjustment>()
                .Property(e => e.SockAdjustmentNumber)
                .IsFixedLength();

            modelBuilder.Entity<StockAdjustment>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<StockAdjustment>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<StockAdjustment>()
                .HasMany(e => e.StockAdjustmentItems)
                .WithRequired(e => e.StockAdjustment)
                .WillCascadeOnDelete(false);

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
                .Property(e => e.GSTRegistrationNumber)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.PurchaseOrderItems)
                .WithRequired(e => e.SupplierItem)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.RequisitionItems)
                .WithRequired(e => e.SupplierItem)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.StockAdjustmentItems)
                .WithRequired(e => e.SupplierItem)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierItem>()
                .HasMany(e => e.StockCards)
                .WithRequired(e => e.SupplierItem)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);
        }
    }
}
