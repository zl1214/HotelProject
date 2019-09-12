using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

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

        public ActionResult AddDishes()
        {
            return View();
        }

        //public ActionResult UploadImg(Dishes dish)
        //{
        //     var file = Request.Files[0];
        //    int dishesId = manager.ReturuDishesId(dish);
        //    return Json(file, JsonRequestBehavior.AllowGet);
               
        //}

        //public ActionResult PublishDishes(Dishes dish)
        //{
           
            
           
        //    return Content(dishesId.ToString());
        //}

    }
}