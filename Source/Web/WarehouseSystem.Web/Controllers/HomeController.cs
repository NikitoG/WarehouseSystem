namespace WarehouseSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Ninject;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        [Inject]
        public IOrganizationServices Organization { get; set; }

        //TODO: remove comment
        //[OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            var allOrganizations = this.Organization
                .GetAll()
                .Project()
                .To<StatisticsViewModel>()
                .ToList();
             
            return View(allOrganizations);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}