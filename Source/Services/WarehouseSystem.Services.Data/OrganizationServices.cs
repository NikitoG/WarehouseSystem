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

        public IList<string> GetNames(bool isSupplier)
        {
            return this.organizations
                .All()
                .Where(o => o.IsSupplier == isSupplier)
                .Select(o => o.Name)
                .ToList();
        }
    }
}
