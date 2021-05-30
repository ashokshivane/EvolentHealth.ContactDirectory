using EvolentHealth.ContactDirectory.BusinessEntities.Interfaces;
using EvolentHealth.ContactDirectory.BusinessEntities.Models;
using EvolentHealth.ContactDirectory.DataAccess.Repository;
using EvolentHealth.ContactDirectory.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace EvolentHealth.ContactDirectory.UnitTest
{
    public class ContactTest
    {
        #region Property  
        public Mock<IContactsRepository> mock = new Mock<IContactsRepository>();
        #endregion

        [Fact]
        public async void GetContact_ById_ReturnsTrue()
        {
            var contactDTO = new ContactModels()
            {
                Id = 101,
                FirstName = "Ashok",
                lastName = "Shivne",
                Email = "abc@gmail.com",
                PhoneNumber = "1234567890",
                Status = true
            };

            int contactId = 101;
            mock.Setup(p => p.GetAsyncContact(contactId)).ReturnsAsync(contactDTO);
            ContactController contact = new ContactController(mock.Object);
            var result = await contact.Details(contactId);
            var model = result as ViewResult;
            
            Assert.True(contactDTO.Equals(model.Model));
        }

        [Fact]
        public async void GetContact_ById_ReturnsFalse()
        {
            var contactDTO = new ContactModels()
            {
                Id = 1,
                FirstName = "Ashok",
                lastName = "Shivne",
                Email = "abc@gmail.com",
                PhoneNumber = "1234567890",
                Status = true
            };

            int contactId = 101;
            mock.Setup(p => p.GetAsyncContact(contactId)).ReturnsAsync(contactDTO);
            ContactController contact = new ContactController(mock.Object);
            var result = await contact.Details(contactId);
            var model = result as ViewResult;

            Assert.True(contactDTO.Equals(model.Model));
        }

    }
}
