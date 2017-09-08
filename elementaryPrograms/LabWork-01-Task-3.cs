// Date: 08-Sep-17

using System;

namespace LabWork01
{
    class ComputingPt1
    {
        public long Factorial(int i)
        {
            if (i >= 2) return i * Factorial(i - 1);
            else return 1;
        }

        public double GetResult(int n, double x)
        {
            double sum = 0;

            for (int i = 1; i <= n; ++i)
                sum += (1.0 / Factorial(i) + Math.Sqrt(Math.Abs(x)));

            return sum;
        }
    }

    class ComputingPt2
    {
	public void GetResult(double a, double xn, double xk, double dx)
	{
	    double negativesSum = 0;
	    double existingsProd = 1;
	    int amountOfPositive = 0;
	    
	    for (var x = xn; x <= xk; x = x + dx) {
	    	double t = Math.Sin(a * x) + Math.Pow((a + x), 1.0 / 3.0) - Math.Exp(x);

		if (t < 0)
		   negativesSum += t;
		if (t != 0)
		   existingsProd *= t;
		if (t > 0)
		   amountOfPositive++;
	    }
	    
	    Console.WriteLine("Сумма отрицательных значений t: {0}", negativesSum);
	    Console.WriteLine("Произведение ненулевых значений t: {0}", existingsProd);
	    Console.WriteLine("Количество положительных значений t: {0}", amountOfPositive);
	}
    }

    class Task3
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите действительное число X: ");
            double x = double.Parse(Console.ReadLine());

            var ResultPt1 = new ComputingPt1();
            var resultPt1 = ResultPt1.GetResult(n, x);

            Console.WriteLine("Результат: {0}\n", resultPt1);

	    const double a = 1.23;
	    const double xn = 2.5;
	    const double xk = 8.5;
	    const double dx = 0.2;
	    Console.WriteLine("Начальные значения: a = {0}, xn = {1}, xk = {2}, dx = {3}", a, xn, xk, dx);

	    var ResultPt2 = new ComputingPt2();
	    ResultPt2.GetResult(a, xn, xk, dx);

	    Console.WriteLine("Работа программы завершена.");
        }
    }
}
