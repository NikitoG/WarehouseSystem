namespace WarehouseSystem.Services.Data.Contract
{
    using WarehouseSystem.Data.Models;

    public interface IPurchaseOrderService
    {
        int CountPurchaseByClient(User user);

        PurchaseOrder Add(PurchaseOrder order);
    }
}
