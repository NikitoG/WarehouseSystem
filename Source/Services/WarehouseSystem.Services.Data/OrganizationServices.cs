using System.Linq;
using AutoMapper.QueryableExtensions;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Data.Repositories;

namespace WarehouseSystem.Services.Data
{
    using WarehouseSystem.Services.Data.Contract;

    public class OrganizationServices : IOrganizationServices
    {
        private IRepository<Organization> organizations;

        public OrganizationServices(IRepository<Organization> organizations)
        {
            this.organizations = organizations;
        }

        public IQueryable<Organization> GetAll()
        {
            return this.organizations.All();
        }
    }
}
