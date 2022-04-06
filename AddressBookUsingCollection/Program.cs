using System;

namespace AddressBookUsingCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Address Book!");
            Console.WriteLine("Enter Address Book Name");
            string addressBookName = Console.ReadLine();
            AddressBookCollection addressBookCollection = new AddressBookCollection();
            AddressBook addressBook = new AddressBook();
            addressBookCollection.addressBookDictionary.Add(addressBookName, addressBook);
            int choice;
            do
            {
                Console.WriteLine("Enter Choice:");
                Console.WriteLine("1) Display All Contact");
                Console.WriteLine("2) Add new Contact");
                Console.WriteLine("3) Edit Contact");
                Console.WriteLine("4) Delete Contact");
                Console.WriteLine("5) Add New Address Book");
                Console.WriteLine("6) List of all Address Book");
                Console.WriteLine("7) Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBookCollection.addressBookDictionary[addressBookName].DisplayNamesInAddresBook();
                        break;
                    case 2:
                        addressBookCollection.addressBookDictionary[addressBookName].AddAddressBookEntry();
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        string lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].EditContact(firstName, lastName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].DeleteContact(firstName, lastName);
                        break;
                    case 5:
                        Console.WriteLine("Enter New Address Book Name");
                        addressBookName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary.Add(addressBookName, new AddressBook());
                        Console.WriteLine("Address Book selected: " + addressBookName);
                        break;
                    case 6:
                        Console.WriteLine("Listing all Address Books");
                        foreach (var addressBookEntry in addressBookCollection.addressBookDictionary)
                        {
                            Console.WriteLine(addressBookEntry.Key);
                        }
                        Console.WriteLine("Select an Address Book");
                        addressBookName = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBookCollection.SearchPersonInCityOrState(firstName, lastName);
                        break;
                    default:
                        Console.WriteLine("Thank you!!!!!!!!!");
                        break;
                }
            } while (choice != 8);


        }
    }
}

