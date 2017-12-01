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
        private readonly string _name;
        private readonly string _surname;
        
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
        
        public Turner(string fullName, int age, int category = 2)
        {
            if (fullName == null)
                throw new ArgumentNullException();
            if (age < RequiredAge)
                throw new ArgumentOutOfRangeException($"'Age' must be greater than {RequiredAge}");
            if (category < LowerCategory || category > HigherCategory)
                throw new ArgumentOutOfRangeException(
                    $"'Category' must be in range from {LowerCategory} to {HigherCategory}"
                );

            var name = fullName.Split();
            _name = name[0];
            _surname = name[1];
            _age = age;
            _category = category;
            
            _indexNumber = _amountOfObjects++;
        }
        
        // Methods:
        
        public override void Work()
        {
            Console.WriteLine($"Turner {_surname} is doing some work.");
        }
        
        public override string WriteReport()
        {
            var workReport = $"A work report written by employee {_name} {_surname} (turner)";
            return workReport;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine("Info about turner:");
            Console.WriteLine($"> Name: {_name} {_surname}, age: {_age}, category: {_category}.");
        }
    }
}