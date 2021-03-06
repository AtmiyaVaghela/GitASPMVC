﻿using ContactApp.Concrete.Filters;
using System.Web.Mvc;

namespace ContactApp.Controllers
{
    public class HomeController : Controller
    {
        [CAuthorize("A", "U")]
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
    }
}