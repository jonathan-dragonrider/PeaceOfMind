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
        private PetService CreatePetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PetService(userId);
            return service;
        }

        // GET: Pet/Index view
        public ActionResult Index()
        {
            var service = CreatePetService();
            var model = service.GetPets();
            return View(model);
        }

        // GET: Pet/Create view
        public ActionResult Create()
        {
            var service = CreatePetService();
            var owners = service.GetOwners();
            ViewBag.ClientId = new SelectList(owners, "ClientId", "Name");

            return View();
        }

        // POST: Pet/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreatePetService();
                service.CreatePet(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Pet/Detail
        public ActionResult Details(int id)
        {
            var service = CreatePetService();
            var model = service.GetPetById(id);

            return View(model);
        }

        // GET: Pet/Edit
        public ActionResult Edit(int id)
        {
            var service = CreatePetService();
            var detail = service.GetPetById(id);
            var model =
                new PetEdit
                {
                    PetId = detail.PetId,
                    Name = detail.Name,
                    Owner = detail.Owner,
                    ClientId = detail.ClientId,
                    TypeOfPet = detail.TypeOfPet,
                };

            var owners = service.GetOwners();
            ViewBag.Owners = owners;
            ViewBag.SelectedOwner = owners.Where(owner => owner.ClientId == model.ClientId);

            return View(model);
        }

        // POST: Pet/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PetEdit model)
        {
            if (ModelState.IsValid)
            {
                var service = CreatePetService();
                service.UpdatePet(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Pet/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreatePetService();
            var model = service.GetPetById(id);

            return View(model);
        }

        // POST: Pet/Delete
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePetService();
            service.DeletePet(id);

            return RedirectToAction("Index");
        }
    }
}