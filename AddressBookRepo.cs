// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookADONET
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;

    public class AddressBookRepo
    {
        // Create connection string 
        public static string connectionString = @"Server=LAPTOP-CTKSHLKD\SQLEXPRESS; Initial Catalog =Address_BookDB; User ID = sa; Password=kamal@99";
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// UC 16 Gets all contacts.
        /// </summary>
        public List<ContactDetails> GetContacts(string firstName = null, string lastName = null)
        {
            try
            {
                // Open connection
                connection.Open();

                // Declare a command
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllContacts";
                command.Connection = connection;

                // To get only one contact
                if (firstName != null && lastName != null)
                {
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                }
                SqlDataReader reader = command.ExecuteReader();
                List<ContactDetails> contactList = new List<ContactDetails>();
                ContactDetails contact;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // If the contact already exists then add in same contact
                        // Else new contact
                        contact = contactList.Find(con => con.FirstName == reader[0].ToString()
                                                    && con.LastName == reader[1].ToString());

                        // Read into contact details
                        if (contact == null)
                        {
                            contact = new ContactDetails();
                            contact.FirstName = reader[0].ToString();
                            contact.LastName = reader[1].ToString();
                            contact.PhoneNumber = reader[2].ToString();
                            contact.Email = reader[3].ToString();
                            contact.Address = reader[4].ToString();
                            contact.zip.zip = reader[5].ToString();
                            contact.zip.city = reader[6].ToString();
                            contact.zip.state = reader[7].ToString();
                            contact.bookNameContactType.Add(reader[8].ToString(), new List<string> { reader[9].ToString() });
                        }

                        // If contact already exists then add only book name and type
                        else
                        {
                            if (contact.bookNameContactType.ContainsKey(reader[9].ToString()))
                                contact.bookNameContactType[reader[8].ToString()].Add(reader[9].ToString());
                            else
                                contact.bookNameContactType.Add(reader[8].ToString(), new List<string> { reader[9].ToString() });
                        }
                        contactList.Add(contact);
                    }
                }

                // Display all the contacts
                contactList.ForEach(contact => contact.Display());
                reader.Close();
                return contactList;
            }
            catch
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                return null;
            }
            finally
            {

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// UC 17 Updates the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="column">The column.</param>
        /// <param name="newValue">The new value.</param>
        public void UpdateContact(string firstName, string lastName, string column, string newValue)
        {
            try
            {
                // Open connection
                connection.Open();

                // Declare a command and give all its properties
                SqlCommand command = new SqlCommand();
                command.CommandText = "update contactdetails set " + column + " = '" + newValue + "' where firstname = '"
                                        + firstName + "' and lastname = '" + lastName + "'";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            finally
            {

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
