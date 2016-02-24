namespace WarehouseSystem.Services.Data
{
    using System.Linq;
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

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

        public IQueryable<PurchaseOrder> GetNewPurchaseOrder(int id)
        {
            return this.orders.All().Where(p => p.SupplierId == id && !p.isDone);
        }

        public void MarkAsRead(int id)
        {
            var order = this.orders.GetById(id);
            order.isDone = true;

            this.orders.Save();
        }

        public IQueryable<PurchaseOrder> AllByUser(int id)
        {
            return this.orders.All().Where(o => o.SupplierId == id);
        }
    }
}
