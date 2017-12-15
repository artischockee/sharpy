using System;

namespace Exceptions
{
    internal static class MainModule
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("(9th lab) Exceptions." + '\n');
                var collection = new Collection();
                collection.Display();
            
                Console.Write("Type number of program: ");
                var chosenProgram = Console.ReadLine();
                Console.ReadKey();
                if (string.IsNullOrEmpty(chosenProgram))
                    throw new Exception();
            
                collection.Execute(int.Parse(chosenProgram));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}