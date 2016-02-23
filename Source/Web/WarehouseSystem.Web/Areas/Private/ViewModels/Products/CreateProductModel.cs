using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Products
{
    public class CreateProductModel
    {
        public SupplierProductViewModel Product { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}