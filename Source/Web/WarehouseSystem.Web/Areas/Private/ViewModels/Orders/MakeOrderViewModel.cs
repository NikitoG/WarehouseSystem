using System.Collections.Generic;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Web.Areas.Private.ViewModels.Messages;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Orders
{
    public class MakeOrderViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public int NextDayOfOrder { get; set; }

        public OrganizationViewModel Supplier { get; set; }
    }
}