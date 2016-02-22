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

namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    public class OrdersController : BaseController
    {
        [Inject]
        public IOrganizationServices Organizations { get; set; }

        [Inject]
        public IScheduleOrderServices ScheduleOrders { get; set; }

        [Inject]
        public IProductServices Products { get; set; }

        [Inject]
        public IPurchaseOrderService PurchaseOrder { get; set; }

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
            if (products != null && ModelState.IsValid)
            {
                var purchaseOrder = new PurchaseOrder()
                {
                    DateOfOrder = DateTime.Now,
                    DateOfDelivery = DateTime.Now.AddDays(2),
                    ClientId = this.UserProfile.OrganizationId ?? 0,
                    SupplierId = products.FirstOrDefault().SupplierId,
                    CreatorId = this.UserProfile.Id
                };

                this.PurchaseOrder.Add(purchaseOrder);

                var order = products.Select(product => new OrderQuantity()
                {
                    ProductId = product.Id, PurchaseOrderId = purchaseOrder.Id, Quantity = product.Quantities
                }).ToList();

                this.OrderQuantities.Add(order);

                return this.RedirectToAction("All");
            }

            return this.Json(products.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult New()
        {
            throw new NotImplementedException();
        }

        public ActionResult Supplier()
        {
            throw new NotImplementedException();
        }
    }
}