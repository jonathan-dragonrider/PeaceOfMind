using Microsoft.AspNet.Identity;
using PeaceOfMind.Models.Job;
using PeaceOfMind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeaceOfMind.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var jobEvent = new JobEvent
            {
                id = 1,
                title = "test",
                start = "2020-10-10"
            };
            return View(jobEvent);
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

        public ActionResult GetEvents()
        {
            var jobEvent = new JobEvent
            {
                id = 1,
                title = "test",
                start = "2020-10-10",
            };

            return new JsonResult { Data = jobEvent, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}