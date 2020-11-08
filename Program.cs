﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookADONET
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // UC 16 Get all contacts
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            addressBookRepo.GetContacts();

            // UC 17 Update Contact
            addressBookRepo.UpdateContact("Ravi", "kumar", "phoneNumber", "8888888888");
            addressBookRepo.GetContacts("Ravi", "kumar");

            // UC 18 Get contacts added in a period
            addressBookRepo.GetContactsAddedInPeriod(new DateTime(2014, 05, 05), new DateTime(2021, 06, 06));

            // UC 19 Get contacts by city or state
            addressBookRepo.GetContactsByCityOrState("pala", "kerala");

            // UC 20 Add New Contact
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
            addressBookRepo.AddNewContact(contact);
            addressBookRepo.GetContacts();
        }
    }
}
