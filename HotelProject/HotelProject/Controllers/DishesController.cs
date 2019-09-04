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
        // GET: Dishes
        public ActionResult Index(int? categoryId)
        {
            ViewBag.DishesList = manager.GetAllDishes(categoryId);
            return View();
        }
        public ActionResult SelectDishesById(int? categoryId)
        {
            ViewBag.DishesList = manager.GetAllDishes(categoryId);
            return View("Index", ViewBag.DishesList);
        }
    }
}