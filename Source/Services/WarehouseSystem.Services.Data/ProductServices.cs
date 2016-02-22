using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.Data.Common;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Services.Data.Contract;

namespace WarehouseSystem.Services.Data
{
    public class ProductServices : IProductServices
    {
        private IDbRepository<Product> products;

        public ProductServices(IDbRepository<Product> products)
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

        public int CountProductsByUser(User user)
        {
            if (user.Organization.IsSupplier)
            {
                return this.products.All().Count(p => p.SupplierId == user.OrganizationId);
            }
            else
            {
                return user.Organization.Partners.Sum(s => s.Products.Count());
            }
        }

        public IQueryable<Product> GetProductsBySupplier(int id)
        {
            return this.products.All().Where(p => p.SupplierId == id);
        }
    }
}
