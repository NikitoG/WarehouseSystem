namespace WarehouseSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Ninject;

    using WarehouseSystem.Services.Data.Contract;

    public class StatisticsController : BaseController
    {
        [Inject]
        public IOrganizationServices Organizations { get; set; }

        [Inject]
        public IProductServices Products { get; set; }

        // [OutputCache(Duration = 60 * 60)]
        public ActionResult AllSuppliers()
        {
            var suppliers = this.Organizations.GetNames(true);
            return this.PartialView("_AllSuppliersPartial", suppliers);
        }

        // [OutputCache(Duration = 60 * 60)]
        public ActionResult AllCustomers()
        {
            var customers = this.Organizations.GetNames(false);
            return this.PartialView("_AllCustomersPartial", customers);
        }

        // [OutputCache(Duration = 60 * 60)]
        public ActionResult AllProducts()
        {
            var products = this.Products.GetNames();
            return this.PartialView("_AllProductsPartial", products);
        }
    }
}
