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
    public class DivisionsController : BaseController
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Divisions_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Division> divisions = this.db.Divisions;
            DataSourceResult result = divisions.ToDataSourceResult(request, division => new
            {
                Id = division.Id,
                Name = division.Name,
                CreatedOn = division.CreatedOn,
                ModifiedOn = division.ModifiedOn,
                IsDeleted = division.IsDeleted,
                DeletedOn = division.DeletedOn
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Divisions_Create([DataSourceRequest]DataSourceRequest request, Division division)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Division
                {
                    Name = division.Name,
                    CreatedOn = division.CreatedOn,
                    ModifiedOn = division.ModifiedOn,
                    IsDeleted = division.IsDeleted,
                    DeletedOn = division.DeletedOn
                };

                this.db.Divisions.Add(entity);
                this.db.SaveChanges();
                division.Id = entity.Id;
            }

            return this.Json(new[] { division }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Divisions_Update([DataSourceRequest]DataSourceRequest request, Division division)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Division
                {
                    Id = division.Id,
                    Name = division.Name,
                    CreatedOn = division.CreatedOn,
                    ModifiedOn = division.ModifiedOn,
                    IsDeleted = division.IsDeleted,
                    DeletedOn = division.DeletedOn
                };

                this.db.Divisions.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { division }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Divisions_Destroy([DataSourceRequest]DataSourceRequest request, Division division)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Division
                {
                    Id = division.Id,
                    Name = division.Name,
                    CreatedOn = division.CreatedOn,
                    ModifiedOn = division.ModifiedOn,
                    IsDeleted = division.IsDeleted,
                    DeletedOn = division.DeletedOn
                };

                this.db.Divisions.Attach(entity);
                this.db.Divisions.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { division }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
