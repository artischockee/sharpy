using System;

namespace informationSystem
{
    internal sealed class CorporateCustomer : Customer
    {
        private const string CustomerType = "Corporate customer";
        private static int _amountOfObjects;
        
        public override string Name { get; protected set; }
        public override string Address { get; protected set; }
        public override string Tariff { get; protected set; }
        public override string Contacts { get; protected set; }
        public override double Discount { get; protected set; }
        public override int YearsOfUsage { get; protected set; }

        public override string Type => CustomerType;

        private readonly int _customerId;
        
        static CorporateCustomer()
        {
            _amountOfObjects = 0;
        }

        public CorporateCustomer()
        {
            Name = "null";
            Address = "null";
            Tariff = "null";
            Contacts = "null";
            Discount = 0;
            YearsOfUsage = 0;

            _customerId = _amountOfObjects;
        }

        public CorporateCustomer(
            string name, string address, string tariff, string contacts, int you = 0)
        {
            if (name == null || address == null || tariff == null || contacts == null)
                throw new ArgumentNullException("CorporateCustomer (Constructor): One of the args was empty.");
            if (you < 0)
                throw new ArgumentOutOfRangeException(nameof(you));

            Name = name;
            Address = address;
            Tariff = tariff;
            Contacts = contacts;
            YearsOfUsage = you;
            
            CalcDiscount();
            
            _customerId = ++_amountOfObjects;
        }
        
        protected override void CalcDiscount()
        {
            if (YearsOfUsage < 3)
                Discount = 0;
            else if (YearsOfUsage < 6)
                Discount = 5;
            else if (YearsOfUsage < 10)
                Discount = 10;
            else if (YearsOfUsage < 15)
                Discount = 15;
            else
                Discount = 20;
        }
    }
}