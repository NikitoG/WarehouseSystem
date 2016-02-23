using System.Collections.Generic;
using System.Linq;
using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Services.Data.Contract
{
    public interface IOrderQuantitiesServices
    {
        void Add(IList<OrderQuantity> order);

        IQueryable<OrderQuantity> GetByOrderId(int id);
    }
}
