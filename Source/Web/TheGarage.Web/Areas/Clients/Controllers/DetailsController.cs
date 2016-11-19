using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarage.Common;
using TheGarage.Web.Areas.Clients.Models;
using TheGarage.Web.Controllers.Base;

namespace TheGarage.Web.Areas.Clients.Controllers
{

    public class DetailsController : BaseController
    {
        // GET: Clients/Clients
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DetailsViewModel model)
        {
            return RedirectToAction("Index", "Details", new { area = "Clients" });
        }
    }
}