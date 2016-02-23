namespace WarehouseSystem.Web
{
    using System.Web.Mvc;
    using WarehouseSystem.Web.Filter;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new MessagesActionFilter());
        }
    }
}
