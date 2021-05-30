using EvolentHealth.ContactDirectory.BusinessEntities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolentHealth.ContactDirectory.BusinessEntities.Interfaces
{
    public interface IContactsRepository 
    {
        Task<List<ContactModels>> GetAsyncContacts();

        Task<ContactModels> GetAsyncContact(int? contactId);

        Task<ContactModels> AddAsyncContact(ContactModels contactModel);

        Task<ContactModels> DeleteAsyncContact(int? contactId);

        Task<ContactModels> UpdateAsyncContact(ContactModels contactModel);

    }
}
