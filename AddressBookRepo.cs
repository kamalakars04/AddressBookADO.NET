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
        public void GetContacts()
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

                SqlDataReader reader = command.ExecuteReader();
                List<ContactDetails> contactList = new List<ContactDetails>();
                ContactDetails contact;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contact = contactList.Find(con => con.FirstName == reader[0].ToString()
                                                    && con.LastName == reader[1].ToString());
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
                contactList.ForEach(contact => contact.Display());
                reader.Close();
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
