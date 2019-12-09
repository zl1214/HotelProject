using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.IO;
using System.Text;

namespace HotelProject.Areas.HotelManager.Controllers
{
    [Authorize]
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
            var list = manager.GetAllRecruitment(page, limit);
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

        //展示上传数据
        public ActionResult ShowData()
        {
            try
            {
                TableModel<Recruitment> table = manager.ShowDataFromExcel(src);
                return Json(table, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {                
                return Json(new { code = 0, msg = ex.ToString(), data = new {r= ex.ToString() }, count = 0 });
            }

        }
       
        private static string src = null;
        //文件上传
        public ActionResult UploadExcelFile()
        {
            try
            {
                var file = Request.Files[0];
                src = Server.MapPath("/Content/ExcelFile/" + file.FileName);
                file.SaveAs(src);
                var json = new { code = 0, msg = "", data = new { src = "/Content/ExcelFile/" + file.FileName } };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.ToString() });
            }
        }

        //导入数据到数据库
        public ActionResult InputData()
        {
            int res = manager.InputDataToDB(src);
            src = null;
            return Content(res.ToString());
        }
        //模板下载
        public ActionResult TemplateDownload()
        {
            string filePath = Server.MapPath("/Content/ExcelFile/ta.xlsx");//路径
            return File(filePath, "application/x-xls", "Template.xlsx");
        }
    }
}