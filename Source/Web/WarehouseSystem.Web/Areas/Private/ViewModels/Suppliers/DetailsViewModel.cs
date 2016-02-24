namespace WarehouseSystem.Web.Areas.Private.ViewModels.Suppliers
{
    using System.Collections.Generic;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Orders;

    public class DetailsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public SupplierViewModel Supplier { get; set; }
    }
}
