using System;

namespace LabWork02
{
    class Task2
    {
        static void AutoFill(ref int[,] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); ++i) {
                for (int j = 0; j < array.GetLength(1); ++j) {
                    array[i,j] = rand.Next(-2, 20);
                }
            }
        }

        static void Print2D(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i) {
                for (int j = 0; j < array.GetLength(1); ++j) {
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Print1D(ref int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                Console.Write(array[i] + " ");
        }

        static void Operate(ref int[,] arrFrom, ref int[] arrTo)
        {
            for (int i = 0; i < arrFrom.GetLength(0); ++i) {
                bool isNegativeExists = false;
                for (int j = 0; j < arrFrom.GetLength(1); ++j) {
                    if (arrFrom[i,j] < 0) {
                        isNegativeExists = true;
                        arrTo[i] = j + 1;
                        break;
                    }
                }
                if (!isNegativeExists)
                    arrTo[i] = 0;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введи число строк и столбцов:");
            Console.Write("Кол-во строк [N]: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Кол-во столбцов [M]: ");
            int M = int.Parse(Console.ReadLine());

            int[,] arrayA = new int[N,M];
            AutoFill(ref arrayA);

            Console.WriteLine("\nСгенерированный массив A:");
            Print2D(ref arrayA);

            int[] arrayB = new int[N];
            Operate(ref arrayA, ref arrayB);

            Console.WriteLine("\nПолученный массив B:");
            Print1D(ref arrayB);

            Console.WriteLine();
        }
    }
}
