using System;

namespace LabWork03
{
    class Task2
    {
        static void AutoFill(ref int[,] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); ++i)
                for (int j = 0; j < array.GetLength(1); ++j)
                    array[i,j] = rand.Next(-5, 16);
        }

        static void Print(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i) {
                for (int j = 0; j < array.GetLength(1); ++j)
                    Console.Write(array[i,j] + "\t");
                Console.WriteLine();
            }
        }

        static void Operate(ref int[,] from, ref int[,] to)
        {
            for (int i = 0; i < to.GetLength(0); ++i)
                for (int j = 0; j < to.GetLength(1); ++j) {
                    if (from[i,j] < 0)
                        to[i,j] = 0;
                    else
                        to[i,j] = from[i,j];
                }
        }

        static void Main(string[] args)
        {
            const uint rows = 3;
            const uint cols = 3;

            int[,] x = new int[rows, cols];
            AutoFill(ref x);

            Console.WriteLine("Массив X:");
            Print(ref x);

            int[,] y = new int[rows, cols];
            Operate(ref x, ref y);

            Console.WriteLine("Массив Y:");
            Print(ref y);
        }
    }
}
