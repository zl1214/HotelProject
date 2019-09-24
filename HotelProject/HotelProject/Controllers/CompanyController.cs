using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;


namespace HotelProject.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Environment()
        {
            return View();
        }

        public ActionResult Suggestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Suggestion(Suggestion suggestion)
        {
            suggestion.SuggestionTime = DateTime.Now;
            suggestion.StatusId = 0;
            int res = new SuggestionManager().AddSuggestion(suggestion);
            return Content(res.ToString());
        }

        public ActionResult Recruitment()
        {
            return View();
        }

        
        public ActionResult RecruitmentList()
        {
            TableModel<Recruitment> list = new RecruitmentManager().GetAllRecruitment();
            return Json(list,JsonRequestBehavior.AllowGet);
        }


        public ActionResult RecruitmentDetail(int postId)
        {
            ViewBag.rec = new RecruitmentManager().GetRecruitmentById(postId);            
            return View();
        }
    }
}