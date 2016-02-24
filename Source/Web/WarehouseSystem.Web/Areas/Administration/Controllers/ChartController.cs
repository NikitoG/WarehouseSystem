namespace WarehouseSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using WarehouseSystem.Common;
    using WarehouseSystem.Data;
    using WarehouseSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class ChartController : BaseController
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Products_Read()
        {
            return this.Json(this.db.Products.Select(product => new
            {
                Name = product.Name,
                Sku = product.Sku,
                Barcode = product.Barcode,
                HeigthInCm = product.HeigthInCm,
                WidthInCm = product.WidthInCm,
                WeightInGr = product.WeightInGr,
                DeliveryUnit = product.DeliveryUnit,
                Stock = product.Stock,
                MinDayOfExpiryInDays = product.MinDayOfExpiryInDays,
                IsBlocked = product.IsBlocked,
                CreatedOn = product.CreatedOn,
                ModifiedOn = product.ModifiedOn,
                IsDeleted = product.IsDeleted,
                DeletedOn = product.DeletedOn
            }));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
