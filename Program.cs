using System;

namespace AddressBookDay13
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook call = new AddressBook();
            for (; ; )
            {
                Console.WriteLine("*** Welcome to the Address Book Program ***\n");
                Console.WriteLine("enter 1 to add contact\nenter 2 to display contacts\nenter 3 to search/edit/delete");
                Console.WriteLine("enter 4 to search by ZIP code or city name\nenter 5 to view the sorted address book");
                Console.WriteLine("enter 6 to exit");
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
                        Console.WriteLine("Enter the state name or ZIP code");
                        string input2 = Console.ReadLine();
                        call.SearchByCityOrState(input2);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("enter 1 to sort by first name");
                        int inputSort = Convert.ToInt32(Console.ReadLine());
                        if (inputSort == 1)
                            call.SortUsingName();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                if (userInput == 5)
                    break;
            }
        }
    }
}
