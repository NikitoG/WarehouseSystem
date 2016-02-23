using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseSystem.Common;
using WarehouseSystem.Web.Controllers;

namespace WarehouseSystem.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdminController : BaseController
    {
        // GET: Administration/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}