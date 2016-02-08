namespace WarehouseSystem.Services.Data
{
    using System.Linq;

    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Data.Repositories;
    using WarehouseSystem.Services.Data.Contract;

    public class UserServices : IUserServices
    {
        private IRepository<User> users;

        public UserServices(IRepository<User> users)
        {
            this.users = users;
        } 

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }
    }
}
