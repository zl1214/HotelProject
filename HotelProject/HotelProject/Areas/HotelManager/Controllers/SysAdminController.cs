using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.Web.Security;

namespace HotelProject.Areas.HotelManager.Controllers
{
    public class SysAdminController : Controller
    {
        private SysAdminsManager manager = new SysAdminsManager();

        // GET: HotelManager/SysAdmin
        public ActionResult Index()
        {
            return View("AdminLogin");
        }

        public ActionResult AdminLogin(SysAdmins objAdmin)
        {
            objAdmin = manager.Login(objAdmin);
            if (objAdmin != null)
            {
                Session["AadminName"] = objAdmin.LoginName;
                FormsAuthentication.SetAuthCookie(objAdmin.LoginName, true);
                return Content("1");
            }
            else
            {
                return Content("0");
            }           
        }

        public ActionResult AdminMain()
        {
            return View();
        }
    }
}