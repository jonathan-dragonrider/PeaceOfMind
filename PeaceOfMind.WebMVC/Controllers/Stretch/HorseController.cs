using Microsoft.AspNet.Identity;
using PeaceOfMind.Models.Horse;
using PeaceOfMind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeaceOfMind.WebMVC.Controllers
{
    public class HorseController : Controller
    {
        // GET: Horse
        public ActionResult Index()
        {
            var service = CreateHorseService();
            var model = service.GetHorses();
            return View(model);
        }

        // GET: Horse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HorseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHorseService();

            if (service.CreateHorse(model))
            {
                TempData["SaveResult"] = "Horse created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Horse could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateHorseService();
            var model = svc.GetHorseById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHorseService();
            var detail = service.GetHorseById(id);
            var model =
                new HorseEdit
                {
                    Name = detail.Name,
                    ClientId = detail.ClientId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HorseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HorseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHorseService();

            if (service.UpdateHorse(model))
            {
                TempData["SaveResult"] = "Horse updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Horse could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateHorseService();
            var model = svc.GetHorseById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHorseService();

            service.DeleteHorse(id);

            TempData["SaveResult"] = "Horse deleted";

            return RedirectToAction("Index");
        }

        private HorseService CreateHorseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HorseService(userId);
            return service;
        }
    }
}