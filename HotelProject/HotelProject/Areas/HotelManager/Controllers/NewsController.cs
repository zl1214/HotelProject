using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace HotelProject.Areas.HotelManager.Controllers
{
    public class NewsController : Controller
    {
        private NewsManager manager = new NewsManager();

        // GET: HotelManager/News
        public ActionResult Index()
        {
            return View();
        }

        //获取所有的新闻列表
        public ActionResult GetAllNews(int? newCategory, int page, int limit)
        {
            var list = manager.GetAllNews(null, page, limit);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Creat(News objnew)
        {
            int res = manager.AddNews(objnew);
            return Content(res.ToString());
        }
    }
}