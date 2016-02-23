using System.Linq;

namespace WarehouseSystem.Services.Data.Contract
{
    using WarehouseSystem.Data.Models;

    public interface IPurchaseOrderService
    {
        int CountPurchaseByClient(User user);

        PurchaseOrder Add(PurchaseOrder order);

        IQueryable<PurchaseOrder> GetNewPurchaseOrder(int id);

        void MarkAsRead(int id);

        IQueryable<PurchaseOrder> AllByUser(int i);
    }
}
