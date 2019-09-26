using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace HotelProject.Areas.HotelManager.Controllers
{
    public class RecruitmentController : Controller
    {
        // GET: HotelManager/Recruitment

        private RecruitmentManager manager = new RecruitmentManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RecruitmentList(int page, int limit)
        {
            var list = manager.GetAllRecruitment(page,limit);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Creat()
        {
            return View();
        }

        public ActionResult AddCreat(Recruitment rec)
        {
            rec.PublishTime = DateTime.Now;
            int res = manager.AddRecruitment(rec);
            return Content(res.ToString());
        }

        public ActionResult Update(int postId)
        {
            ViewBag.postId = postId;
            return View();
        }

        public ActionResult SelectRecruitmentById(int postId)
        {
            var rec = manager.GetRecruitmentById(postId);
            return Json(rec, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateRecruitment(Recruitment rec)
        {
            rec.PublishTime = DateTime.Now;
            int res = manager.ModifyRecruitment(rec);
            return Content(res.ToString());
        }

        public ActionResult Delete(int[] num)
        {           
            int res = manager.DeleteRecruitment(num);
            return Content(res.ToString());
        }
    }
}