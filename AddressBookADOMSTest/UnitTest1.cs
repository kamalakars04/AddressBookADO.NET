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

        /// <summary>
        /// TC 19 Get contacts by city or by state
        /// </summary>
        [TestMethod]
        public void GetContactsByCityOrState()
        {
            // Arrange
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            // Act
            List<ContactDetails> actualContactList = addressBookRepo.GetContactsByCityOrState("pala","kerala");
            List<ContactDetails> expectedContactList = addressBookRepo.GetContacts().FindAll(contact => contact.zip.city == "pala"
                                                                                              && contact.zip.state == "kerala");

            // Assert
            CollectionAssert.AreEqual(actualContactList, expectedContactList);
        }

        /// <summary>
        /// TC 20 Add new contact and then check database
        /// </summary>
        [TestMethod]
        public void AddNewContact()
        {
            // Arrange
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            ContactDetails contact = new ContactDetails();
            contact.FirstName = "Bhaskar";
            contact.LastName = "chandra";
            contact.PhoneNumber = "1212121212";
            contact.Email = "abc@gmail.com";
            contact.Address = "this nagar";
            contact.zip.zip = "123456";
            contact.zip.city = "Mumbai";
            contact.zip.state = "Maharastra";
            contact.bookNameContactType.Add("yesBook", new List<string> { "Friend", "Family" });
            

            // Act
            addressBookRepo.AddNewContact(contact);
            List<ContactDetails> actual =  addressBookRepo.GetContacts().FindAll(contact => contact.FirstName == "Bhaskar" && contact.LastName == "chandra");
            List<ContactDetails> expected = new List<ContactDetails> { contact };
            // Assert
            CollectionAssert.AreEqual(actual, expected);
        }

    }
}
