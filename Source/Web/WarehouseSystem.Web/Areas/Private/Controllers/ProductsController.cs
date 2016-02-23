using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ninject;
using WarehouseSystem.Services.Data.Contract;
using WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels;
using WarehouseSystem.Web.Areas.Private.ViewModels.Products;
using WarehouseSystem.Web.Controllers;

namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using WarehouseSystem.Data;
    using WarehouseSystem.Data.Models;

    public class ProductsController : BaseController
    {
        [Inject]
        public IProductServices Products { get; set; }

        [Inject]
        public ICategoryServices Categories { get; set; }

        public ActionResult Index()
        {
            this.PopulateCategories();

            return this.View();
        }

        public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.Products.GetProductsBySupplier(this.UserProfile.OrganizationId ?? 0)
                .Project()
                .To<SupplierProductViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, SupplierProductViewModel product)
        {
            if (this.ModelState.IsValid)
            {
                var entity = Mapper.Map<Product>(product);

                this.Products.Add(entity);
                product.Id = entity.Id;
            }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, SupplierProductViewModel product)
        {
            if (this.ModelState.IsValid)
            {
                var entity = Mapper.Map<Product>(product);
                this.Products.Update(entity);
            }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, SupplierProductViewModel product)
        {
            if (this.ModelState.IsValid)
            {
                var entity = Mapper.Map<Product>(product);
                this.Products.Delete(entity);
            }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        private void PopulateCategories()
        {
            var categories = this.Categories.GetAll()
                        .Select(c => new CategoryViewModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                        .OrderBy(e => e.Name);

            ViewData["categories"] = categories;
            ViewData["defaultCategory"] = categories.First();
        }
    }
}
