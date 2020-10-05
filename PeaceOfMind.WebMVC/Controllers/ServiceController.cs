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
        private ServiceService CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userId);
            return service;
        }

        // GET: Service/Index view
        public ActionResult Index()
        {
            var service = CreateServiceService();
            var model = service.GetServices();
            return View(model);
        }

        // GET: Service/Create view
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateServiceService();
                service.CreateService(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Service/Detail
        public ActionResult Details(int id)
        {
            var service = CreateServiceService();
            var model = service.GetServiceById(id);

            return View(model);
        }

        // GET: Service/Edit
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

        // POST: Service/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceEdit model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateServiceService();
                service.UpdateService(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Service/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateServiceService();
            var model = service.GetServiceById(id);

            return View(model);
        }

        // POST: Service/Delete
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateServiceService();
            service.DeleteService(id);

            return RedirectToAction("Index");
        }
    }
}