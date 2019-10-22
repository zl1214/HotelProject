using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace HotelProject.Areas.HotelManager.Controllers
{
    public class ExcelController : Controller
    {
        // GET: HotelManager/Excel
        public ActionResult Index()
        {
            return View();
        }

        private static string src = null;
        //文件上传
        public ActionResult UploadFile()
        {
            try
            {
                var file = Request.Files[0];
                src = Server.MapPath("~/Content/Excel/" + file.FileName.Substring(file.FileName.LastIndexOf("\\")));
                file.SaveAs(src);
                new importDataFromExcelManager().GetDataFromExcel<Suggestion>(src); 
                var json = new { code = 0, msg = "", data = new { src = "~/Content/Excel/" + file.FileName } };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.ToString() });
            }
        }
    }
}