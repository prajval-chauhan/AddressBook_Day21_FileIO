using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using System.Linq;
using CsvHelper.Configuration;

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
                    EditAddressBook();
                    break;
                case 2:
                    ReadAddressBook();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        /// <summary>
        ///  This method is used to copy the data of the list that is storing the contacts into the .txt file
        /// </summary>
        public void EditAddressBook()
        {
            if(File.Exists(path))
            {
                using (StreamWriter copyAddressBook = File.AppendText(path))
                {
                    foreach (AddressBook contact in AddressBook.Records)
                    {
                        count++;
                        copyAddressBook.WriteLine("**********\nCntact No: {0}\n***********", count);
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
        public static void WriteAddressBookCsv(AddressBook addressBook)
        {
            string path = @"C:\Users\prajv\source\repos\AddressBookDay13\AddressBook.csv";
            using (StreamWriter writer = new StreamWriter(path))
            {
                var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.Configuration.MemberTypes = CsvHelper.Configuration.MemberTypes.Fields;
                csv.WriteRecords(AddressBook.Records);
                writer.Close();
            }
        }
        public static void ReadAddressBookCsv()
        {
            string path = @"C:\Users\prajv\source\repos\AddressBookDay13\AddressBook.csv";
            var reader = new StreamReader(path);
            var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<AddressBook>().ToList();
            foreach(AddressBook contact in AddressBook.Records)
            {
                Console.WriteLine("FullName : " +contact.firstName+" "+contact.lastName);
            }
        }
    }
}
