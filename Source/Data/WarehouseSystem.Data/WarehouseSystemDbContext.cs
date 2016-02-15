using System;
using System.Linq;
using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using WarehouseSystem.Data.Models;

    public class WarehouseSystemDbContext : IdentityDbContext<User>, IWarehouseSystemDbContext
    {
        public WarehouseSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static WarehouseSystemDbContext Create()
        {
            return new WarehouseSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Division> Divisions { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<PublicMessage> PublicMessages { get; set; }

        public IDbSet<OrderQuantity> OrderQuantities { get; set; }

        public IDbSet<Organization> Organizations { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public IDbSet<ScheduleOrder> ScheduleOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Message>()
                .HasRequired(m => m.To)
                .WithMany(t => t.ReceivedMessages)
                .HasForeignKey(m => m.ToId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Message>()
                .HasRequired(m => m.From)
                .WithMany(t => t.SendMessages)
                .HasForeignKey(m => m.FromId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Category>()
                .HasRequired(m => m.Division)
                .WithMany(t => t.Categories)
                .HasForeignKey(m => m.DivisionId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Product>()
                .HasRequired(m => m.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(m => m.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<OrderQuantity>()
                .HasRequired(m => m.Product)
                .WithMany(t => t.OrderQuantities)
                .HasForeignKey(m => m.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<OrderQuantity>()
                .HasRequired(m => m.PurchaseOrder)
                .WithMany(t => t.OrderQuantities)
                .HasForeignKey(m => m.PurchaseOrderId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<PurchaseOrder>()
                .HasRequired(m => m.Client)
                .WithMany(t => t.Clients)
                .HasForeignKey(m => m.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<PurchaseOrder>()
                .HasRequired(m => m.Supplier)
                .WithMany(t => t.Suppliers)
                .HasForeignKey(m => m.SupplierId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<PurchaseOrder>()
                .HasRequired(m => m.Creator)
                .WithMany(t => t.Orders)
                .HasForeignKey(m => m.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<ScheduleOrder>()
                .HasRequired(m => m.Client)
                .WithMany(t => t.ScheduleOrdersClient)
                .HasForeignKey(m => m.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<ScheduleOrder>()
                .HasRequired(m => m.Supplier)
                .WithMany(t => t.ScheduleOrdersSupplier)
                .HasForeignKey(m => m.SupplierId)
                .WillCascadeOnDelete(false);

            //modelBuilder
            //    .Entity<User>()
            //    .HasRequired(m => m.Organization)
            //    .WithMany(t => t.Employees)
            //    .HasForeignKey(m => m.OrganizationId)
            //    .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Product>()
                .HasRequired(m => m.Supplier)
                .WithMany(t => t.Products)
                .HasForeignKey(m => m.SupplierId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
