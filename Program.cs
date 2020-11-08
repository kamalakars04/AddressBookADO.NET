// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookADO.NET
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // UC 16 Get all contacts
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            addressBookRepo.GetContacts();
        }
    }
}
