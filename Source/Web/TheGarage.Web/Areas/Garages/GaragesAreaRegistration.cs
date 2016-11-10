using System.Web.Mvc;

namespace TheGarage.Web.Areas.Garages
{
    public class GaragesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Garages";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {


            context.MapRoute(
                    "Garages_by_id_and_name",
                    "Garages/{id}/{name}",
                    new
                    {
                        controller = "List",
                        action = "Index1",
                        id = UrlParameter.Optional,
                        category = UrlParameter.Optional
                    });

            context.MapRoute(
                "Garages_default",
                "Garages/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}