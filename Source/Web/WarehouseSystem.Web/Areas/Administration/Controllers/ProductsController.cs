﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
﻿using WarehouseSystem.Common;
﻿using WarehouseSystem.Data;
﻿using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Web.Areas.Administration.Controllers
{

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class ProductsController : Controller
    {
        private WarehouseSystemDbContext db = new WarehouseSystemDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Product> products = db.Products;
            DataSourceResult result = products.ToDataSourceResult(request, product => new {
                Id = product.Id,
                Name = product.Name,
                Sku = product.Sku,
                Barcode = product.Barcode,
                HeigthInCm = product.HeigthInCm,
                WidthInCm = product.WidthInCm,
                WeightInGr = product.WeightInGr,
                DeliveryUnit = product.DeliveryUnit,
                Stock = product.Stock,
                MinDayOfExpiryInDays = product.MinDayOfExpiryInDays,
                IsBlocked = product.IsBlocked,
                CreatedOn = product.CreatedOn,
                ModifiedOn = product.ModifiedOn,
                IsDeleted = product.IsDeleted,
                DeletedOn = product.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, Product product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Name = product.Name,
                    Sku = product.Sku,
                    Barcode = product.Barcode,
                    HeigthInCm = product.HeigthInCm,
                    WidthInCm = product.WidthInCm,
                    WeightInGr = product.WeightInGr,
                    DeliveryUnit = product.DeliveryUnit,
                    Stock = product.Stock,
                    MinDayOfExpiryInDays = product.MinDayOfExpiryInDays,
                    IsBlocked = product.IsBlocked,
                    CreatedOn = product.CreatedOn,
                    ModifiedOn = product.ModifiedOn,
                    IsDeleted = product.IsDeleted,
                    DeletedOn = product.DeletedOn
                };

                db.Products.Add(entity);
                db.SaveChanges();
                product.Id = entity.Id;
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, Product product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Sku = product.Sku,
                    Barcode = product.Barcode,
                    HeigthInCm = product.HeigthInCm,
                    WidthInCm = product.WidthInCm,
                    WeightInGr = product.WeightInGr,
                    DeliveryUnit = product.DeliveryUnit,
                    Stock = product.Stock,
                    MinDayOfExpiryInDays = product.MinDayOfExpiryInDays,
                    IsBlocked = product.IsBlocked,
                    CreatedOn = product.CreatedOn,
                    ModifiedOn = product.ModifiedOn,
                    IsDeleted = product.IsDeleted,
                    DeletedOn = product.DeletedOn
                };

                db.Products.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, Product product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Sku = product.Sku,
                    Barcode = product.Barcode,
                    HeigthInCm = product.HeigthInCm,
                    WidthInCm = product.WidthInCm,
                    WeightInGr = product.WeightInGr,
                    DeliveryUnit = product.DeliveryUnit,
                    Stock = product.Stock,
                    MinDayOfExpiryInDays = product.MinDayOfExpiryInDays,
                    IsBlocked = product.IsBlocked,
                    CreatedOn = product.CreatedOn,
                    ModifiedOn = product.ModifiedOn,
                    IsDeleted = product.IsDeleted,
                    DeletedOn = product.DeletedOn
                };

                db.Products.Attach(entity);
                db.Products.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
