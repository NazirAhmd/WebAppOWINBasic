﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOWINBasic.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}