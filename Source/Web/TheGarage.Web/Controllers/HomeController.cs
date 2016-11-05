﻿using System.Web.Mvc;

namespace TheGarage.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TempDataTest()
        {
            if (this.TempData["SuccessMessage"] == null)
            {
                this.TempData["SuccessMessage"] == "Succes!";
            }
            var data = this.TempData["SuccessMessage"];

            return View(data);
        } 

    }


}