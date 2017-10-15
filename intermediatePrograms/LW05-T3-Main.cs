using System;

namespace LW05T3
{
    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            const int rows = 4;
            const int cols = 5;
            try {
                var test1 = new Matrix(rows, cols);
                test1.Fill();
                var test2 = new Matrix(rows, cols);
                test2.Fill();

                Console.WriteLine("1st matrix:");
                test1.Display();
                Console.WriteLine("\n2nd matrix:");
                test2.Display();

                Console.WriteLine("\nMinimum of 1st: {0}", test1.GetMinimum());
                Console.WriteLine("Minimum of 2nd: {0}", test2.GetMinimum());

                var test3 = new Matrix(rows, cols);
                test3 = test2 - test1;
                Console.WriteLine("\n3rd matrix (2nd - 1st):");
                test3.Display();

                Console.WriteLine("\nMinimum of 3rd: {0}", test3.GetMinimum());
            }
            catch (IndexOutOfRangeException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
