using EvolentHealth.ContactDirectory.BusinessEntities.Interfaces;
using EvolentHealth.ContactDirectory.BusinessEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolentHealth.ContactDirectory.DataAccess.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsContext _dbContext;

        public ContactsRepository(ContactsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactModels> GetAsyncContact(int? contactId)
        {
            try
            {
                if (_dbContext != null && contactId != null)
                {
                    return await _dbContext.Contacts.FindAsync(contactId);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return null;
        }

        public async Task<List<ContactModels>> GetAsyncContacts()
        {
            try
            {
                if (_dbContext != null)
                {
                    return await _dbContext.Contacts.ToListAsync();
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
                if (_dbContext != null)
                {
                    await _dbContext.Contacts.AddAsync(contactModel);
                    await _dbContext.SaveChangesAsync();

                    return contactModel;
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
                if (_dbContext != null && contactId != null)
                {

                    var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == contactId);

                    if (contact != null)
                    {
                        //Delete that contact
                        _dbContext.Contacts.Remove(contact);

                        //Commit the transaction
                        await _dbContext.SaveChangesAsync();
                        return contact;
                    }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            return null;
        }

        public async Task<ContactModels> UpdateAsyncContact(ContactModels contactModel)
        {
            try
            {
                if (_dbContext != null)
                {
                    //Delete that post
                    _dbContext.Contacts.Update(contactModel);

                    //Commit the transaction
                    await _dbContext.SaveChangesAsync();
                    return contactModel;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        
    }
}
