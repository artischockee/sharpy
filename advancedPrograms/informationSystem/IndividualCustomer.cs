using System;

namespace informationSystem
{
    internal sealed class IndividualCustomer : Customer
    {
        private const string CustomerType = "Individual customer";
        private static int _amountOfObjects;
        
        public override string Name { get; protected set; }
        public override string Tariff { get; protected set; }
        public override double Discount { get; protected set; }
        public override int YearsOfUsage { get; protected set; }
        
        public override string Type => CustomerType;

        private readonly string _dateOfBirth;
        private readonly int _customerId;

        static IndividualCustomer()
        {
            _amountOfObjects = 0;
        }
        
        public IndividualCustomer()
        {
            Name = "null";
            Tariff = "null";
            Discount = 0;
            YearsOfUsage = 0;
            _dateOfBirth = "null";

            _customerId = _amountOfObjects;
        }
        
        public IndividualCustomer(
            string name, string tariff, string dob, int you = 0)
        {
            if (name == null || tariff == null || dob == null)
                throw new ArgumentNullException("IndividualCustomer (Constructor): One of the args was empty.");
            if (you < 0)
                throw new ArgumentOutOfRangeException(nameof(you));

            Name = name;
            Tariff = tariff;
            YearsOfUsage = you;
            _dateOfBirth = dob;
            
            CalcDiscount();

            _customerId = ++_amountOfObjects;
        }

        protected override void CalcDiscount()
        {
            if (YearsOfUsage < 3)
                Discount = 0;
            else if (YearsOfUsage < 5)
                Discount = 5;
            else if (YearsOfUsage < 8)
                Discount = 10;
            else if (YearsOfUsage < 12)
                Discount = 15;
            else
                Discount = 20;
        }
    }
}