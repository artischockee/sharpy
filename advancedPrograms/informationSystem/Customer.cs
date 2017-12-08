namespace informationSystem
{
    internal abstract class Customer
    {
        // Abstract properties:

        public abstract string Name { get; }
        public abstract string Address { get; }
        public abstract string Contacts { get; }
        public abstract int YearsOfUsage { get; }
        public abstract Tariff CurrentTariff { get; }
        protected abstract double Discount { get; set; }
        public abstract double MonthlyPayment { get; }

        // Abstract methods:
        
        public abstract void DisplayInfo();
    }
}