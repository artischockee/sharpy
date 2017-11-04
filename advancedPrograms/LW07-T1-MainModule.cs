using System;

namespace LW07T1
{
    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]

        public static void Main(string[] args)
        {
            try {
                var test = new Array<int>();
                for (int i = 0; i < 10; ++i)
                    test.Add(i + 1);
                Console.WriteLine("Test 1");
                test.Display();

                var test2 = new Array<int>();
                for (int i = 15; i >= 0; --i)
                    test2.Add(i + 1);
                Console.WriteLine("Test 2");
                test2.Display();
            
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    } // public class MainModule
} // namespace LW07T1
