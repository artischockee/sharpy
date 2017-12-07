using System;
using System.Collections.Generic;

namespace informationSystem
{
    internal static class CustomersTypes
    {
        private static readonly List<Customer> List;

        static CustomersTypes()
        {
            List = new List<Customer>
            {
                new CorporateCustomer(),
                new IndividualCustomer()
            };
        }

        public static void Display()
        {
            var index = 0;
            foreach (var customer in List)
                Console.WriteLine($"{++index}. {customer.Type}");
        }
    }
    
    internal abstract class Customer
    {
        private const string CustomerType = "Customer (default)";
        public abstract string Type { get; }

        // Name is used both for individual and corporated customers.
        public abstract string Name { get; protected set; }

        public abstract string Address { get; protected set; }
        public abstract string Tariff { get; protected set; }
        public abstract string Contacts { get; protected set; }
        public abstract double Discount { get; protected set; }

        // Internet-operator provides discounts for clients
        // with big amount of usage's years
        public abstract int YearsOfUsage { get; protected set; }

        protected abstract void CalcDiscount();
    }
}