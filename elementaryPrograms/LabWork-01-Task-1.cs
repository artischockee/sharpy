// Date: 08-Sep-17

using System;

namespace LabWork01
{
    class Processing
    {
        public double VarA(double x, double y)
        {
            double tmp1 = 1 + y;
            double tmp2 = (x + y) / (Math.Pow(x, 2) + 4);
            double tmp3 = (Math.Exp(-x - 2) + 1) / (2 * (Math.Pow(x, 2) + 4));

            return (double) tmp1 * tmp2 / tmp3;
        }

        public double VarB(double x, double y, double z)
        {
            double tmp1 = 1 + Math.Cos(y - 2);
            double tmp2 = Math.Pow(x, 4) / 2;
            double tmp3 = Math.Pow(Math.Sin(z), 2);

            return (double) tmp1 / (tmp2 + tmp3);
        }
    }

    class Task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите действительные значения переменных:");
            Console.Write("X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Z: ");
            double z = double.Parse(Console.ReadLine());

            var A = new Processing();
            double a = A.VarA(x, y);

            var B = new Processing();
            double b = B.VarB(x, y, z);

            Console.WriteLine("Вариант А. Результат: {0}", a);
            Console.WriteLine("Вариант B. Результат: {0}", b);
        }
    }
}
