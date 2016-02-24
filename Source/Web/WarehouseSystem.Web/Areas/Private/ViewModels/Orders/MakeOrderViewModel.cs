namespace WarehouseSystem.Web.Areas.Private.ViewModels.Orders
{
    using System.Collections.Generic;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Messages;

    public class MakeOrderViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public int NextDayOfOrder { get; set; }

        public OrganizationViewModel Supplier { get; set; }
    }
}
