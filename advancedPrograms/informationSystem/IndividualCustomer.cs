using System;

namespace informationSystem
{
    internal sealed class IndividualCustomer : Customer, IAutoCounter
    {
        // Fields:
        
        public static int AmountOfObjects { get; private set; }

        private readonly int _customerIdentifier;
        private readonly string _dateOfBirth;
        
        // Properties:

        public override string Name { get; }
        public override string Address { get; }
        public override string Contacts { get; }
        public override Tariff CurrentTariff { get; }
        public override int YearsOfUsage { get; }
        protected override double Discount { get; set; }
        public override double MonthlyPayment { get; }

        // Constructors:

        static IndividualCustomer()
        {
            AmountOfObjects = 0;
        }
        
        public IndividualCustomer(
            string name, string dob, string address,
            string contacts, Tariff tariff, int you = 0)
        {
            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(dob)
                || string.IsNullOrEmpty(address)
                || string.IsNullOrEmpty(contacts))
                throw new ArgumentNullException("ArgNullException in IndividualCustomer's constructor.");
            if (you < 0)
                throw new ArgumentOutOfRangeException();

            Name = name;
            _dateOfBirth = dob;
            Address = address;
            Contacts = contacts;
            CurrentTariff = tariff;
            YearsOfUsage = you;

            if (YearsOfUsage == 0)
                Discount = 0.0;

            if (Discount != 0)
            {
                var percent = Discount / 100;
                MonthlyPayment = CurrentTariff.PricePerMonth * percent;
            }
            else
                MonthlyPayment = CurrentTariff.PricePerMonth;
            
            _customerIdentifier = ++AmountOfObjects;
        }
        
        public override void DisplayInfo()
        {
            Console.WriteLine("Info about individual customer:");
            Console.WriteLine($"ID: {_customerIdentifier}, Name: {Name}, DoB: {_dateOfBirth};");
            Console.WriteLine($"Address: {Address};");
            Console.WriteLine($"Contacts: {Contacts};");
            CurrentTariff.DisplayInfo();
            Console.WriteLine($"Years of usage: {YearsOfUsage}, discount: {Discount};");
            Console.WriteLine($"Total monthly payment: {MonthlyPayment}");
        }

        private void CalculateDiscount(Customer client)
        {
            
        }
    }
}