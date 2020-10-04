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
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }

        // GET: Client/Index view
        public ActionResult Index()
        {
            var service = CreateClientService();
            var model = service.GetClients();
            return View(model);
        }

        // GET: Client/Create view
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateClientService();
                service.CreateClient(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Client/Detail
        public ActionResult Details(int id)
        {
            var service = CreateClientService();
            var model = service.GetClientById(id);

            return View(model);
        }

        // GET: Client/Edit
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

        // POST: Client/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateClientService();
                service.UpdateClient(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Client/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateClientService();
            var model = service.GetClientById(id);

            return View(model);
        }

        // POST: Client/Delete
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClientService();
            service.DeleteClient(id);

            return RedirectToAction("Index");
        }

        
    }

}