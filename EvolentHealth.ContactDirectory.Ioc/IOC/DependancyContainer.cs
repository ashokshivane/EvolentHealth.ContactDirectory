using EvolentHealth.ContactDirectory.BusinessEntities.Interfaces;
using EvolentHealth.ContactDirectory.DataAccess;
using EvolentHealth.ContactDirectory.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace EvolentHealth.ContactDirectory.Ioc
{
   public class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Using Singleton as I am using mock data.
            
            //Data Access Layer 
             services.AddSingleton<IContactsRepository, MockContactsRepositoty>();
            //Un-comment it if you want to run the API project with real time data & UI project to run with database instead of mock data.
            //services.AddScoped<IContactsRepository, ContactsRepository>();
        }
    }
}
