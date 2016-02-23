using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Ninject;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Services.Data.Contract;
using WarehouseSystem.Web.Areas.Private.ViewModels.Messages;
using WarehouseSystem.Web.Areas.Private.ViewModels.Orders;
using WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels;
using WarehouseSystem.Web.Controllers;
using WarehouseSystem.Web.ViewModels.ToastrModels;

namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        [Inject]
        public IOrganizationServices Organizations { get; set; }

        [Inject]
        public IScheduleOrderServices ScheduleOrders { get; set; }

        [Inject]
        public IProductServices Products { get; set; }

        [Inject]
        public IPurchaseOrderService PurchaseOrders { get; set; }

        [Inject]
        public IOrderQuantitiesServices OrderQuantities { get; set; }

        public ActionResult All()
        {
            var id = this.UserProfile.OrganizationId;
            var model = this.Organizations.GetPartners(id ?? 0)
                .Project()
                .To<PartnersViewModel>()
                .ToList();

            return View(model);
        }

        public ActionResult ByPartner(int id)
        {
            var clientId = this.UserProfile.OrganizationId ?? 0;
            var nextDayOfOrder = this.ScheduleOrders.GetNextDayOfOrder(clientId, id);
            var products = this.Products.GetProductsBySupplier(id)
                .Project()
                .To<ProductViewModel>()
                .ToList();
            var supplier = Mapper.Map<OrganizationViewModel>(this.Organizations.GetById(id));

            var model = new MakeOrderViewModel
            {
                NextDayOfOrder = nextDayOfOrder,
                Products = products,
                Supplier = supplier
            };

            return this.View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
        {
            if (products != null && this.ModelState.IsValid)
            {
                var purchaseOrder = new PurchaseOrder()
                {
                    DateOfOrder = DateTime.Now,
                    DateOfDelivery = DateTime.Now.AddDays(2),
                    ClientId = this.UserProfile.OrganizationId ?? 0,
                    SupplierId = products.FirstOrDefault().SupplierId,
                    CreatorId = this.UserProfile.Id
                };

                this.PurchaseOrders.Add(purchaseOrder);

                var order = products.Select(product => new OrderQuantity()
                {
                    ProductId = product.Id, PurchaseOrderId = purchaseOrder.Id, Quantity = product.Quantities
                }).ToList();

                this.OrderQuantities.Add(order);

                this.AddToastMessage("Succefull", "You made order !", ToastType.Success);

                return this.Redirect("/Private/Orders/All");
            }

            this.AddToastMessage("Error!", string.Empty, ToastType.Error);
            return this.Json(products.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Details(int id)
        {
            var model = this.OrderQuantities.GetByOrderId(id)
                .Project()
                .To<QuantitiesViewModel>()
                .ToList();

            return this.PartialView("_OrderDetailsPartial", model);
        }

        public ActionResult New()
        {
            var model = this.PurchaseOrders.GetNewPurchaseOrder(this.UserProfile.OrganizationId ?? 0)
                .Project()
                .To<PurchaseOrderViewModel>()
                .ToList();

            return this.View(model);
        }

        public ActionResult Supplier()
        {
            var model = this.PurchaseOrders.AllByUser(this.UserProfile.OrganizationId ?? 0)
                .Project()
                .To<PurchaseOrderViewModel>()
                .ToList();

            return this.View("New", model);
        }

        public ActionResult Done(int id)
        {
            this.PurchaseOrders.MarkAsRead(id);

            return this.RedirectToAction("New");
        }
    }
}