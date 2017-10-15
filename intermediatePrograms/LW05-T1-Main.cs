using System;

namespace LW05T1
{
    internal class A
    {
        private float a;
        private float b;

        internal A()
        {
            this.a = this.b = 0;
        }

        internal A(float a, float b)
        {
            this.a = a;
            this.b = b;
        }

        public static A operator -(A obj1, A obj2)
        {
            var obj = new A();
            obj.a = obj1.a - obj2.a;
            obj.b = obj1.b - obj2.b;
            return obj;
        }

        public static A operator +(A obj1, A obj2)
        {
            var obj = new A();
            obj.a = obj1.a + obj2.a;
            obj.b = obj1.b + obj2.b;
            return obj;
        }

        public void Print()
        {
            Console.WriteLine("a = {0}, b = {1}", a, b);
        }
    }

    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            var obj1 = new A(127.001f, 44.5f);
            var obj2 = new A(32.114f, 10.337f);

            Console.WriteLine("1st object:");
            obj1.Print();
            Console.WriteLine("2nd object:");
            obj2.Print();

            var obj = new A();
            obj1 -= obj2;
            obj = obj1 + obj2;

            Console.WriteLine("Result:");
            obj.Print();
        }
    }
}
