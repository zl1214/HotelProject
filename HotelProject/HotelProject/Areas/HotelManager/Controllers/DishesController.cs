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
       

        // GET: HotelManager/Dishes
        //页面跳转
        public ActionResult Index()
        {
            return View();
        }

       
    }
}