using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookDay13
{
    class AddressBook
    {
        /// <summary>
        /// A list with the name 'Records' is created with the objectie to store the objects of AddressBook type
        /// </summary>
        public static List<AddressBook> Records = new List<AddressBook>();
        /// <summary>
        /// Below are the fields that the Address Book will have 
        /// </summary>
        public string firstName;
        public string lastName;
        public string MobileNumber;
        public string eMail;
        public string address;
        public string zipCode;
        public string state;

        /// <summary>
        /// Method to add the contact Entry
        /// </summary>
        public void AddContact()
        {
            Console.Clear();
            AddressBook contact = new AddressBook();
            bool check;
            do
            {
                Console.WriteLine("Enter the first name of the person: ");
                string tempFirstName = Console.ReadLine();
                Console.WriteLine("Enter the last name of the person: ");
                string tempLastName = Console.ReadLine();
                check = DuplicacyCheck(tempFirstName, tempLastName);
                if (check == false)
                {
                    contact.firstName = tempFirstName;
                    contact.lastName = tempLastName;
                    Console.WriteLine("Enter the mobile number of the person: ");
                    contact.MobileNumber = Console.ReadLine();
                    Console.WriteLine("Enter the email ID of the person: ");
                    contact.eMail = Console.ReadLine();
                    Console.WriteLine("Enter the address of the person");
                    contact.address = Console.ReadLine();
                    Console.WriteLine("Enter the ZIP code: ");
                    contact.zipCode = Console.ReadLine();
                    Console.WriteLine("Enter the state: ");
                    contact.state = Console.ReadLine();
                    Console.Clear();
                    Records.Add(contact);
                }
                if(check == true)
                {
                    Console.WriteLine("\nCannot proceed further. Entry with same name already exists");
                    Console.WriteLine("Please enter again");
                    Console.ReadKey();
                    Console.Clear();

                }
            } while (check == true);
        }
        /// <summary>
        /// Method to display the Contacts or single entry
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void DisplayContact(AddressBook contact)
        {
            Console.WriteLine("First Name : " + contact.firstName);
            Console.WriteLine("Last Name : " + contact.lastName);
            Console.WriteLine("Mobile  Number : " + contact.MobileNumber);
            Console.WriteLine("Email : " + contact.eMail);
            Console.WriteLine("Address : " + contact.address);
            Console.WriteLine("ZIP Code: " + contact.zipCode);
            Console.WriteLine("state : " + contact.state);
            Console.WriteLine("***************");
        }
        /// <summary>
        /// Method to display all the contacts present in the list named Records 
        /// </summary>
        public void DisplayRecords()
        {
            Console.Clear();
            if (Records.Count == 0)
            {
                Console.WriteLine("The address book has no entries");
            }
            else
            {
                Console.WriteLine("***Your Contacts***\n\n***************");
                foreach (var contact in Records)
                {
                    DisplayContact(contact);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Method to search the contact using first name which further gives option  to either edit or delete the matched entry
        /// </summary>
        /// <param name="name">The name.</param>
        public void SearchByName(string name)
        {
            bool FLAG = false;
            Console.Clear();
            if (Records.Count == 0)
            {
                Console.WriteLine("The address book has no entries");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                for (int i = 0; i < Records.Count; i++)
                {
                    if ((Records[i].firstName).Equals(name))
                    {
                        FLAG = true;
                        Console.Clear();
                        DisplayContact(Records[i]);
                        Console.WriteLine("Enter 1 to edit contact\nEnter 2 to delete the contact\nEnter 3 to continue searching\nEnter 4 to stop search");
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Enter the first name of the person: ");
                                Records[i].firstName = Console.ReadLine();
                                Console.WriteLine("Enter the last name of the person: ");
                                Records[i].lastName = Console.ReadLine();
                                Console.WriteLine("Enter the mobile number of the person: ");
                                Records[i].MobileNumber = Console.ReadLine();
                                Console.WriteLine("Enter the email ID of the person: ");
                                Records[i].eMail = Console.ReadLine();
                                Console.WriteLine("Enter the address of the person");
                                Records[i].address = Console.ReadLine();
                                Console.WriteLine("Enter the ZIP code: ");
                                Records[i].zipCode = Console.ReadLine();
                                Console.WriteLine("Enter the state: ");
                                Records[i].state = Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                Records.RemoveAt(i);
                                Console.Clear();
                                break;
                            case 3:
                                continue;
                            case 4:
                                break;
                        }
                    }
                }
                if (FLAG == false)
                {
                    Console.WriteLine("No such entry found");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// This method checks if the entry with same name already exists or not in the records
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <returns></returns>
        public bool DuplicacyCheck(string firstname, string lastname)
        {
            bool FLAG = false;
            for (int i = 0; i < Records.Count; i++)
            {
                if(Records[i].firstName.Equals(firstname) && Records[i].lastName.Equals(lastname))
                {
                    FLAG = true;
                    return FLAG;
                }
            }
            return FLAG;
        }
    }
}
