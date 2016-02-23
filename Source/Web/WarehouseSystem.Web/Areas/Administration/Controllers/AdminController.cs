using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseSystem.Common;

namespace WarehouseSystem.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdminController : Controller
    {
        // GET: Administration/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}