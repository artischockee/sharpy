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
        private string PlaceOfWork { get; }
        public string PlaceOfStudy { get; set; }

        // Properties:
        
        public static int AmountOfObjects => _amountOfObjects;
        public int IndexNumber => _indexNumber;

        // Constructors:

        static PartTimeStudent()
        {
            _amountOfObjects = 0;
        }

        public PartTimeStudent(string name, int age, string placeOfStudy, string placeOfWork)
        {
            if (name == null || placeOfStudy == null || placeOfWork == null)
                throw new ArgumentNullException();
            if (age < RequiredAge)
                throw new ArgumentOutOfRangeException($"'Age' must be greater than {RequiredAge}");

            Name = name;
            _age = age;
            PlaceOfWork = placeOfWork;
            PlaceOfStudy = placeOfStudy;
            
            _indexNumber = _amountOfObjects++;
        }
        
        // Methods:
        
        public override void Work()
        {
            Console.WriteLine($"Student {Name} is doing some work at {PlaceOfWork}.");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Info about part-time student:");
            Console.WriteLine($"> Name: {Name}, age: {_age};");
            Console.WriteLine($"> Place of study: {PlaceOfStudy}, job: {PlaceOfWork}.");
        }
        
        public void Study()
        {
            Console.WriteLine($"Student {Name} is studying.");
        }
    }
}