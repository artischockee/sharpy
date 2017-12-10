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
                
                for (var i = 0; i < 3; ++i)
                    provider.AddCustomer();
                foreach (var client in provider.Customers)
                    client.DisplayInfo();

                Console.WriteLine($"Total payments of this month: ${provider.CalculateSummaryPayments()}");
                
                Console.WriteLine("Program has been completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}