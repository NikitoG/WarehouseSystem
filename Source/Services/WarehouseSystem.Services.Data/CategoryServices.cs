using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.Data.Common;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Services.Data.Contract;

namespace WarehouseSystem.Services.Data
{
    public class CategoryServices : ICategoryServices
    {
        private IDbRepository<Category> cateories;

        public CategoryServices(IDbRepository<Category> cateories)
        {
            this.cateories = cateories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.cateories.All();
        }
    }
}
