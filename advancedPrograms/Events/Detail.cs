using System;

namespace Events
{
    internal class Detail
    {
        public string Name { get; protected set; }
        public double Size { get; protected set; }
        public double Weight { get; protected set; }
        
        public Detail(string name, double size, double weight)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (size <= 0 || weight <= 0)
                throw new ArgumentOutOfRangeException();
            
            Name = name;
            Size = size;
            Weight = weight;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Detail \'{Name}\'. Size: {Size}, weight: {Weight}kg.");
        }
    }
}