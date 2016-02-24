namespace WarehouseSystem.Web.Filter
{
    using System.Linq;
    using System.Web.Mvc;
    using WarehouseSystem.Web.Controllers;
    using WarehouseSystem.Web.ViewModels.ToastrModels;

    public class MessagesActionFilter : ActionFilterAttribute
    {
        // This method is called BEFORE the action method is executed
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Check for incoming Toastr objects, in case we've been redirected here
            BaseController controller = filterContext.Controller as BaseController;
            if (controller != null)
            {
                controller.Toastr = (controller.TempData["Toastr"] as Toastr)
                                     ?? new Toastr();
            }

            base.OnActionExecuting(filterContext);
        }

        // This method is called AFTER the action method is executed but BEFORE the
        // result is processed (in the view or in the redirection)
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            BaseController controller = filterContext.Controller as BaseController;
            if (filterContext.Result.GetType() == typeof(ViewResult))
            {
                if (controller.Toastr != null && controller.Toastr.ToastMessages.Any())
                {
                    // We're going to a view so we store Toastr in the ViewData collection
                    controller.TempData["Toastr"] = controller.Toastr;
                }
            }
            else if (filterContext.Result.GetType() == typeof(RedirectToRouteResult))
            {
                if (controller.Toastr != null && controller.Toastr.ToastMessages.Any())
                {
                    // User is being redirected to another action method so we store Toastr in
                    // the TempData collection
                    controller.TempData["Toastr"] = controller.Toastr;
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
