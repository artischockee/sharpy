using System;
using System.Collections.Generic;

namespace informationSystem
{
    // This class describes an internet-operator, that
    // provides internet-services for its customers
    internal class Operator
    {
        private readonly string _name;
        private List<Customer> _customers;
        private List<string> _tariffsList;

        public Operator(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            _name = name;
            _customers = new List<Customer>();
            _tariffsList = new List<string>
            {
                "Basic",
                "Online-30",
                "Online-50",
                "Online-100",
                "Unlimited"
            };
        }

        public void DisplayTariffs()
        {
            var index = 0;
            foreach (var tariff in _tariffsList)
                Console.WriteLine($"{++index}. {tariff}");
        }

        private void CustomerCreating()
        {
            string name, address, tariff, contacts;
            
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Address (city, district, building) : ");
            address = Console.ReadLine();
            Console.Write("Choose on of the following tariffs");
            
            
//            tariff = Console.ReadLine();
            Console.Write("Contacts (tel., email, fax, etc): ");
            contacts = Console.ReadLine();
        }

        public void AddCustomer()
        {
            Console.WriteLine($"Adding a customer in {_name}'s database..");
            Console.WriteLine("Choose a customer type:");
            CustomersTypes.Display();

            Console.Write("> ");
            var answer = Console.ReadLine();
            if (string.IsNullOrEmpty(answer))
                throw new Exception();
            
        }
    }
}