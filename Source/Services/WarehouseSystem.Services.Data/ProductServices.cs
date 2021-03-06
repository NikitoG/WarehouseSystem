﻿namespace WarehouseSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

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

        public Product GetById(int id)
        {
            return this.products.GetById(id);
        }

        public Product Update(Product product)
        {
            var entity = this.products.GetById(product.Id);

            entity.Name = product.Name;
            entity.Sku = product.Sku;
            entity.Barcode = product.Barcode;
            entity.HeigthInCm = product.HeigthInCm;
            entity.WidthInCm = product.WidthInCm;
            entity.WeightInGr = product.WeightInGr;
            entity.DeliveryUnit = product.DeliveryUnit;
            entity.Stock = product.Stock;
            entity.MinDayOfExpiryInDays = product.MinDayOfExpiryInDays;
            entity.IsBlocked = product.IsBlocked;
            entity.CreatedOn = product.CreatedOn;
            entity.ModifiedOn = product.ModifiedOn;
            entity.IsDeleted = product.IsDeleted;
            entity.DeletedOn = product.DeletedOn;

            this.products.Save();

            return entity;
        }

        public Product Add(Product product)
        {
            this.products.Add(product);
            this.products.Save();

            return product;
        }

        public void Delete(Product product)
        {
            this.products.Delete(product);
        }

        public IQueryable<Product> All()
        {
            return this.products.All();
        }
    }
}
