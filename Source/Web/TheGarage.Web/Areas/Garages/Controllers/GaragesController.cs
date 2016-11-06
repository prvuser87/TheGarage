using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheGarage.Web.Areas.Garages.Controllers
{
    public class GaragesController : Controller
    {
        // GET: Garages/Garages
        public ActionResult Index()
        {
            return View();
        }
    }
}