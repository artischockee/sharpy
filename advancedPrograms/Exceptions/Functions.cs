using System;

namespace Exceptions
{
    public class BadSqrtException : Exception
    {
        public BadSqrtException(string message = null) : base(message)
        {}
    }

    internal static class Calculation
    {
        private static double z;
        
        public static double ZedOne(ref double x)
        {
            try
            {
                var sameSqrtExp = Math.Pow(x, 2) - 9;
                if (sameSqrtExp < 0)
                    throw new BadSqrtException("Sqrt expression cannot be negative.");
                
                var sameSqrt = Math.Sqrt(sameSqrtExp);
                
                var numerator = (x + 1) * sameSqrt + x * (x + 2) - 3;
                var denominator = (x - 1) * sameSqrt + Math.Pow(x, 2) - 2 * x - 3;
                
                if (denominator == 0)
                    throw new DivideByZeroException("Attempt to divide by zero.");

                z = numerator / denominator;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Function will return 0");
                return 0;
            }

            return z;
        }
        
        public static double ZedTwo(ref double x)
        {
            try
            {
                var numerator = x + 3;
                var denominator = x - 3;

                if (denominator == 0)
                    throw new DivideByZeroException("Attempt to divide by zero.");

                var division = numerator / denominator;
                if (division < 0)
                    throw new BadSqrtException("Sqrt expression cannot be negative.");

                z = Math.Sqrt(division);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Function will return 0");
                return 0;
            }

            return z;
        }
    }
    
    internal class Functions : Program
    {
        private const string ProgramName = "Functions Calculation";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }
        
        protected internal override void Execute()
        {
            try
            {
                Console.ReadKey();
                Console.Write("Input \'x\' value: ");
                var x = double.Parse(Console.ReadLine());

                var zOne = Calculation.ZedOne(ref x);
                var zTwo = Calculation.ZedTwo(ref x);
                
                Console.WriteLine("Results:" + '\n' + $"Z1 = {zOne}" + '\n' + $"Z2 = {zTwo}");
                Console.WriteLine("Program has been successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}