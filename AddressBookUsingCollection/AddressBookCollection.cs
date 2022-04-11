//using CsvHelper;
//using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace AddressBookUsingCollection
{
    class AddressBookCollection
    {
        public Dictionary<string, AddressBook> addressBookDictionary;//Dictionary collection
        public Dictionary<string, List<Person>> cityDictionary;
        public Dictionary<string, List<Person>> stateDictionary;

        public AddressBookCollection()
        {
            addressBookDictionary = new Dictionary<string, AddressBook>();
        }
        public void PrintAllAddressBookNames()
        {
            foreach (var AddressBookItem in addressBookDictionary)
            {
                Console.WriteLine(AddressBookItem.Key);
            }
        }
        public void SearchPersonInCityOrState(string firstName, string lastName)
        {
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> PersonInCitiesOrStates = addressBookEntry.Value.addressBook.FindAll(i => (i.firstName == firstName) && (i.lastName == lastName));
                foreach (Person person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.firstName} {person.lastName} is in {person.city} {person.state}");
                }
            }
        }
        public void ViewPersonByCityOrState(string city, string state)
        {
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> PersonInCitiesOrStates = addressBookEntry.Value.addressBook.FindAll(i => (i.city == city) && (i.state == state));
                foreach (Person person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.city} {person.state} is in {person.city} {person.state}");
                }
            }
        }
        public void ViewCountByCityOrState(string city, string state)
        {
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> ViewCountByCityOrState = addressBookEntry.Value.addressBook.FindAll(i => (i.city == city) && (i.state==state));
                foreach (Person person in ViewCountByCityOrState)
                {
                    Console.WriteLine($"Total person in {city} are : " + ViewCountByCityOrState.Count);
                }
            }            
        }
        
        public  void ReadAddressBookFromFile()
        {
            string filePath = @"C:\Users\Pappu Rathod\source\repos\AddressBookUsingCollection\Files\Employee.txt";
            if (File.Exists(filePath))
            {
                string output = File.ReadAllText(filePath);
                Console.WriteLine(output);
            }
            else
                Console.WriteLine("file don't exist");           
        }
        public void WriteAddressBookCollectionToFiles()
        {
            string folderPath = @"C:\Users\Pappu Rathod\source\repos\AddressBookUsingCollection\Files\";
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Person person in AddressBookItem.Value.addressBook)
                    {
                        writer.WriteLine($"First Name : {person.firstName}");
                        writer.WriteLine($"Last Name : {person.lastName}");
                        writer.WriteLine($"Address : {person.address}");
                        writer.WriteLine($"City : {person.city}");
                        writer.WriteLine($"State : {person.state}");
                        writer.WriteLine($"Zip : {person.zip}");
                        writer.WriteLine($"PhoneNumber : {person.phoneNumber}");
                        writer.WriteLine($"Email : {person.email}");
                        writer.WriteLine("------------------------");
                    }
                }
            }
        }

        public void WriteAddressBookCollectionToCSVFiles()
        {
            string filePath = @"C:\Users\Pappu Rathod\source\repos\AddressBookUsingCollection\CSVFiles\data.csv";

            foreach (var AddressBookItem in addressBookDictionary)
            {
                using (var writer = new StreamWriter(filePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (Person person in AddressBookItem.Value.addressBook)
                    {
                        writer.WriteLine($"First Name : {person.firstName}");
                        writer.WriteLine($"Last Name : {person.lastName}");
                        writer.WriteLine($"Address : {person.address}");
                        writer.WriteLine($"City : {person.city}");
                        writer.WriteLine($"State : {person.state}");
                        writer.WriteLine($"Zip : {person.zip}");
                        writer.WriteLine($"PhoneNumber : {person.phoneNumber}");
                        writer.WriteLine($"Email : {person.email}");
                    }
                }
            }
        }
        public void ReadAddressBookCollectionFromCSVFiles()
        {                
            string filePath = @"C:\Users\Pappu Rathod\source\repos\AddressBookUsingCollection\CSVFiles\";
            string[] filePaths = Directory.GetFiles(filePath, "*.csv");
            foreach (var presentFiles in filePaths)
            {
                using (StreamReader streamReader = File.OpenText(presentFiles))
                {
                    string lines = "";
                    while ((lines = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(lines);
                    }
                }
            }        
        }        
    }
}

