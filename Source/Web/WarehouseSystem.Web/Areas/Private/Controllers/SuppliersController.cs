using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ninject;
using WarehouseSystem.Services.Data.Contract;
using WarehouseSystem.Web.Areas.Private.ViewModels.Orders;
using WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels;
using WarehouseSystem.Web.Areas.Private.ViewModels.Suppliers;
using WarehouseSystem.Web.Controllers;
using WarehouseSystem.Web.ViewModels.ToastrModels;

namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    [Authorize]
    public class SuppliersController : BaseController
    {
        [Inject]
        public IOrganizationServices Organizations { get; set; }

        [Inject]
        public IProductServices Products { get; set; }

        public ActionResult Index()
        {
            var model = this.Organizations.GetAllSuppliers()
                .Project()
                .To<PartnersViewModel>()
                .ToList();

            this.ViewBag.Title = "All";

            return this.View(model);
        }

        public ActionResult GetById(int id)
        {
            var products = this.Products.GetProductsBySupplier(id)
                .Project()
                .To<ProductViewModel>()
                .ToList();

            var supplier = Mapper.Map<SupplierViewModel>(this.Organizations.GetById(id));

            var model = new DetailsViewModel
            {
                Supplier = supplier,
                Products = products
            };

            return this.View(model);
        }

        public ActionResult GetPartners(int id)
        {
            var model = this.Organizations.GetSuppliersByCategory(id)
                .Project()
                .To<PartnersViewModel>()
                .ToList();

            this.ViewBag.Title = "ByCategory";

            return this.View("Index", model);
        }

        public ActionResult SetPartner(int id)
        {
            var clientId = this.UserProfile.OrganizationId ?? 0;
            var partner = this.Organizations.SetPartners(clientId, id);
            if (partner.Id == clientId)
            {
                this.AddToastMessage("Error", "You was partners", ToastType.Info);
            }
            else
            {
                this.AddToastMessage(partner.Name, "Establishing a domestic partnership", ToastType.Success);
            }

            return this.RedirectToAction("All", "Orders", new { area="Private" });
        }

        public ActionResult DeletePartner(int id)
        {
            var clientId = this.UserProfile.OrganizationId ?? 0;
            this.Organizations.DeletePartners(clientId, id);


            this.AddToastMessage("Seccesfull", "Drop  your partnership!", ToastType.Success);

            return this.RedirectToAction("All", "Orders", new { area="Private" });
        }
    }
}