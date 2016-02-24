namespace WarehouseSystem.Web.Areas.Private
{
    using System.Web.Mvc;

    public class UserAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Private";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Message",
                url: "message/{id}",
                defaults: new { controller = "Messages", action = "ById", Area = "Private" });

            context.MapRoute(
                name: "Order",
                url: "orders/{id}",
                defaults: new { controller = "Orders", action = "ByPartner", Area = "Private" });

            context.MapRoute(
                name: "Supplier",
                url: "suppliers/{id}",
                defaults: new { controller = "Suppliers", action = "GetById", Area = "Private" });

            context.MapRoute(
                name: "Category",
                url: "byCategories/{id}",
                defaults: new { controller = "Suppliers", action = "GetPartners", Area = "Private" });

            context.MapRoute(
                name: "Product",
                url: "product/{id}",
                defaults: new { controller = "Products", action = "Update", Area = "Private" });

            context.MapRoute(
                "Private_default",
                "Private/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
