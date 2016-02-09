using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Ninject;
using WarehouseSystem.Services.Data.Contract;
using WarehouseSystem.Web.ViewModels.Home;
using WebGrease.Css.Extensions;

namespace WarehouseSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IOrganizationServices OrganizationServices { get; set; }

        public ActionResult Index()
        {
            var allOrganizations = OrganizationServices
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