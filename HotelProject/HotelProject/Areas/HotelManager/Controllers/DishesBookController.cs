﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelProject.Areas.HotelManager.Controllers
{
    public class DishesBookController : Controller
    {
        // GET: HotelManager/DishesBook
        public ActionResult Index()
        {
            return View();
        }
    }
}