using System;

namespace interfaces
{
    public class PartTimeStudent : Employee, IStudent
    {
        // Fields:

        private static int _amountOfObjects;
        private readonly string _name;
        private readonly string _surname;
        private readonly int _indexNumber;
        private const int RequiredAge = 16;
        private int _age;
        private string _placeOfWork;
        private string _placeOfStudy;
        
        // Properties:
        
        public static int AmountOfObjects => _amountOfObjects;
        public int IndexNumber => _indexNumber;
        public string PlaceOfStudy
        {
            get { return _placeOfStudy; }
            set { _placeOfStudy = value; }
        }

        // Constructors:

        static PartTimeStudent()
        {
            _amountOfObjects = 0;
        }

        public PartTimeStudent(string fullName, int age, string placeOfStudy, string placeOfWork = null)
        {
            if (fullName == null || placeOfStudy == null)
                throw new ArgumentNullException();
            if (age < RequiredAge)
                throw new ArgumentOutOfRangeException($"'Age' must be greater than {RequiredAge}");

            var name = fullName.Split();
            _name = name[0];
            _surname = name[1];
            _age = age;
            _placeOfStudy = placeOfStudy;
            _placeOfWork = placeOfWork ?? "none";
            
            _indexNumber = _amountOfObjects++;
        }
        
        // Methods:
        
        public override void Work()
        {
            if (_placeOfWork != "none")
                Console.WriteLine($"Student {_name} {_surname} is doing some work at {_placeOfWork}");
        }

        public override string WriteReport()
        {
            var workReport = $"A work report written by employee {_name} {_surname} (student)";
            return workReport;
        }

        public void Study()
        {
            Console.WriteLine($"Student {_name} {_surname} is studying.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Info about part-time student:");
            Console.WriteLine($"> Name: {_name} {_surname}, age: {_age},");
            Console.WriteLine($">  place of study: {_placeOfStudy}, job: {_placeOfWork}");
        }
    }
}