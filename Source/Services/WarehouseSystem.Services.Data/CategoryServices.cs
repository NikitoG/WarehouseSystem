namespace WarehouseSystem.Services.Data
{
    using System.Linq;
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

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
