namespace WarehouseSystem.Services.Data.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WarehouseSystem.Data.Models;

    public interface IOrganizationServices
    {
        IQueryable<Organization> GetAll();

        IList<string> GetNames(bool isSupplier);
    }
}
