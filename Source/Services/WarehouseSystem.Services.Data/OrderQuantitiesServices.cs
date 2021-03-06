﻿namespace WarehouseSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

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

        public IQueryable<OrderQuantity> GetByOrderId(int id)
        {
            return this.quantities.All().Where(o => o.PurchaseOrderId == id);
        }
    }
}
