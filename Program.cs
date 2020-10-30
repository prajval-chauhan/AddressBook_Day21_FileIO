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
                Console.WriteLine("enter 6 to perform File IO Operations\nenter 7 to exit");
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
                        Console.WriteLine("Enter the state name or city");
                        string input2 = Console.ReadLine();
                        call.SearchByCityOrState(input2);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("enter 1 to sort by first name\nenter 2 to sort by state\nenter 3 to sort by ZIP code\nenter 4 to sort using City");
                        int inputSort = Convert.ToInt32(Console.ReadLine());
                        call.SortingAddressBook(inputSort);
                        break;
                    case 6:
                        Console.WriteLine("enter 1 to copy export the data into the notepad file\nenter 2 to see the exported data");
                        int file = Convert.ToInt32(Console.ReadLine());
                        FileIO fileIO = new FileIO();
                        fileIO.callMethod(file);
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                if (userInput == 7)
                    break;
            }
        }
    }
}
