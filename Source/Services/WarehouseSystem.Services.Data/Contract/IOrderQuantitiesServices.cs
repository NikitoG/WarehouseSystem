namespace WarehouseSystem.Services.Data.Contract
{
    using System.Collections.Generic;
    using System.Linq;
    using WarehouseSystem.Data.Models;

    public interface IOrderQuantitiesServices
    {
        void Add(IList<OrderQuantity> order);

        IQueryable<OrderQuantity> GetByOrderId(int id);
    }
}
