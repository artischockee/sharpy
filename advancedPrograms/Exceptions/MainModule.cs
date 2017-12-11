using System;

namespace Exceptions
{
    internal static class MainModule
    {
        public static void Main(string[] args)
        {
            try
            {
                var collection = new Collection();
                collection.Display();
            
                Console.Write("Type number of program: ");
                var chosenProgram = Console.ReadLine();
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