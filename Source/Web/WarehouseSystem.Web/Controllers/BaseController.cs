namespace WarehouseSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Ninject;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Services.Web;
    using WarehouseSystem.Web.ViewModels.ToastrModels;

    [HandleError]
    public class BaseController : Controller
    {
        [Inject]
        public IUserServices Users { get; set; }

        [Inject]
        public ICacheService Cache { get; set; }

        public BaseController()
        {
            this.Toastr = new Toastr();
        }

        public Toastr Toastr { get; set; }

        protected User UserProfile { get; private set; }

        public ToastMessage AddToastMessage(string title, string message, ToastType toastType)
        {
            return this.Toastr.AddToastMessage(title, message, toastType);
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            var userName = requestContext.HttpContext.User.Identity.Name;
            this.UserProfile = this.Users.GetByName(userName);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
