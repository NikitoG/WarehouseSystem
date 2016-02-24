namespace WarehouseSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Ninject;
    using WarehouseSystem.Common;
    using WarehouseSystem.Data;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.Areas.Administration.ViewModels;
    using WarehouseSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class ProductsController : BaseController
    {
        [Inject]
        public IProductServices Products { get; set; }

        [Inject]
        public ICategoryServices Categories { get; set; }

        public ActionResult Index()
        {
            this.TempData["Categories"] = this.Cache.Get(
                    "categories",
                    () => this.Categories.GetAll()
                                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                        .ToList(),
                    30 * 60);

            return View();
        }

        public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            this.TempData["Categories"] = this.Cache.Get(
                    "categories",
                    () => this.Categories.GetAll()
                                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                        .ToList(),
                    30 * 60);

            DataSourceResult result = this.Products.All()
                .Project()
                .To<ProductViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, ProductViewModel product)
        {
            this.TempData["Categories"] = this.Cache.Get(
                    "categories",
                    () => this.Categories.GetAll()
                                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                        .ToList(),
                    30 * 60);

            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Product
                {
                    Name = product.Name,
                    Sku = product.Sku,
                    Barcode = product.Barcode,
                    HeigthInCm = product.HeigthInCm,
                    WidthInCm = product.WidthInCm,
                    WeightInGr = product.WeightInGr,
                    DeliveryUnit = product.DeliveryUnit,
                    MinDayOfExpiryInDays = product.MinDayOfExpiryInDays,
                    IsBlocked = product.IsBlocked,
                    SupplierId = this.UserProfile.Organization.Id
                };

                this.Products.Add(entity);
                product.Id = entity.Id;
            }

            var productsToDisplay = this.Products.All()
                .Project()
                .To<ProductViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { productsToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, ProductViewModel product)
        {
            this.TempData["Categories"] = this.Cache.Get(
                    "categories",
                    () => this.Categories.GetAll()
                                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                        .ToList(),
                    30 * 60);

            if (this.ModelState.IsValid)
            {
                this.Products.Update(Mapper.Map<Product>(product));
            }

            var postToDisplay = this.Products.All().Project()
                           .To<ProductViewModel>()
                           .FirstOrDefault(x => x.Id == product.Id);
            return this.Json(new[] { postToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, ProductViewModel product)
        {
            this.Products.Delete(Mapper.Map<Product>(product));

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}
