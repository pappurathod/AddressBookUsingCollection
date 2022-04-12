
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;
using CsvHelper.Configuration;
using System.Globalization;

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
        /// <summary>
        /// UC8:
        /// </summary>
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
        /// <summary>
        /// UC9:
        /// </summary>
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
        /// <summary>
        /// UC10:
        /// </summary>
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
        /// <summary>
        /// UC13:Ability to Read or Write the Address Book with Persons Contact into a File using File IO
        /// </summary>
        public void ReadAddressBookFromFile()
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
                        
                    }
                }
            }
        }
        /// <summary>
        /// UC14:Ability to Read/Write the Address Book with Persons Contact as CSV File
        /// </summary>
        public void WriteAddressBookCollectionToCSVFiles()
        {
            string folderPath = @"C:\Users\Pappu Rathod\source\repos\AddressBookUsingCollection\CSVFiles\";
            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IncludePrivateMembers = true,
            };
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".csv";
                using (StreamWriter writer = new StreamWriter(filePath))
                using (var csvExport = new CsvWriter(writer, configuration))
                {
                    csvExport.WriteHeader<Person>();
                    csvExport.NextRecord();
                    foreach (Person person in AddressBookItem.Value.addressBook)
                    {
                        csvExport.WriteField($"{person.firstName}");
                        csvExport.WriteField($"{person.lastName}");
                        csvExport.WriteField($"{person.address}");
                        csvExport.WriteField($"{person.city}");
                        csvExport.WriteField($"{person.state}");
                        csvExport.WriteField($"{person.zip}");
                        csvExport.WriteField($"{person.phoneNumber}");
                        csvExport.WriteField($"{person.email}");
                        csvExport.NextRecord();
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
                    string lines ="";
                    while ((lines = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(lines);
                    }
                }
            }        
        }
        /// <summary>
        /// UC15:Ability to Read or Write the Address Book with Persons Contact as JSON File
        /// </summary>
        public void WriteAddressBookCollectionFromJsonFiles()
        {
            string folderPath = @"C:\Users\Pappu Rathod\source\repos\AddressBookUsingCollection\JsonFiles\";
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".json";
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter writer = new StreamWriter(filePath))
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(writer, AddressBookItem.Value.addressBook);
                }
            }
        }
        public void ReadAddressBookCollectionFromJsonFiles()
        {
            string folderPath = @"C:\Users\Pappu Rathod\source\repos\AddressBookUsingCollection\JsonFiles\Student.json";
            string result = File.ReadAllText(folderPath);
            List<Person> contactDetails = JsonConvert.DeserializeObject<List<Person>>(result);
            Console.WriteLine("Successfully read records from the file" + contactDetails);
            //Console.WriteLine(result);
        }
    }
}