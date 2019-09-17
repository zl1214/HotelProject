﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BLL;
using Models;

namespace HotelProject.Areas.HotelManager.Controllers
{
    public class DishesController : Controller
    {
        private DishesManager manager = new DishesManager();

        #region 菜品展示及异步分类查询
        //页面跳转
        public ActionResult Index(int? categoryId)
        {
            ViewBag.DishesList = manager.GetAllDishes(categoryId);
            if (Request.IsAjaxRequest())
            {
                return View("DishesList", ViewBag.DishesList);
            }            
            return View();
        }
        #endregion

        #region 添加菜品
        public ActionResult AddDishes()
        {
            return View();
        }

        private static string src = null;
        //图片上传
        public ActionResult UploadImg()
        {
            try
            {
                var file = Request.Files[0];
                src = Server.MapPath("~/Content/images/Dishes/" + file.FileName);
                file.SaveAs(src);
                var json = new { code = 0, msg = "", data = new { src = "~/Content/images/Dishes/" + file.FileName } };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.ToString() });
            }           
        }

        //表单提交，修改图片名称
        public ActionResult PublishDishes(Dishes dish)
        {
            //提交表单
            int dishesId = manager.ReturuDishesId(dish);
            if (dishesId > 0)
            {
                //提交成功后，判断是否有图片，如果有图片，则修改图片的名称
                
                FileInfo fi = new FileInfo(src);
                if (fi.Exists)
                {
                    string modeifySrc = "~/Content/images/Dishes/" + dishesId.ToString() + ".png";
                    fi.MoveTo(Server.MapPath(modeifySrc));
                    src = null;               
                }               
                return Content("1");

            }
            else { return Content("0"); }
        }
        #endregion

        #region 修改菜品

        public ActionResult ModifyDishes(int dishesId)
        {
            ViewBag.dishesId = dishesId;
            return View();
        }

        public ActionResult SelectDishesById(int dishesId)
        {
            Dishes dish = manager.GetDishesById(dishesId);
            return Json(dish,JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}