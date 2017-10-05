using System;

namespace LabWork04
{
    internal class A
    {
        private float a = 128.001f;
        private float b = 3.14f;

        internal float c
        {
            get {
                a -= b;
                return a + b;
            }
        }
    }

    public class Programm
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            var obj = new A();
            Console.WriteLine("Result: {0}", obj.c);
        }
    }
}
