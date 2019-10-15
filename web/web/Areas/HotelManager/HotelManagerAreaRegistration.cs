using System.Web.Mvc;

namespace HotelProject.Areas.HotelManager
{
    public class HotelManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HotelManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HotelManager_default",
                "HotelManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
               new string[] { "HotelProject.Areas.HotelManager.Controllers" }
            );
        }
    }
}