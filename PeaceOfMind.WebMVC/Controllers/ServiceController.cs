using Microsoft.AspNet.Identity;
using PeaceOfMind.Data;
using PeaceOfMind.Models;
using PeaceOfMind.Models.Service;
using PeaceOfMind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeaceOfMind.WebMVC.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            var service = CreateServiceService();
            var model = service.GetServices();
            return View(model);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateServiceService();

            if (service.CreateService(model))
            {
                TempData["SaveResult"] = "Service created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Service could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateServiceService();
            var model = svc.GetServiceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateServiceService();
            var detail = service.GetServiceById(id);
            var model =
                new ServiceEdit
                {
                    ServiceId = detail.ServiceId,
                    Name = detail.Name,
                    Cost = detail.Cost,
                    Duration = detail.Duration,
                    DurationUnit = detail.DurationUnit,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ServiceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateServiceService();

            if (service.UpdateService(model))
            {
                TempData["SaveResult"] = "Service updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Service could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateServiceService();
            var model = svc.GetServiceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateServiceService();

            service.DeleteService(id);

            TempData["SaveResult"] = "Service deleted";

            return RedirectToAction("Index");
        }

        private ServiceService CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userId);
            return service;
        }
    }
}