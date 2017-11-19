using System;
using System.Collections.Generic;

namespace interfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var students = new List<PartTimeStudent>
            {
                new PartTimeStudent("Tony Stark", 52, "MIT"),
                new PartTimeStudent("Artem Piskarev", 19, "TUCSR", "KFC"),
                new PartTimeStudent("Irina Iost", 18, "TPU", "Google")
            };

            foreach (var student in students)
            {
                student.DisplayInfo();
                student.Study();
                student.Work();
            }
            
            
        }
    }
}