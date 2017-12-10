using System;

namespace informationSystem
{
    internal sealed class IndividualCustomer : Customer
    {
        // Fields:

        private const int RegionNumber = 70;

        private static int _amountOfObjects;
        private readonly string _customerIdentifier;
        private readonly string _name;
        private readonly string _dateOfBirth;
        
        // Constructors:

        static IndividualCustomer()
        {
            _amountOfObjects = 0;
        }
        
        public IndividualCustomer(
            string name, string dateOfBirth, string address, Tariff tariff, int yearsOfUsage = 0)
            : base (address, yearsOfUsage, tariff)
        {
            _name = name;
            _dateOfBirth = dateOfBirth;
            
            ++_amountOfObjects;

            var letters = GetFirstLettersOfName(name);
            var uniqueID = _amountOfObjects.ToString().PadLeft(8, '0');

            _customerIdentifier = string.Concat(RegionNumber, letters[0], letters[1], uniqueID);
        }
        
        public override void DisplayInfo()
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("Information about individual customer:");
            Console.WriteLine($"Identificator: {_customerIdentifier}.");
            Console.WriteLine($"Name: {_name}; Birth date: {_dateOfBirth}.");
            base.DisplayInfo();
            Console.WriteLine(new string('=', 80));
        }

        public override void SetDiscount(double discount)
        {
            if (discount < 0 || discount > 100)
                throw new ArgumentOutOfRangeException();
            
            Discount = discount;
            MonthlyPayment = Math.Abs(Discount) < 0
                ? Tariff.PricePerMonth
                : Tariff.PricePerMonth * (discount / 100);
        }

        private static char[] GetFirstLettersOfName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            
            var splitted = name.Split();
            if (splitted.Length < 2)
                throw new Exception();

            return new[] {splitted[0][0], splitted[1][0]};
        }
    }
}