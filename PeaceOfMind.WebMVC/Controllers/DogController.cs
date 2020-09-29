using Microsoft.AspNet.Identity;
using PeaceOfMind.Models.Dog;
using PeaceOfMind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeaceOfMind.WebMVC.Controllers
{
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            var service = CreateDogService();
            var model = service.GetDogs();
            return View(model);
        }

        // GET: Dog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDogService();

            if (service.CreateDog(model))
            {
                TempData["SaveResult"] = "Dog created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Dog could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDogService();
            var detail = service.GetDogById(id);
            var model =
                new DogEdit
                {
                    Name = detail.Name,
                    ClientId = detail.ClientId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DogId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDogService();

            if (service.UpdateDog(model))
            {
                TempData["SaveResult"] = "Dog updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Dog could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDogService();

            service.DeleteDog(id);

            TempData["SaveResult"] = "Dog deleted";

            return RedirectToAction("Index");
        }

        private DogService CreateDogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DogService(userId);
            return service;
        }
    }
}