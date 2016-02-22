namespace WarehouseSystem.Services.Data.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WarehouseSystem.Data.Models;

    public interface IOrganizationServices
    {
        IQueryable<Organization> GetAll();

        IQueryable<Organization> GetAllSuppliers();

        IQueryable<Organization> GetSuppliersByCategory(int id);

        IList<string> GetNames(bool isSupplier);

        int CountAllPartners(User user);

        IQueryable<Organization> GetPartners(int id);

        Organization GetById(int id);
        
        void SetPartners(int clientId, int id);

        void DeletePartners(int clientId, int id);
    }
}
