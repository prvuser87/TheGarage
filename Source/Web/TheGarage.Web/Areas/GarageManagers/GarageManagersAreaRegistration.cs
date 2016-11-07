using System.Web.Mvc;

namespace TheGarage.Web.Areas.GarageManagers
{
    public class GarageManagersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GarageManagers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GarageManagers_default",
                "GarageManagers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}