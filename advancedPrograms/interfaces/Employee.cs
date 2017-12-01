using System;
using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace interfaces
{
    public delegate void Sort(List<Employee> list);
    
    public abstract class Employee
    {
        public abstract string Name { get; }
        public abstract void Work();
        public abstract string WriteReport();

        public static void SortTurnersByName(List<Employee> list)
        {
            var turners = list.Where(person => person is Turner).ToList();

            turners.Sort((employee1, employee2) => CompareOrdinal(employee1.Name, employee2.Name));
            
            foreach (var person in turners)
                Console.WriteLine(person.Name);
        }
    }
}