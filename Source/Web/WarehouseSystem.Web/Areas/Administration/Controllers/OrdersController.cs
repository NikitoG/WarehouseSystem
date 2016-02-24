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
    public class OrdersController : BaseController
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScheduleOrders_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ScheduleOrder> scheduleorders = db.ScheduleOrders;
            DataSourceResult result = scheduleorders.ToDataSourceResult(request, scheduleOrder => new {
                Id = scheduleOrder.Id,
                OrderDay = scheduleOrder.OrderDay,
                DelivaryDay = scheduleOrder.DelivaryDay,
                CreatedOn = scheduleOrder.CreatedOn,
                ModifiedOn = scheduleOrder.ModifiedOn,
                IsDeleted = scheduleOrder.IsDeleted,
                DeletedOn = scheduleOrder.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ScheduleOrders_Create([DataSourceRequest]DataSourceRequest request, ScheduleOrder scheduleOrder)
        {
            if (ModelState.IsValid)
            {
                var entity = new ScheduleOrder
                {
                    OrderDay = scheduleOrder.OrderDay,
                    DelivaryDay = scheduleOrder.DelivaryDay,
                    CreatedOn = scheduleOrder.CreatedOn,
                    ModifiedOn = scheduleOrder.ModifiedOn,
                    IsDeleted = scheduleOrder.IsDeleted,
                    DeletedOn = scheduleOrder.DeletedOn
                };

                db.ScheduleOrders.Add(entity);
                db.SaveChanges();
                scheduleOrder.Id = entity.Id;
            }

            return Json(new[] { scheduleOrder }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ScheduleOrders_Update([DataSourceRequest]DataSourceRequest request, ScheduleOrder scheduleOrder)
        {
            if (ModelState.IsValid)
            {
                var entity = new ScheduleOrder
                {
                    Id = scheduleOrder.Id,
                    OrderDay = scheduleOrder.OrderDay,
                    DelivaryDay = scheduleOrder.DelivaryDay,
                    CreatedOn = scheduleOrder.CreatedOn,
                    ModifiedOn = scheduleOrder.ModifiedOn,
                    IsDeleted = scheduleOrder.IsDeleted,
                    DeletedOn = scheduleOrder.DeletedOn
                };

                db.ScheduleOrders.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { scheduleOrder }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ScheduleOrders_Destroy([DataSourceRequest]DataSourceRequest request, ScheduleOrder scheduleOrder)
        {
            if (ModelState.IsValid)
            {
                var entity = new ScheduleOrder
                {
                    Id = scheduleOrder.Id,
                    OrderDay = scheduleOrder.OrderDay,
                    DelivaryDay = scheduleOrder.DelivaryDay,
                    CreatedOn = scheduleOrder.CreatedOn,
                    ModifiedOn = scheduleOrder.ModifiedOn,
                    IsDeleted = scheduleOrder.IsDeleted,
                    DeletedOn = scheduleOrder.DeletedOn
                };

                db.ScheduleOrders.Attach(entity);
                db.ScheduleOrders.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { scheduleOrder }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
