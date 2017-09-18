using System;

namespace LabWork02
{
    class Task4
    {
        static void AutoFill(ref int[,] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); ++i) {
                for (int j = 0; j < array.GetLength(1); ++j) {
                    array[i,j] = rand.Next(0,10);
                }
            }
        }

        static void Print(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i) {
                for (int j = 0; j < array.GetLength(1); ++j) {
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int MaxOfArray(ref int [,] array)
        {
            int max = array[0,0];
            for (int i = 0; i < array.GetLength(0); ++i) {
                for (int j = 0; j < array.GetLength(1); ++j) {
                    if (array[i,j] > max)
                        max = array[i,j];
                }
            }

            return max;
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void Operate(ref int [,] array)
        {
            int rowAmount = array.GetLength(0);
            int colAmount = array.GetLength(1);

            int max = MaxOfArray(ref array);
            int col = colAmount - 1;
            int row = 0;

            for (int i = 0; i < rowAmount; ++i) {
                for (int j = 0; j < colAmount; ++j) {
                    if (j > i) continue;
                    else if (array[i,j] == max) {
                        Console.WriteLine("Debug: swapping {0} (at position {1},{2}) and {3} (at position {4},{5})", array[i,j], i+1, j+1, array[row,col], row+1, col+1);

                        Swap(ref array[i,j], ref array[row,col]);
                        row++;
                    }
                    if (row == rowAmount - 1 || row == col) {
                        row = 0;
                        col--;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введи число строк и столбцов:");
            Console.Write("Кол-во строк [N]: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Кол-во столбцов [M]: ");
            int M = int.Parse(Console.ReadLine());

            int[,] array = new int[N,M];
            AutoFill(ref array);

            Console.WriteLine("\nСгенерированный массив:");
            Print(ref array);

            Console.WriteLine("Максимум: {0}", MaxOfArray(ref array));

            Operate(ref array);

            Console.WriteLine("\nПолученный результат:");
            Print(ref array);

            Console.WriteLine();
        }
    }
}
