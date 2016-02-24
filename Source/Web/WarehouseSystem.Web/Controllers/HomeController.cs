namespace WarehouseSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Ninject;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.ViewModels.Home;
    using WarehouseSystem.Web.ViewModels.ToastrModels;

    public class HomeController : BaseController
    {
        [Inject]
        public IOrganizationServices Organization { get; set; }

        [Inject]
        public IPublicMessageServices PublicMessage { get; set; }

        public ActionResult Index()
        {
            var allOrganizations = this.Cache.Get(
                    "homeStatistics",
                    () => this.Organization.GetAll()
                                            .Project()
                                            .To<StatisticsViewModel>()
                                            .ToList(),
                    30 * 60);

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
            this.AddToastMessage("Succefull", "We will answer you as soon as possible!", ToastType.Success);
            return this.RedirectToAction("Index");
        }
    }
}