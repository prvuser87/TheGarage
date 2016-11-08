using System.Web.Mvc;

namespace TheGarage.Web.Areas.CompanyManagers
{
    public class CompanyManagersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CompanyManagers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CompanyManagers_default",
                "CompanyManagers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}