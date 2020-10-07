﻿using Microsoft.AspNet.Identity;
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

        public JsonResult GetEvents()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            var events = service.GetJobs();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}