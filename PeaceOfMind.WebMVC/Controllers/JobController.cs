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
    public class JobController : Controller
    {
        private JobService CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            return service;
        }

        // GET: Job/Index view
        public ActionResult Index()
        {
            var service = CreateJobService();
            var model = service.GetJobs();
            return View(model);
        }

        // GET: Job/Create view
        public ActionResult Create()
        {
            var service = CreateJobService();
            var clients = service.GetClients();
            var services = service.GetServices();
            var pets = service.GetPets();
            ViewBag.ClientId = new SelectList(clients, "ClientId", "Name");
            ViewBag.ServiceId = new SelectList(services, "ServiceId", "Name");
            ViewBag.PetIds = new SelectList(pets, "PetId", "Name");

            return View();
        }

        // POST: Job/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateJobService();
                service.CreateJob(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Job/Detail
        public ActionResult Details(int id)
        {
            var service = CreateJobService();
            var model = service.GetJobById(id);

            return View(model);
        }

        // GET: Job/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateJobService();
            var detail = service.GetJobById(id);
            var model =
                new JobEdit
                {
                    ClientId = detail.ClientId,
                    ServiceId = detail.ServiceId,
                    PetIds = detail.PetIds,
                    StartTime = detail.StartTime,
                    Note = detail.Note,
                };
            return View(model);
        }

        // POST: Job/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateJobService();
                service.UpdateJob(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Job/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateJobService();
            var model = service.GetJobById(id);

            return View(model);
        }

        // POST: Job/Delete
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobService();
            service.DeleteJob(id);

            return RedirectToAction("Index");
        }
    }
}
// Next Steps:
// Populate drop down lists
// Figure out how to send lists through the view - checkboxes? drop down list but it lets you select multiple values?