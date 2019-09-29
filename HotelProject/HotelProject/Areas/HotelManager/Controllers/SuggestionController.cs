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
    public class SuggestionController : Controller
    {
        private SuggestionManager manager = new SuggestionManager();

        // GET: HotelManager/Suggestion
        public ActionResult Index()
        {
            ViewBag.SugNum = manager.GetAllSuggesById(0);
            ViewBag.Handling = manager.GetAllSuggesById(1);
            ViewBag.Handled = manager.GetAllSuggesById(2);
            return View();
        }

        //表格初始化
        public ActionResult SuggestionList(int page, int limit,int statusId=0)
        {
            var list = manager.GetAllSuggestion(page, limit, statusId);
            return Json(list,JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateStatusId(Suggestion sug)
        {
            int res = manager.UpdateStatusId(sug);           
            return Content(res.ToString());
        }

       
    }
}