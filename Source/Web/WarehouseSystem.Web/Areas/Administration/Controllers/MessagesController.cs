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
            return View();
        }

        public ActionResult Messages_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Message> messages = db.Messages;
            DataSourceResult result = messages.ToDataSourceResult(request, message => new {
                Id = message.Id,
                Title = message.Title,
                Content = message.Content,
                IsRead = message.IsRead,
                CreatedOn = message.CreatedOn,
                ModifiedOn = message.ModifiedOn,
                IsDeleted = message.IsDeleted,
                DeletedOn = message.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Messages_Create([DataSourceRequest]DataSourceRequest request, Message message)
        {
            if (ModelState.IsValid)
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

                db.Messages.Add(entity);
                db.SaveChanges();
                message.Id = entity.Id;
            }

            return Json(new[] { message }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Messages_Update([DataSourceRequest]DataSourceRequest request, Message message)
        {
            if (ModelState.IsValid)
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

                db.Messages.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { message }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Messages_Destroy([DataSourceRequest]DataSourceRequest request, Message message)
        {
            if (ModelState.IsValid)
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

                db.Messages.Attach(entity);
                db.Messages.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { message }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
