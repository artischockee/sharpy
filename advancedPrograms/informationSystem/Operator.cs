using System;
using System.Collections.Generic;

namespace informationSystem
{
    internal struct DiscountsGrid
    {
        public int YearsOfUsage { get; }
        public int Discount { get; }

        public DiscountsGrid(int yearsOfUsage, int discount)
        {
            YearsOfUsage = yearsOfUsage;
            Discount = discount;
        }
    }

    internal struct Tariff
    {
        public string TariffName { get; }
        public double PricePerMonth { get; }

        public Tariff(string tariffName, double pricePerMonth)
        {
            TariffName = tariffName;
            PricePerMonth = pricePerMonth;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Tariff: \"{TariffName}\", price: {PricePerMonth}/month.");
        }
    }
    
    // This class describes an internet-operator, that
    // provides internet-services for its customers
    internal class Operator
    {
        // Fields:
        
        private readonly string _name;
        private List<Customer> _customers;
        private readonly List<Tariff> _tariffsList;
        private readonly List<DiscountsGrid> _discountsGrid;
        
        public List<Customer> Customers => _customers;

        // Constructors:
        
        public Operator(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            _name = name;
            _customers = new List<Customer>();
            
            _tariffsList = new List<Tariff>
            {
                new Tariff("Basic", 14.99),
                new Tariff("Online-30", 17.99),
                new Tariff("Online-50", 24.99),
                new Tariff("Online-100", 29.99),
                new Tariff("Unlimited", 49.99)
            };
            
            _discountsGrid = new List<DiscountsGrid>
            {
                new DiscountsGrid(3, 0),
                new DiscountsGrid(5, 5),
                new DiscountsGrid(8, 10),
                new DiscountsGrid(12, 15),
                new DiscountsGrid(-1, 20)
            };
        }
        
        // Methods:

        public void DisplayTariffs()
        {
            var index = 0;
            foreach (var tariff in _tariffsList)
                Console.WriteLine($"{++index}. {tariff.TariffName}. Price: {tariff.PricePerMonth}/month");
        }
        
        public void AddCustomer()
        {
            Console.WriteLine($"Adding a customer in {_name}'s database..");

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Date of birth (format: DD.MM.YYYY): ");
            var dob = Console.ReadLine();
            Console.Write("Address (city, disctrict, etc): ");
            var address = Console.ReadLine();
            Console.Write("Contacts (tel., email, fax, etc): ");
            var contacts = Console.ReadLine();
            Console.WriteLine("Choose on of the following tariffs:");
            DisplayTariffs();
            var tariffIndex = int.Parse(Console.ReadLine());
            if (tariffIndex < 1 || tariffIndex > _tariffsList.Count)
                throw new ArgumentOutOfRangeException(nameof(tariffIndex));
            var tariff = _tariffsList[tariffIndex - 1];
            
            _customers.Add(new IndividualCustomer(name, dob, address, contacts, tariff));
        }
    }
}