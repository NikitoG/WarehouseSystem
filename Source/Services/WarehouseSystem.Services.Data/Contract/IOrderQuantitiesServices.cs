using System.Collections.Generic;
using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Services.Data.Contract
{
    public interface IOrderQuantitiesServices
    {
        void Add(IList<OrderQuantity> order);
    }
}
