namespace WarehouseSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using WarehouseSystem.Common;
    using WarehouseSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdminController : BaseController
    {
        // GET: Administration/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}