using System.Linq;
using WarehouseSystem.Data.Common;

namespace WarehouseSystem.Services.Data
{
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Data.Models;

    public class PurchaseOrderService : IPurchaseOrderService
    {
        private IDbRepository<PurchaseOrder> orders;

        public PurchaseOrderService(IDbRepository<PurchaseOrder> orders)
        {
            this.orders = orders;
        }

        public int CountPurchaseByClient(User user)
        {
            if (user.Organization.IsSupplier)
            {
                return this.orders.All().Count(o => o.SupplierId == user.OrganizationId);
            }
            else
            {
                return this.orders.All().Count(o => o.ClientId == user.OrganizationId);
            }
        }

        public PurchaseOrder Add(PurchaseOrder order)
        {
            this.orders.Add(order);
            this.orders.Save();

            return order;
        }
    }
}
