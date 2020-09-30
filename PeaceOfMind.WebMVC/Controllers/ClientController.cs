using Microsoft.AspNet.Identity;
using PeaceOfMind.Models.Client;
using PeaceOfMind.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeaceOfMind.WebMVC.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var service = CreateClientService();
            var model = service.GetClients();
            return View(model);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Client created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Client could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(id);
            var model =
                new ClientEdit
                {
                    ClientId = detail.ClientId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber,
                    Address = detail.Address
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Client updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Client could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClientService();

            service.DeleteClient(id);

            TempData["SaveResult"] = "Client deleted";

            return RedirectToAction("Index");
        }

        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
    }

}