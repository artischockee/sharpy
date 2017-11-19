using System;
using System.Collections.Generic;

namespace interfaces
{
    public static class Test
    {
        public static void Experiment()
        {
            var employees = new List<Employee>
            {
                new Turner("John Travolta", 63, 6),
                new Turner("Anthony Stark", 52, 3),
                new PartTimeStudent("Jack Sparrow", 53, "Oxford University", "Hollywood"),
                new PartTimeStudent("Keanu Reeves", 53, "КИПТСУ"),
                new Turner("Bruce Willis", 62)
            };

            foreach (var employee in employees)
            {
                employee.Work();
                Console.WriteLine(employee.WriteReport());
            }
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Test.Experiment();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}