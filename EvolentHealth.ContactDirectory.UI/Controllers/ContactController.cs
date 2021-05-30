using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using EvolentHealth.ContactDirectory.BusinessEntities.Interfaces;
using EvolentHealth.ContactDirectory.BusinessEntities.Models;
using EvolentHealth.ContactDirectory.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvolentHealth.ContactDirectory.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactsRepository _contactRepository;

        public ContactController(IContactsRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        // GET: PersonController
        public async Task<ActionResult> Index()
        {
            List<ContactModels> model = await _contactRepository.GetAsyncContacts();

            return View(model);
        }

        // GET: PersonController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ContactModels Model = await _contactRepository.GetAsyncContact(id);
            return View(Model);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactModels addedModel = await _contactRepository.AddAsyncContact(model);
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ContactModels Model = await _contactRepository.GetAsyncContact(id);
            return View(Model);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContactModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactModels updatedModel = await _contactRepository.UpdateAsyncContact(model);
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ContactModels deletedModel = await _contactRepository.DeleteAsyncContact(id);
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
