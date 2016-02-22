﻿namespace WarehouseSystem.Services.Data.Contract
{
    using System.Linq;
    using System.Collections.Generic;
    using WarehouseSystem.Data.Models;

    public interface IProductServices
    {
        IList<string> GetNames();

        int CountProductsByUser(User user);

        IQueryable<Product> GetProductsBySupplier(int id);
    }
}
