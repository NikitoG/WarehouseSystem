using System.Collections.Generic;
using WarehouseSystem.Data.Common;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Services.Data.Contract;

namespace WarehouseSystem.Services.Data
{
    public class OrderQuantitiesServices : IOrderQuantitiesServices
    {
        private IDbRepository<OrderQuantity> quantities;

        public OrderQuantitiesServices(IDbRepository<OrderQuantity> quantities)
        {
            this.quantities = quantities;
        }

        public void Add(IList<OrderQuantity> order)
        {
            foreach (var quantity in order)
            {
                this.quantities.Add(quantity);
            }
            this.quantities.Save();
        }
    }
}
