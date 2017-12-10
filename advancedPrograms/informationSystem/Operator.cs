using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace informationSystem
{
    internal struct DiscountsGrid
    {
        public const int GreaterUsage = -1;
        
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
        /*
        public void DisplayInfo()
        {
            Console.WriteLine($"Tariff: \"{TariffName}\", price: {PricePerMonth}/month.");
        }
        */
    }
    
    // This class describes an internet-operator, that
    // provides internet-services for its customers
    internal class Operator : IAutoCounter
    {
        // Fields:
        
        private readonly string _name;
        private List<Customer> _customers;
        private readonly List<Tariff> _tariffsList;
        private readonly List<DiscountsGrid> _discountsGrid;
        
        public List<Customer> Customers => _customers;
        public List<Tariff> TariffsList => _tariffsList;

        // Constructors:
        
        public Operator(string operatorName)
        {
            if (string.IsNullOrEmpty(operatorName))
                throw new ArgumentNullException(nameof(operatorName));

            _name = operatorName;
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
                new DiscountsGrid(DiscountsGrid.GreaterUsage, 20)
            };
            
            if (_discountsGrid.Last().YearsOfUsage != DiscountsGrid.GreaterUsage)
                throw new DataException($"Last row of discount grid (operator \'{_name}\' does not have " +
                                        $"GreaterUsage const var (value = {DiscountsGrid.GreaterUsage}) " +
                                        "as \'YearsOfUsage\' field. Please check it out.");
        }
        
        // Methods:

        public void DisplayTariffs()
        {
            var index = 0;
            foreach (var tariff in _tariffsList)
                Console.WriteLine($"{++index}. \"{tariff.TariffName}\"; Price: ${tariff.PricePerMonth} per month");
        }

        public void AddCustomer()
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"Adding a customer in {_name}'s database.");

            Console.Write("Name: ");
            var name = Console.ReadLine();
            
            Console.Write("Date of birth (format: DD.MM.YYYY): ");
            var dob = Console.ReadLine();
            
            Console.Write("Address (city, for example): ");
            var address = Console.ReadLine();
            
            Console.WriteLine("Choose one of the following tariffs:");
            DisplayTariffs();
            var tariffIndex = int.Parse(Console.ReadLine());
            if (tariffIndex < 1 || tariffIndex > _tariffsList.Count)
                throw new ArgumentOutOfRangeException(nameof(tariffIndex));
            var tariff = _tariffsList[tariffIndex - 1];
            
            Console.Write("[Optional] Years of usage (default = 0): ");
            var you = int.Parse(Console.ReadLine());
            
            _customers.Add(new IndividualCustomer(name, dob, address, tariff, you));
            CalculateDiscount(_customers.Last());
        }

        public double CalculateSummaryPayments()
        {
            return _customers.Sum(client => client.MonthlyPayment);
        }

        public void CalculateDiscount(Customer client)
        {
            foreach (var row in _discountsGrid)
            {
                if (client.YearsOfUsage >= row.YearsOfUsage
                    && row.YearsOfUsage != DiscountsGrid.GreaterUsage)
                    continue;

                client.SetDiscount(row.Discount);
                break;
            }
            
        }
    }
}