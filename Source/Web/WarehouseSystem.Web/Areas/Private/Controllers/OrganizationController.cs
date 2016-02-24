namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Organizations;
    using WarehouseSystem.Web.Controllers;

    [Authorize]
    public class OrganizationController : BaseController
    {
        public ActionResult Index()
        {
            var model = Mapper.Map<IndividualStatisticsViewModel>(this.UserProfile);

            return this.View(model);
        }
    }
}
