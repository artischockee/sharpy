using System;

namespace informationSystem
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var provider = new Operator("Qwertynet");
                provider.AddCustomer();

                foreach (var client in provider.Customers)
                {
                    client.DisplayInfo();
                }
                
                Console.WriteLine("Program has been completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}