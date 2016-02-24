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
            return View();
        }

        public ActionResult Divisions_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Division> divisions = db.Divisions;
            DataSourceResult result = divisions.ToDataSourceResult(request, division => new {
                Id = division.Id,
                Name = division.Name,
                CreatedOn = division.CreatedOn,
                ModifiedOn = division.ModifiedOn,
                IsDeleted = division.IsDeleted,
                DeletedOn = division.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Divisions_Create([DataSourceRequest]DataSourceRequest request, Division division)
        {
            if (ModelState.IsValid)
            {
                var entity = new Division
                {
                    Name = division.Name,
                    CreatedOn = division.CreatedOn,
                    ModifiedOn = division.ModifiedOn,
                    IsDeleted = division.IsDeleted,
                    DeletedOn = division.DeletedOn
                };

                db.Divisions.Add(entity);
                db.SaveChanges();
                division.Id = entity.Id;
            }

            return Json(new[] { division }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Divisions_Update([DataSourceRequest]DataSourceRequest request, Division division)
        {
            if (ModelState.IsValid)
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

                db.Divisions.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { division }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Divisions_Destroy([DataSourceRequest]DataSourceRequest request, Division division)
        {
            if (ModelState.IsValid)
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

                db.Divisions.Attach(entity);
                db.Divisions.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { division }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
