using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace HotelProject.Controllers
{
    public class NewsController : Controller
    {
        private NewsManager manager = new NewsManager();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        //根据条件获取新闻列表
        public ActionResult GetNewsList(int? newCategory, int page, int limit)
        {
            var obj = manager.GetAllNews(newCategory, page, limit);
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        //根据newID获取新闻详情
        public ActionResult Detail(int newId)
        {
           ViewBag.news = manager.SelectNewsById(newId);
           return View();
        }
    }
}