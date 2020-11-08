// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookADONET
{
    using System;

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
        }
    }
}
