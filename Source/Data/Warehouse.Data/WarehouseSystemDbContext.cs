namespace WarehouseSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WarehouseSystem.Models;

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

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Division> Divisions { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<OrderQuantity> OrderQuantities { get; set; }

        public IDbSet<Organization> Organizations { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public IDbSet<ScheduleOrder> ScheduleOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasRequired(p => p.Organization)
                .WithMany(x => x.Employees)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<PurchaseOrder>()
                .HasRequired(p => p.Creator)
                .WithMany(x => x.Orders)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany(x => x.Products)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Category>()
                .HasRequired(p => p.Division)
                .WithMany(x => x.Categories)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<OrderQuantity>()
                .HasRequired(p => p.Product)
                .WithMany(x => x.OrderQuantities)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<OrderQuantity>()
                .HasRequired(p => p.PurchaseOrder)
                .WithMany(x => x.OrderQuantities)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
