using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using WarehouseSystem.Services.Data.Contract;

namespace WarehouseSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IUserServices UserServices { get; set; }

        public ActionResult Index()
        {
            var result = UserServices.GetAll();
            return View(result.Count());
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