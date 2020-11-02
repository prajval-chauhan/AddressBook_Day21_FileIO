using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace AddressBookDay13
{
    public class FileIO
    {
        // A count vairiabl eto print the serial number of the contacts while exporting them
        int count = 0;
        //This is the path of the .txt file that would be used
        string path = @"C:\Users\prajv\source\repos\AddressBookDay13\Contact Book.txt";
        /// <summary>
        /// Calls the is used to call the Read/Write method as required by the user
        /// </summary>
        /// <param name="i">The i.</param>
        public void callMethod(int i)
        {
            switch (i)
            {
                case 1:
                    WriteAddressBook();
                    Console.Clear();
                    Console.WriteLine("Contacts exported to .txt file");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    ReadAddressBook();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    WriteAddressBookCSV();
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    ReadAddressBookCSV();
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Choice");
                    Console.ReadKey();
                    break;
            }
        }
        /// <summary>
        ///  This method is used to copy the data of the list that is storing the contacts into the .txt file
        /// </summary>
        public void WriteAddressBook()
        {
            if(File.Exists(path))
            {
                using (StreamWriter copyAddressBook = File.AppendText(path))
                {
                    foreach (AddressBook contact in AddressBook.Records)
                    {
                        count++;
                        copyAddressBook.WriteLine("**********\nContact No: {0}\n***********", count);
                        copyAddressBook.WriteLine("First Name : " + contact.firstName);
                        copyAddressBook.WriteLine("Last  Name : " + contact.lastName);
                        copyAddressBook.WriteLine("Mobile Number : " + contact.MobileNumber);
                        copyAddressBook.WriteLine("Email : " + contact.eMail);
                        copyAddressBook.WriteLine("City : " + contact.city);
                        copyAddressBook.WriteLine("State : " + contact.state);
                    }
                    copyAddressBook.Close();
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
        }
        /// <summary>
        /// This method is used to read the data/contents of the .txt file
        /// </summary>
        public void ReadAddressBook()
        {
            using (StreamReader readAddressBook = File.OpenText(path))
            {
                if (File.Exists(path))
                 {
                    string read = "";
                    while((read = readAddressBook.ReadLine()) != null)
                        Console.WriteLine(read);
                    Console.ReadKey();
                }
            }
        }
        /// <summary>
        /// This method is used to write the data/contents of address book list into the .csv file
        /// </summary>
        public void WriteAddressBookCSV()
        {
            string csvFilePath = @"C:\Users\prajv\source\repos\AddressBookDay13\FileIO.csv";
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.Configuration.MemberTypes = CsvHelper.Configuration.MemberTypes.Fields;
                csv.WriteRecords(AddressBook.Records);
                writer.Flush();
            }
        }
        /// <summary>
        /// This method is used to read the data/contents of the .csv file
        /// </summary>
        public static void ReadAddressBookCSV()
        {
            string csvFilePath = @"C:\Users\prajv\source\repos\AddressBookDay13\FileIO.csv";
            using (var reader = new StreamReader(csvFilePath))
                using(var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressBook>().ToList();
                foreach(AddressBook contact in records)
                {
                    Console.WriteLine("First Name : " + contact.firstName);
                    Console.WriteLine("Last  Name : " + contact.lastName);
                    Console.WriteLine("Mobile Number : " + contact.MobileNumber);
                    Console.WriteLine("Email : " + contact.eMail);
                    Console.WriteLine("zipCode : " + contact.zipCode);
                    Console.WriteLine("City : " + contact.city);
                    Console.WriteLine("State : " + contact.state);
                }
            }
        }
    }
}
