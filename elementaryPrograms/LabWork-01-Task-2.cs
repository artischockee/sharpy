// Date: 08-Sep-17

using System;

namespace LabWork01
{
    class Computing
    {
        public double GetResult(double x)
        {
            if (x < 5)
                return (double) Math.Log(x - 3);
            else if (x > 5)
                return (double) Math.Pow(x, 2) - 4;
            else
                return (double) Math.Pow(x, 3) - 5 * x + 2;
        }
    }

    class Task2
    {
        static void Main(string[] args)
        {
            Console.Write("Введите действительное значение переменной X: ");
            double x = double.Parse(Console.ReadLine());

            var Result = new Computing();
            var result = Result.GetResult(x);

            Console.WriteLine("Результат: Y = {0}", result);
        }
    }
}
