using System.Collections.Generic;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels
{
    public class SideMenuViewModel
    {
        public UserViewModel UserViewModel { get; set; }

        public IEnumerable<PartnersViewModel> Partners { get; set; } 

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}