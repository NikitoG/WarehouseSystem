namespace WarehouseSystem.Services.Data
{
    using System.Linq;
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

    public class UserServices : IUserServices
    {
        private IDbRepository<User> users;

        public UserServices(IDbRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetByName(string name)
        {
            return this.users.All().FirstOrDefault(u => u.UserName == name);
        }

        public void Update()
        {
            this.users.Save();
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
