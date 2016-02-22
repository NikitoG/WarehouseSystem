namespace WarehouseSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using AutoMapper.QueryableExtensions;
    using Ninject;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        [Inject]
        public IOrganizationServices Organization { get; set; }

        [Inject]
        public IPublicMessageServices PublicMessage { get; set; }

        //TODO: remove comment
        //[OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            var allOrganizations = this.Organization
                .GetAll()
                .Project()
                .To<StatisticsViewModel>()
                .ToList();

            var viewModel = new IndexViewModel
            {
                Customers = allOrganizations.Count(o => o.IsSupplier == false),
                Suppliers = allOrganizations.Count(o => o.IsSupplier == true),
                Products = allOrganizations.Where(o => o.IsSupplier == true).Sum(o => o.Products)
            };

            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult Send()
        {
            return this.PartialView("_ContactUsPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(SendMassageViewModel message)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView("_ContactUsPartial", message);
            }

            var newMessage = Mapper.Map<PublicMessage>(message);
            newMessage.CreatedOn = DateTime.Now;
            this.PublicMessage.Add(newMessage);
            this.TempData["success"] = "Successfull";
            return this.PartialView("_ContactUsPartial", new SendMassageViewModel());
        }
    }
}