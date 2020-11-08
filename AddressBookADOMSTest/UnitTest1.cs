// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookADOMSTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using AddressBookADONET;

    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// TC 17 Updates the contact and test the database.
        /// </summary>
        [TestMethod]
        public void UpdateContactAndTestTheDB()
        {
            // Arrange
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            
            // Act
            addressBookRepo.UpdateContact("Ravi", "kumar", "phoneNumber", "8888888889");
            List<ContactDetails> contactlist = addressBookRepo.GetContacts("Ravi", "kumar");
            ContactDetails contact = contactlist.Find(contact => contact.FirstName == "Ravi" &&
                                                        contact.LastName == "kumar");

            // Assert
            Assert.AreEqual("8888888889", contact.PhoneNumber);
        }
    }
}
