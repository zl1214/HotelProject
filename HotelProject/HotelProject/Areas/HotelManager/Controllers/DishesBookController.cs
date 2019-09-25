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
        private DishesBookMananger manager = new DishesBookMananger();

        // GET: HotelManager/DishesBook
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DishesBookList(int page,int limit, string hotelName, string customerName)
        {
            var list = manager.GetAllDishesBook(page,limit, hotelName, customerName);
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderStatus(DishesBook book)
        {
            int res = manager.UpdateDishesBook(book);
            return Content(res.ToString());
        }
    }
}