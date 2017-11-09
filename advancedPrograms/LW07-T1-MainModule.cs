using System;

namespace LW07T1
{
    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]

        public static void ArrayTesting()
        {
            var first = new Array<int>();
            first.Add(1,2,3,4,5,6,7,8,9,10);
            first.Display();

            var second = new Array<int>();
            second.Add(15,14,13,12,11,10,9,8,7,6,5,4,3,2,1);
            second.Display();
        }

        public static void StackTesting()
        {
            var Sfirst = new Stack<int>();
            Sfirst.Push(17, 14, 32, 55, 1, 2, 3, 10, 16);
            Sfirst.Display();
        }

        public static void QueueTesting()
        {
            
        }

        public static void Main(string[] args)
        {
            try {
                ArrayTesting();
                // StackTesting();
                // QueueTesting();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    } // public class MainModule
} // namespace LW07T1
