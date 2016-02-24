namespace WarehouseSystem.Services.Data.Contract
{
    using WarehouseSystem.Data.Models;

    public interface IImageServices
    {
        Image GetById(int id);

        Image Add(Image image);
    }
}
