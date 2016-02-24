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
            return this.View();
        }

        public ActionResult Organizations_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Organization> organizations = this.db.Organizations;
            DataSourceResult result = organizations.ToDataSourceResult(request, organization => new
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
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Create([DataSourceRequest]DataSourceRequest request, Organization organization)
        {
            if (this.ModelState.IsValid)
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

                this.db.Organizations.Add(entity);
                this.db.SaveChanges();
                organization.Id = entity.Id;
            }

            return this.Json(new[] { organization }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Update([DataSourceRequest]DataSourceRequest request, Organization organization)
        {
            if (this.ModelState.IsValid)
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

                this.db.Organizations.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { organization }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Organizations_Destroy([DataSourceRequest]DataSourceRequest request, Organization organization)
        {
            if (this.ModelState.IsValid)
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

                this.db.Organizations.Attach(entity);
                this.db.Organizations.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { organization }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
