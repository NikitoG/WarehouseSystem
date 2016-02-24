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
    public class UsersController : BaseController
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<User> users = this.db.Users;
            DataSourceResult result = users.ToDataSourceResult(request, user => new
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Position = user.Position,
                CreatedOn = user.CreatedOn,
                ModifiedOn = user.ModifiedOn,
                IsDeleted = user.IsDeleted,
                DeletedOn = user.DeletedOn,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                UserName = user.UserName
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Position = user.Position,
                    CreatedOn = user.CreatedOn,
                    ModifiedOn = user.ModifiedOn,
                    IsDeleted = user.IsDeleted,
                    DeletedOn = user.DeletedOn,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PasswordHash = user.PasswordHash,
                    SecurityStamp = user.SecurityStamp,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    LockoutEndDateUtc = user.LockoutEndDateUtc,
                    LockoutEnabled = user.LockoutEnabled,
                    AccessFailedCount = user.AccessFailedCount,
                    UserName = user.UserName
                };

                this.db.Users.Add(entity);
                this.db.SaveChanges();
                user.Id = entity.Id;
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Position = user.Position,
                    CreatedOn = user.CreatedOn,
                    ModifiedOn = user.ModifiedOn,
                    IsDeleted = user.IsDeleted,
                    DeletedOn = user.DeletedOn,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PasswordHash = user.PasswordHash,
                    SecurityStamp = user.SecurityStamp,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    LockoutEndDateUtc = user.LockoutEndDateUtc,
                    LockoutEnabled = user.LockoutEnabled,
                    AccessFailedCount = user.AccessFailedCount,
                    UserName = user.UserName
                };

                this.db.Users.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Position = user.Position,
                    CreatedOn = user.CreatedOn,
                    ModifiedOn = user.ModifiedOn,
                    IsDeleted = user.IsDeleted,
                    DeletedOn = user.DeletedOn,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PasswordHash = user.PasswordHash,
                    SecurityStamp = user.SecurityStamp,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    LockoutEndDateUtc = user.LockoutEndDateUtc,
                    LockoutEnabled = user.LockoutEnabled,
                    AccessFailedCount = user.AccessFailedCount,
                    UserName = user.UserName
                };

                this.db.Users.Attach(entity);
                this.db.Users.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
