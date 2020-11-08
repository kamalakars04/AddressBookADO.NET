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
    using System;

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

        /// <summary>
        /// TC 18 Gets the contacts added in particular period.
        /// </summary>
        [TestMethod]
        public void GetContactsAddedInParticularPeriod()
        {
            // Arrange
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            // Act
            List<ContactDetails> actualContactList = addressBookRepo.GetContactsAddedInPeriod(new DateTime(2012, 05, 05), new DateTime(2013, 06, 06));
            List<ContactDetails> expectedContactList = addressBookRepo.GetContacts("Abhi", "J");

            // Assert
            CollectionAssert.AreEqual(actualContactList, expectedContactList);
        }
    }
}
