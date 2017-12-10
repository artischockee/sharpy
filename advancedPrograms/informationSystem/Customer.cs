using System;

namespace informationSystem
{
    internal abstract class Customer : IDiscountAccessor
    {
        // Fields (auto-properties):
        
        public string Address { get; protected set; }
        public int YearsOfUsage { get; protected set; }
        public Tariff Tariff { get; protected set; }
        public double Discount { get; protected set; }
        public double MonthlyPayment { get; protected set; }

        // Constructor:

        protected Customer(
            string address, int yearsOfUsage, Tariff tariff)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (yearsOfUsage < 0)
                throw new ArgumentOutOfRangeException(nameof(yearsOfUsage));

            Address = address;
            YearsOfUsage = yearsOfUsage;
            Tariff = tariff;
        }
        
        // Methods:
        
        public void SetDiscount(double discount)
        {
            if (discount < 0 || discount > 100)
                throw new ArgumentOutOfRangeException();
            
            Discount = discount;
            MonthlyPayment = Discount == 0
                ? Tariff.PricePerMonth
                : Tariff.PricePerMonth * ((100 - discount) / 100);
        }
        
        // Virtual methods:

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Address: {Address}.");
            Console.WriteLine($"Years of usage: {YearsOfUsage}; Tariff: {Tariff.TariffName}.");
            Console.WriteLine($"Monthly payment: ${MonthlyPayment} ({Discount}% of discount).");
        }
    }
}