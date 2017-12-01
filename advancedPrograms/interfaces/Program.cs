using System;
using System.Collections.Generic;

namespace interfaces
{
    public static class Program
    {
        private static void Experiment()
        {
            var employees = new List<Employee>
            {
                new Turner("John Travolta", 63, 6),
                new Turner("Anthony Stark", 52, 3),
                new PartTimeStudent("Jack Sparrow", 53, "Oxford University", "Hollywood"),
                new PartTimeStudent("Keanu Reeves", 53, "KIPTSU", "KIPTSU"),
                new Turner("Bruce Willis", 62),
                new Turner("Christopher Nolan", 47),
                new PartTimeStudent("Vladimir Putin", 65, "S-Petersburg State University", "Kremlin"),
                new Turner("Arnold Schwarzenegger", 70, 6)
            };

            foreach (var employee in employees)
            {
                employee.DisplayInfo();
                employee.Work();
            }

            Sort sortTurners = Employee.SortTurnersByName;
            sortTurners(employees);
        }
        
        public static void Main(string[] args)
        {
            try
            {
                Experiment();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}