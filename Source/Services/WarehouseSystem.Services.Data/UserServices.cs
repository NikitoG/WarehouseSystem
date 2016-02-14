﻿using WarehouseSystem.Data.Common;

namespace WarehouseSystem.Services.Data
{
    using System.Linq;

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
    }
}