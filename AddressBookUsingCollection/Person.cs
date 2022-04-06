using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingCollection
{
    public class Person
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string phoneNumber;
        public string email;

        public override bool Equals(object obj)
        {            
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Person))
            {
                return false;
            }
            return (this.firstName == ((Person)obj).firstName) && (this.lastName == ((Person)obj).lastName);
        }
        public void DisplayPerson()
        {
            Console.WriteLine("First Name :" + firstName);
            Console.WriteLine("Last Name :" + lastName);
            Console.WriteLine("Address :" + address);
            Console.WriteLine("City : " + city);
            Console.WriteLine("State : " + state);
            Console.WriteLine("Zip :" + zip);
            Console.WriteLine("PhoneNumber :" + phoneNumber);
            Console.WriteLine("Email :" + email);
        }
    }
}