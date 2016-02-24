namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Ninject;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Products;
    using WarehouseSystem.Web.Controllers;

    [Authorize]
    public class ProductsController : BaseController
    {
        [Inject]
        public IProductServices Products { get; set; }

        [Inject]
        public IImageServices Images { get; set; }

        [Inject]
        public ICategoryServices Categories { get; set; }

        public ActionResult Index()
        {
            var model = this.Products.GetProductsBySupplier(this.UserProfile.OrganizationId ?? 0)
                .Project()
                .To<SupplierProductViewModel>()
                .ToList();

            return this.View(model);
        }

        public ActionResult Update(int id)
        {
            this.TempData["Categories"] = this.Cache.Get(
                    "categories",
                    () => this.Categories.GetAll()
                                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                        .ToList(),
                    30 * 60);

            var model = Mapper.Map<SupplierProductViewModel>(this.Products.GetById(id));

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SupplierProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData["Categories"] = this.Cache.Get(
                        "categories",
                        () => this.Categories.GetAll()
                                            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                            .ToList(),
                        30 * 60);

                return this.View(model);
            }

            var product = Mapper.Map<Product>(model);
            if (model.UploadedImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.UploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    var newImage = new Image
                    {
                        Content = content,
                        FileExtension = model.UploadedImage.FileName.Split(new[] { '.' }).Last()
                    };

                    product.Image = newImage;
                }
            }

            this.Products.Update(product);

            return this.RedirectToAction("Index", "Products", new { area = "Private" });
        }

        public ActionResult Create()
        {
            this.TempData["Categories"] = this.Cache.Get(
                    "categories",
                    () => this.Categories.GetAll()
                                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                        .ToList(),
                    30 * 60);

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData["Categories"] = this.Cache.Get(
                        "categories",
                        () => this.Categories.GetAll()
                                            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                            .ToList(),
                        30 * 60);

                return this.View(model);
            }

            var product = Mapper.Map<Product>(model);
            product.SupplierId = this.UserProfile.Organization.Id;

            this.Products.Add(product);

            return this.RedirectToAction("Index", "Products", new { area = "Private" });
        }
    }
}
