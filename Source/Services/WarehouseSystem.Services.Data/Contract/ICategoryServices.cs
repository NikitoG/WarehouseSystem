namespace WarehouseSystem.Services.Data.Contract
{
    using System.Linq;
    using WarehouseSystem.Data.Models;

    public interface ICategoryServices
    {
        IQueryable<Category> GetAll();
    }
}
