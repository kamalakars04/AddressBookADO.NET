// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookADO.NET
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ContactDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public class Zip
        {
            public string zip { get; set; }
            public string city { get; set; }
            public string state { get; set; }

            public override bool Equals(object obj)
            {
                return this.zip == ((Zip)obj).zip;
            }
        }

        public Zip zip = new Zip();

        public Dictionary<string, List<string>> bookNameContactType = new Dictionary<string, List<string>>();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is ContactDetails))
                return false;
            ContactDetails compareContact = (ContactDetails)obj;
            return this.FirstName == compareContact.FirstName && this.LastName == compareContact.LastName;
        }

        public void Display()
        {
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("FirstName : " + FirstName );
            Console.WriteLine("LastName : " + LastName);
            Console.WriteLine("PhoneNumber : " + PhoneNumber);
            Console.WriteLine("Email : " + Email);
            Console.WriteLine("Address : " + Address);
            Console.WriteLine("Zip : " + zip.zip);
            Console.WriteLine("City : " + zip.city);
            Console.WriteLine("State : " + zip.state);
            Console.Write("AddressBook Names : ");
            foreach(KeyValuePair<string,List<string>> keyValuePair in bookNameContactType)
                Console.Write(keyValuePair.Key);
            Console.Write("\nContact type : ");
            foreach (KeyValuePair<string, List<string>> keyValuePair in bookNameContactType)
                keyValuePair.Value.ForEach(type => Console.Write(type));

        }
    }
}