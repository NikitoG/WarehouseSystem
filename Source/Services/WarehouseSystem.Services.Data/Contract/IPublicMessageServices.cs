namespace WarehouseSystem.Services.Data.Contract
{
    using WarehouseSystem.Data.Models;

    public interface IPublicMessageServices
    {
        PublicMessage Add(PublicMessage message);
    }
}
