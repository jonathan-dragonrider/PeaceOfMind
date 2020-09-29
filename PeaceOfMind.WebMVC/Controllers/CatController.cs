using Microsoft.AspNet.Identity;
using PeaceOfMind.Models.Cat;
using PeaceOfMind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeaceOfMind.WebMVC.Controllers
{
    public class CatController : Controller
    {
        // GET: Cat
        public ActionResult Index()
        {
            var service = CreateCatService();
            var model = service.GetCats();
            return View(model);
        }

        // GET: Cat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCatService();

            if (service.CreateCat(model))
            {
                TempData["SaveResult"] = "Cat created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Cat could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCatService();
            var model = svc.GetCatById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCatService();
            var detail = service.GetCatById(id);
            var model =
                new CatEdit
                {
                    Name = detail.Name,
                    ClientId = detail.ClientId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CatEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CatId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCatService();

            if (service.UpdateCat(model))
            {
                TempData["SaveResult"] = "Cat updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cat could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCatService();
            var model = svc.GetCatById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCatService();

            service.DeleteCat(id);

            TempData["SaveResult"] = "Cat deleted";

            return RedirectToAction("Index");
        }

        private CatService CreateCatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CatService(userId);
            return service;
        }
    }
}