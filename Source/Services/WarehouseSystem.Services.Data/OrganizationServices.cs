using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using WarehouseSystem.Data.Common;
using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Services.Data
{
    using WarehouseSystem.Services.Data.Contract;

    public class OrganizationServices : IOrganizationServices
    {
        private IDbRepository<Organization> organizations;

        public OrganizationServices(IDbRepository<Organization> organizations)
        {
            this.organizations = organizations;
        }

        public IQueryable<Organization> GetAll()
        {
            return this.organizations.All();
        }

        public IQueryable<Organization> GetAllSuppliers()
        {
            return this.organizations.All().Where(s => s.IsSupplier == true);
        }

        public IQueryable<Organization> GetSuppliersByCategory(int id)
        {
            return this.organizations.All()
                .Where(s => s.IsSupplier == true && s.Products.Any(p => p.CategoryId == id));
        }

        public IList<string> GetNames(bool isSupplier)
        {
            return this.organizations
                .All()
                .Where(o => o.IsSupplier == isSupplier)
                .Select(o => o.Name)
                .ToList();
        }

        public int CountAllPartners(User user)
        {
            return this.organizations.GetById(user.OrganizationId).Partners.Count();
        }

        public IQueryable<Organization> GetPartners(int id)
        {
            return this.organizations.GetById(id).Partners.AsQueryable();
        }

        public Organization GetById(int id)
        {
            return this.organizations.GetById(id);
        }

        public void SetPartners(int clientId, int id)
        {
            var client = this.organizations.GetById(clientId);
            var supplier = this.organizations.GetById(id);

            if (client.Partners.Contains(supplier))
            {
                return;
            }

            client.Partners.Add(supplier);

            this.organizations.Save();
        }

        public void DeletePartners(int clientId, int id)
        {
            var client = this.organizations.GetById(clientId);
            var supplier = this.organizations.GetById(id);

            if (!client.Partners.Contains(supplier))
            {
                return;
            }

            client.Partners.Remove(supplier);
            supplier.Partners.Remove(client);

            this.organizations.Save();
        }
    }
}
