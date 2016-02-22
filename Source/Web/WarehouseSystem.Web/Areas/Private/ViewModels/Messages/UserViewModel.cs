using System.Web.Mvc;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Web.Infrastructure.Mapping;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Messages
{
    public class UserViewModel : SelectListItem, IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}