using Microsoft.AspNet.Identity;
using PeaceOfMind.Models.Pet;
using PeaceOfMind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeaceOfMind.WebMVC.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index()
        {
            var service = CreatePetService();
            var model = service.GetPets();
            return View(model);
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            var svc = CreatePetService();
            var owners = svc.GetOwners();

            ViewBag.ClientId = new SelectList(owners, "ClientId", "FullName");

            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePetService();

            if (service.CreatePet(model))
            {
                TempData["SaveResult"] = "Pet created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Pet could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePetService();
            var model = svc.GetPetById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePetService();

            var owners = service.GetOwners();
            ViewBag.ClientId = new SelectList(owners, "ClientId", "FullName");

            var detail = service.GetPetById(id);
            var model =
                new PetEdit
                {
                    Name = detail.Name,
                    ClientId = detail.ClientId,
                    Type = detail.Type
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PetId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreatePetService();
            var owners = service.GetOwners();
            ViewBag.ClientId = new SelectList(owners, "ClientId", "FullName");

            if (service.UpdatePet(model))
            {
                TempData["SaveResult"] = "Pet updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Pet could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePetService();
            var model = svc.GetPetById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePetService();

            service.DeletePet(id);

            TempData["SaveResult"] = "Pet deleted";

            return RedirectToAction("Index");
        }

        private PetService CreatePetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PetService(userId);
            return service;
        }
    }
}