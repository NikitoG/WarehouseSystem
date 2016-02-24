namespace WarehouseSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using WarehouseSystem.Common;
    using WarehouseSystem.Data;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class OrganizationsController : BaseController
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Organizations_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Organization> organizations = db.Organizations;
            DataSourceResult result = organizations.ToDataSourceResult(request, organization => new {
                Id = organization.Id,
                Name = organization.Name,
                MateriallyResponsiblePerson = organization.MateriallyResponsiblePerson,
                LogoUrl = organization.LogoUrl,
                Vat = organization.Vat,
                Address = organization.Address,
                IsSupplier = organization.IsSupplier,
                CreatedOn = organization.CreatedOn,
                ModifiedOn = organization.ModifiedOn,
                IsDeleted = organization.IsDeleted,
                DeletedOn = organization.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Create([DataSourceRequest]DataSourceRequest request, Organization organization)
        {
            if (ModelState.IsValid)
            {
                var entity = new Organization
                {
                    Name = organization.Name,
                    MateriallyResponsiblePerson = organization.MateriallyResponsiblePerson,
                    LogoUrl = organization.LogoUrl,
                    Vat = organization.Vat,
                    Address = organization.Address,
                    IsSupplier = organization.IsSupplier,
                    CreatedOn = organization.CreatedOn,
                    ModifiedOn = organization.ModifiedOn,
                    IsDeleted = organization.IsDeleted,
                    DeletedOn = organization.DeletedOn
                };

                db.Organizations.Add(entity);
                db.SaveChanges();
                organization.Id = entity.Id;
            }

            return Json(new[] { organization }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Update([DataSourceRequest]DataSourceRequest request, Organization organization)
        {
            if (ModelState.IsValid)
            {
                var entity = new Organization
                {
                    Id = organization.Id,
                    Name = organization.Name,
                    MateriallyResponsiblePerson = organization.MateriallyResponsiblePerson,
                    LogoUrl = organization.LogoUrl,
                    Vat = organization.Vat,
                    Address = organization.Address,
                    IsSupplier = organization.IsSupplier,
                    CreatedOn = organization.CreatedOn,
                    ModifiedOn = organization.ModifiedOn,
                    IsDeleted = organization.IsDeleted,
                    DeletedOn = organization.DeletedOn
                };

                db.Organizations.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { organization }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Destroy([DataSourceRequest]DataSourceRequest request, Organization organization)
        {
            if (ModelState.IsValid)
            {
                var entity = new Organization
                {
                    Id = organization.Id,
                    Name = organization.Name,
                    MateriallyResponsiblePerson = organization.MateriallyResponsiblePerson,
                    LogoUrl = organization.LogoUrl,
                    Vat = organization.Vat,
                    Address = organization.Address,
                    IsSupplier = organization.IsSupplier,
                    CreatedOn = organization.CreatedOn,
                    ModifiedOn = organization.ModifiedOn,
                    IsDeleted = organization.IsDeleted,
                    DeletedOn = organization.DeletedOn
                };

                db.Organizations.Attach(entity);
                db.Organizations.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { organization }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
