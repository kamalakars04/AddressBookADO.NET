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
    using System.Linq;

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

        /// <summary>
        /// TC 21 Adds the multiple new contact.
        /// </summary>
        [TestMethod]
        public void AddMultipleNewContactWithThreads()
        {
            // Arrange
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            ContactDetails contact = new ContactDetails();
            contact.FirstName = "Varun";
            contact.LastName = "Arora";
            contact.PhoneNumber = "4564564564";
            contact.Email = "Varun@gmail.com";
            contact.Address = "That nagar";
            contact.zip.zip = "741258";
            contact.zip.city = "Jaipur";
            contact.zip.state = "Rajasthan";
            contact.bookNameContactType.Add("Mybook", new List<string> { "Friend", "Family" });

            // Add to list of contacts
            List<ContactDetails> contacts = new List<ContactDetails> { contact };
            ContactDetails contact1 = new ContactDetails(); 
            contact1.FirstName = "Bajaj";
            contact1.LastName = "Honda";
            contact1.PhoneNumber = "7896544569";
            contact1.Email = "Bajaj@gmail.com";
            contact1.Address = "Bike nagar";
            contact1.zip.zip = "741258";
            contact1.zip.city = "Jaipur";
            contact1.zip.state = "Rajasthan";
            contact1.bookNameContactType.Add("BroBook", new List<string> { "Friend", "Family" });
            
            // Add contact to list
            contacts.Add(contact1);

            // Act
            addressBookRepo.InsertMultipleContactsWithThreads(contacts);
            List<ContactDetails> actual = addressBookRepo.GetContacts().FindAll(contact => (contact.FirstName == "Bajaj" && contact.LastName == "Honda") ||
                                                                                           (contact.FirstName == "Varun" && contact.LastName == "Arora")).OrderBy(c => c.FirstName).ToList();
            List<ContactDetails> expected = new List<ContactDetails> { contact,contact1}.OrderBy(c => c.FirstName).ToList();
            // Assert
            CollectionAssert.AreEqual(actual, expected);
        }

    }
}
