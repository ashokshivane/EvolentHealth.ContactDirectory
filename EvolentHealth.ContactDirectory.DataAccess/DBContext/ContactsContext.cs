using EvolentHealth.ContactDirectory.BusinessEntities.Models;
using Microsoft.EntityFrameworkCore;


namespace EvolentHealth.ContactDirectory.DataAccess
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }
        public DbSet<ContactModels> Contacts { get; set; }
    }
}
