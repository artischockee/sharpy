using System;

namespace interfaces
{
    public sealed class Turner : Employee
    {
        // Fields:
        
        private static int _amountOfObjects;
        
        private const int RequiredAge = 18;
        private const int LowerCategory = 2;
        private const int HigherCategory = 6;
        
        private readonly int _indexNumber;
        public override string Name { get; }
        
        private int _age;
        private int _category;
        
        // Properties:
        
        public static int AmountOfObjects => _amountOfObjects;
        public int IndexNumber => _indexNumber;

        // Constructors:
        
        static Turner()
        {
            _amountOfObjects = 0;
        }
        
        public Turner(string name, int age, int category = LowerCategory)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (age < RequiredAge)
                throw new ArgumentOutOfRangeException(
                    $"'Age' must be greater than {RequiredAge} or equal");
            if (category < LowerCategory || category > HigherCategory)
                throw new ArgumentOutOfRangeException(
                    $"'Category' must be in range from {LowerCategory} to {HigherCategory}");

            Name = name;
            _age = age;
            _category = category;
            
            _indexNumber = _amountOfObjects++;
        }
        
        // Methods:
        
        public override void Work()
        {
            Console.WriteLine($"Turner {Name} is doing some work.");
        }
        
        public override void DisplayInfo()
        {
            Console.WriteLine("Info about turner:");
            Console.WriteLine($"> Name: {Name}, age: {_age}, category: {_category}.");
        }
    }
}