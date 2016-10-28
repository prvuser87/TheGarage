using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheGarage.Web.Startup))]
namespace TheGarage.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
