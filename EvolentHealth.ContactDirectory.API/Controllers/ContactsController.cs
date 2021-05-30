using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvolentHealth.ContactDirectory.BusinessEntities.Interfaces;
using EvolentHealth.ContactDirectory.BusinessEntities.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvolentHealth.ContactDirectory.API.Controllers
{
    public class ContactsController : Controller
    {
        IContactsRepository _contactsRepository;
        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        // GET: ContactsController
        [HttpGet]
        [Route("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await _contactsRepository.GetAsyncContacts();
                if (contacts == null)
                {
                    return NotFound();
                }

                return Ok(contacts);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // GET: ContactsController/GetContact/5
        [HttpGet]
        [Route("GetContact")]
        public async Task<IActionResult> GetContact(int? contactId)
        {
            if (contactId == null)
            {
                return BadRequest();
            }

            try
            {
                var contact = await _contactsRepository.GetAsyncContact(contactId);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddPost([FromBody] ContactModels model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ContactModels addedModel = await _contactsRepository.AddAsyncContact(model);
                    if (addedModel != null)
                    {
                        return Ok(addedModel);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteContact")]
        public async Task<IActionResult> DeleteContact(int? contactId)
        {
            

            if (contactId == null)
            {
                return BadRequest();
            }

            try
            {
                ContactModels deletedModel = await _contactsRepository.DeleteAsyncContact(contactId);
                if (deletedModel == null)
                {
                    return NotFound();
                }
                return Ok(deletedModel);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateContact")]
        public async Task<IActionResult> UpdatePost([FromBody] ContactModels model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ContactModels updatedModel = await _contactsRepository.UpdateAsyncContact(model);

                    return Ok(updatedModel);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
