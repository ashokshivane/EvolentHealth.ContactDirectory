using EvolentHealth.ContactDirectory.BusinessEntities.Interfaces;
using EvolentHealth.ContactDirectory.BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHealth.ContactDirectory.DataAccess
{
    public class MockContactsRepositoty : IContactsRepository
    {
        private List<ContactModels> contacts = new List<ContactModels>();
        public MockContactsRepositoty()
        {
            contacts.Add(new ContactModels() { Id = 101, FirstName = "Ashok", lastName = "Shivne", Email = "abc@gmail.com", PhoneNumber = "1234567890", Status = true });
            contacts.Add(new ContactModels() { Id = 102, FirstName = "Test1", lastName = "User1", Email = "test1User1@gmail.com", PhoneNumber = "2345678901", Status = true });
            contacts.Add(new ContactModels() { Id = 103, FirstName = "Test2", lastName = "User2", Email = "test2User2@gmail.com", PhoneNumber = "3456789012", Status = true });
            contacts.Add(new ContactModels() { Id = 104, FirstName = "Test3", lastName = "User3", Email = "test3User3@gmail.com", PhoneNumber = "3456789012", Status = true });
        }
   
       
        public async Task<List<ContactModels>> GetAsyncContacts()
        {
            try
            {
                if (contacts != null)
                {
                    var allContacts = Task.Run(() => contacts);
                    return await allContacts;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }

        public async Task<ContactModels> GetAsyncContact(int? contactId)
        {
            try
            {
                if (contacts != null && contactId != null)
                {
                    var contact = Task.Run(() => contacts.Find(x => x.Id == contactId));
                    return await contact;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        public async Task<ContactModels> AddAsyncContact(ContactModels contactModel)
        {
            try
            {
                if (contactModel != null)
                {
                    contactModel.Id = contacts.Max(x => x.Id) + 1;
                    var allContacts = Task.Run(() => contacts.Add(contactModel));
                    var newContact = Task.Run(() => contactModel);
                    return await newContact;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return null;
        }

        public async Task<ContactModels> DeleteAsyncContact(int? contactId)
        {
           
            try
            {  
                var removedContact = Task.Run(() => contacts.Find(x => x.Id == contactId));
                if(contacts.Remove(contacts.Find(x => x.Id == contactId)))
                {
                    return await removedContact;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<ContactModels> UpdateAsyncContact(ContactModels contactModel)
        {
            
            try
            {
                var contact = contacts.Find(x => x.Id == contactModel.Id);
                contacts.Remove(contact);
                contacts.Add(contactModel);
                return await Task.Run(() => contactModel);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
