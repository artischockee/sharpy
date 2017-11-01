using System;
using System.Collections.Generic;

namespace LW06T1
{
    public class InvalidSexException : Exception
    {
        public InvalidSexException(string message) : base(message) {}
    }

    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            List<Pet> Pets = new List<Pet>();
            try {
                Pets.Add(new Dog("Polkan", 'm', 24.22, 48.1));
                Pets.Add(new Cat("Dribble", 'm', 15.69, 30.12));
                Pets.Add(new Parrot("Kesha", 'm', 2.34, 26));
                Pets.Add(new Cat("Tabitha", 'f', 16.6, 29.45));
                Pets.Add(new Dog("Boxer", 'm', 26.15, 49.01));
            }
            catch (InvalidSexException e) {
                Console.WriteLine(e.Message);
            }

            foreach (var pet in Pets) {
                pet.Action();
                Console.WriteLine();
            }

            // Console.ReadLine(); // in case of running on Windows
        }
    }
}
