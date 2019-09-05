using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace HotelProject.Controllers
{
    public class DishesController : Controller
    {

        private DishesManager manager = new DishesManager();
        private DishesBookMananger book = new DishesBookMananger();
        
        //菜品展示
        public ActionResult Index(int? categoryId)
        {
            ViewBag.DishesList = manager.GetAllDishes(categoryId);
            return View();
        }

        public ActionResult DishesBook()
        {
            return View();
        }

        [HttpPost]
        //菜品预订
        public ActionResult DishesBook(DishesBook dishes)
        {
            int res = book.DishesBook(dishes);
            return Content(res.ToString());
        }
    }
}