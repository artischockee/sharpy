using System;

namespace mathLogic
{
    public static class MainModule
    {
        public static void Main()
        {
            try
            {
                var collection = new Collection();
                collection.Display();
                
                Console.WriteLine("Type number of program: ");
                var chosenProgram = int.Parse(Console.ReadLine());
                collection.Execute(chosenProgram);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}