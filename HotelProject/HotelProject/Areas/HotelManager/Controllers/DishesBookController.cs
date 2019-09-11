using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

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