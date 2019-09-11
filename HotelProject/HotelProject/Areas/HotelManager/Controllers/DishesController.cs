using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace HotelProject.Areas.HotelManager.Controllers
{
    public class DishesController : Controller
    {
        private DishesManager manager = new DishesManager();

        // GET: HotelManager/Dishes
        //页面跳转
        public ActionResult Index(int? categoryId)
        {
            ViewBag.DishesList = manager.GetAllDishes(categoryId);
            return View();
        }

       
    }
}