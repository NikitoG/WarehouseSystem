using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IWarehouseSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Division> Divisions { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<OrderQuantity> OrderQuantities { get; set; }

        IDbSet<Organization> Organizations { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<PurchaseOrder> PurchaseOrders { get; set; }

        IDbSet<ScheduleOrder> ScheduleOrders { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
