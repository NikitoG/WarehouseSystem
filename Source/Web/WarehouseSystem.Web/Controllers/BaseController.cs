using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Services.Data.Contract;

namespace WarehouseSystem.Web.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        [Inject]
        public IUserServices Users { get; set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            var userName = requestContext.HttpContext.User.Identity.Name;
            this.UserProfile = this.Users.GetByName(userName);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}