﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WarehouseSystem.Web.Areas.User.Controllers
{
    public class UserController : Controller
    {
        // GET: User/User
        public ActionResult Index()
        {
            return View();
        }
    }
}