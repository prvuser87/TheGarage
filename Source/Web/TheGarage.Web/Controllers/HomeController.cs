using System.Linq;
using System.Web.Mvc;
using TheGarage.Common;
using TheGarage.Data;
using TheGarage.Web.Controllers.Base;

namespace TheGarage.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ITheGarageData data;

        public HomeController(ITheGarageData data)
        {
            this.data = data;
        }
        public ActionResult Index()
        {
            if (false)//this.User.IsInRole(GlobalConstants.PendingClientRole))
            {
                return RedirectToAction("Index", "Details", new { area = "Clients" });
            }else
            {
                return View();
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HasPermission("PermissionA")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}