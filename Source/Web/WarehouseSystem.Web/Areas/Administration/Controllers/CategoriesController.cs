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
    public class CategoriesController : BaseController
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Category> categories = this.db.Categories;
            DataSourceResult result = categories.ToDataSourceResult(request, category => new
            {
                Id = category.Id,
                Name = category.Name,
                CreatedOn = category.CreatedOn,
                ModifiedOn = category.ModifiedOn,
                IsDeleted = category.IsDeleted,
                DeletedOn = category.DeletedOn
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, Category category)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = category.Name,
                    CreatedOn = category.CreatedOn,
                    ModifiedOn = category.ModifiedOn,
                    IsDeleted = category.IsDeleted,
                    DeletedOn = category.DeletedOn
                };

                this.db.Categories.Add(entity);
                this.db.SaveChanges();
                category.Id = entity.Id;
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, Category category)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    CreatedOn = category.CreatedOn,
                    ModifiedOn = category.ModifiedOn,
                    IsDeleted = category.IsDeleted,
                    DeletedOn = category.DeletedOn
                };

                this.db.Categories.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Destroy([DataSourceRequest]DataSourceRequest request, Category category)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    CreatedOn = category.CreatedOn,
                    ModifiedOn = category.ModifiedOn,
                    IsDeleted = category.IsDeleted,
                    DeletedOn = category.DeletedOn
                };

                this.db.Categories.Attach(entity);
                this.db.Categories.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
