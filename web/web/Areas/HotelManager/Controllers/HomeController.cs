﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelProject.Areas.HotelManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: HotelManager/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}