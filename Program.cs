using System;

namespace AddressBookDay13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Welcome to the Address Book Program ***\n");
            AddressBook call = new AddressBook();
            for (; ; )
            {
                Console.WriteLine("Enter 1 to Add Contact\nEnter 2 to display contacts\nEnter 3 to search/edit/delete\nEnter 4 to exit\n");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        call.AddContact();
                        break;
                    case 2:
                        call.DisplayRecords();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("******SEARCH******\nEnter the first name of the contact");
                        string input = Console.ReadLine();
                        call.SearchByName(input);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                if (userInput == 4)
                    break;
            }
        }
    }
}
