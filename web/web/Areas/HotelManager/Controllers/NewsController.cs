using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace HotelProject.Areas.HotelManager.Controllers
{
    [Authorize]
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

        //页面跳转到新闻发布
        public ActionResult Creat()
        {
            return View();
        }

        //新闻发布动作方法
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Creat(News objnew)
        {
            objnew.PublishTime = DateTime.Now;
            int res = manager.AddNews(objnew);
            return Content(res.ToString());
        }

        //页面跳转只修改页面
        public ActionResult Update(int newsId)
        {  
            ViewBag.NewsId = newsId;
            return View();
        }


        public ActionResult SelectNewsById(int newsId)
        {
            var objNew = manager.SelectNewsById(newsId);
            return Json(objNew,JsonRequestBehavior.AllowGet);
        }

        //修改新闻的动作方法
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(News objnew)
        {
            int res = manager.UpdateNews(objnew);
            return Content(res.ToString());
        }

        //批量删除新闻
        public ActionResult Delete(int[] num)
        {
            int res = manager.DeleteNews(num);
            return Content(res.ToString());
        }
    }
}