namespace WarehouseSystem.Services.Data.Contract
{
    using System.Collections.Generic;
    using System.Linq;
    using WarehouseSystem.Data.Models;

    public interface IProductServices
    {
        IList<string> GetNames();

        int CountProductsByUser(User user);

        IQueryable<Product> GetProductsBySupplier(int id);

        Product Add(Product product);

        Product GetById(int id);

        Product Update(Product product);

        void Delete(Product product);

        IQueryable<Product> All();
    }
}
