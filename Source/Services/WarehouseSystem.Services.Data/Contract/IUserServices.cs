namespace WarehouseSystem.Services.Data.Contract
{
    using System.Linq;
    using WarehouseSystem.Data.Models;

    public interface IUserServices
    {
        IQueryable<User> GetAll();

        User GetByName(string name);

        void Update();
    }
}
