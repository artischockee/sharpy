using System;

namespace Events
{
    internal class Product : Detail, IMovable, ISellable
    {
        private readonly string _manufacturer;

        public Product(string name, string manufacturer, double size, double weight)
            : base(name, size, weight)
        {
            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(manufacturer))
                throw new ArgumentNullException();
            if (size <= 0 || weight <= 0)
                throw new ArgumentOutOfRangeException();

            _manufacturer = manufacturer;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"As Product: Manufacturer\'s name: {_manufacturer}.");
        }

        public void MoveOnAxisX(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Product \'{Name}\' has been moved on {distance}m along X axis.");
        }

        public void MoveOnAxisY(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Product \'{Name}\' has been moved on {distance}m along Y axis.");
        }

        public void MoveOnAxisZ(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Product \'{Name}\' has been moved on {distance}m along Z axis.");
        }

        public double Sell()
        {
            Console.WriteLine("How much do you want for this product?");
            var wantedPayment = double.Parse(Console.ReadLine());
            
            return wantedPayment;
        }

        public object Pledge()
        {
            Console.WriteLine("What do you want take from the customer for this product?");
            var wantedGoods = Console.ReadLine();
            
            return wantedGoods;
        }
    }
}