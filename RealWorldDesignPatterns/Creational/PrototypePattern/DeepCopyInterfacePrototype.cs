using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Creational.PrototypePattern
{
    public class DeepCopyInterfacePrototype
    {
        public class Address : IPrototype<Address>
        {
            public string Street, Number;

            public Address(string street, string number)
            {
                Street = street;
                Number = number;
            }
            public Address(Address other)
            {
                Street = other.Street;
                Number = other.Number;
            }

            public Address DeepCopy()
            {
                return new Address(Street, Number);
            }
        }
        public class Person : IPrototype<Person>
        {
            public string Name, Position;
            public Address Address;

            public Person(string name, string position, Address address)
            {
                Name = name;
                Position = position;
                Address = address;  
            }

            public Person(Person other)
            {
                Name = other.Name;
                Position = other.Position;
                Address = new Address(other.Address);
            }

            public Person DeepCopy()
            {
                return new Person(Name, Position, Address.DeepCopy());
            }
        }

        public interface IPrototype<out T>
        {
            T DeepCopy();
        }
    }

}
