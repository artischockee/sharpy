using System;

namespace interfaces
{
    public class PartTimeStudent : Employee, IStudent
    {
        // Fields:

        private static int _amountOfObjects;
        
        private const int RequiredAge = 16;
        
        private readonly int _indexNumber;
        public override string Name { get; }
        
        private int _age;
        private string _placeOfWork;
        public string PlaceOfStudy { get; set; }

        // Properties:
        
        public static int AmountOfObjects => _amountOfObjects;
        public int IndexNumber => _indexNumber;

        // Constructors:

        static PartTimeStudent()
        {
            _amountOfObjects = 0;
        }

        public PartTimeStudent(string name, int age, string placeOfStudy, string placeOfWork = null)
        {
            if (name == null || placeOfStudy == null)
                throw new ArgumentNullException();
            if (age < RequiredAge)
                throw new ArgumentOutOfRangeException($"'Age' must be greater than {RequiredAge}");

            Name = name;
            _age = age;
            PlaceOfStudy = placeOfStudy;
            _placeOfWork = placeOfWork ?? "none";
            
            _indexNumber = _amountOfObjects++;
        }
        
        // Methods:
        
        public override void Work()
        {
            if (_placeOfWork != "none")
                Console.WriteLine($"Student {Name} is doing some work at {_placeOfWork}.");
        }

        public override string WriteReport()
        {
            if (_placeOfWork == "none")
                return null;
            
            var workReport = $"A work report written by employee {Name} (student).";
            return workReport;
        }

        public void Study()
        {
            Console.WriteLine($"Student {Name} is studying.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Info about part-time student:");
            Console.WriteLine($"> Name: {Name}, age: {_age};");
            Console.WriteLine($"> Place of study: {PlaceOfStudy}, job: {_placeOfWork}.");
        }
    }
}