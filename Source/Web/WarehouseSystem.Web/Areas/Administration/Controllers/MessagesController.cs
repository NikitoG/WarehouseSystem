namespace WarehouseSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using WarehouseSystem.Data;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Controllers;

    public class MessagesController : BaseController
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Messages_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Message> messages = this.db.Messages;
            DataSourceResult result = messages.ToDataSourceResult(request, message => new
            {
                Id = message.Id,
                Title = message.Title,
                Content = message.Content,
                IsRead = message.IsRead,
                CreatedOn = message.CreatedOn,
                ModifiedOn = message.ModifiedOn,
                IsDeleted = message.IsDeleted,
                DeletedOn = message.DeletedOn
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Messages_Create([DataSourceRequest]DataSourceRequest request, Message message)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Message
                {
                    Title = message.Title,
                    Content = message.Content,
                    IsRead = message.IsRead,
                    CreatedOn = message.CreatedOn,
                    ModifiedOn = message.ModifiedOn,
                    IsDeleted = message.IsDeleted,
                    DeletedOn = message.DeletedOn
                };

                this.db.Messages.Add(entity);
                this.db.SaveChanges();
                message.Id = entity.Id;
            }

            return this.Json(new[] { message }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Messages_Update([DataSourceRequest]DataSourceRequest request, Message message)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Message
                {
                    Id = message.Id,
                    Title = message.Title,
                    Content = message.Content,
                    IsRead = message.IsRead,
                    CreatedOn = message.CreatedOn,
                    ModifiedOn = message.ModifiedOn,
                    IsDeleted = message.IsDeleted,
                    DeletedOn = message.DeletedOn
                };

                this.db.Messages.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { message }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Messages_Destroy([DataSourceRequest]DataSourceRequest request, Message message)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Message
                {
                    Id = message.Id,
                    Title = message.Title,
                    Content = message.Content,
                    IsRead = message.IsRead,
                    CreatedOn = message.CreatedOn,
                    ModifiedOn = message.ModifiedOn,
                    IsDeleted = message.IsDeleted,
                    DeletedOn = message.DeletedOn
                };

                this.db.Messages.Attach(entity);
                this.db.Messages.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { message }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
