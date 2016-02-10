using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Data.Repositories;
using WarehouseSystem.Services.Data.Contract;

namespace WarehouseSystem.Services.Data
{
    public class ProductServices : IProductServices
    {
        private IRepository<Product> products;

        public ProductServices(IRepository<Product> products)
        {
            this.products = products;
        }

        public IList<string> GetNames()
        {
            return this.products
                .All()
                .Select(o => o.Name)
                .ToList();
        }
    }
}
