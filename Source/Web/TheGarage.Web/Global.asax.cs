using PhilosophicalMonkey;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TheGarage.Data;
using TheGarage.Data.Migrations;

namespace TheGarage.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

             Database.SetInitializer(new MigrateDatabaseToLatestVersion<TheGarageDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TheGarageDbContext>());
            var seedTypes = new Type[] { typeof(Startup) };
            var assemblies = Reflect.OnTypes.GetAssemblies(seedTypes);
            var typesInAssemblies = Reflect.OnTypes.GetAllExportedTypes(assemblies);
            AutoMapper.SelfConfig.MappingConfigFactory.LoadAllMappings(typesInAssemblies);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
