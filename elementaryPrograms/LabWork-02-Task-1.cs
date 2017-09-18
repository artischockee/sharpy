using System;

namespace LabWork02
{
    class Task1
    {
        static void Main(string[] args)
        {
            Console.Write("Введи число эл-в в массиве: ");
            int N = int.Parse(Console.ReadLine());

            int[] array = new int[N];
            int maxPositive = 0; // maximum positive number
            int sumPosEven = 0; // sum of positive and even numbers
            bool isNegativeExist = false; // checks if any negative number exists in array

            Console.WriteLine("Введи {0} элемент(а/ов) массива", N);
            for (int i = 0; i < array.Length; ++i) {
                int var = int.Parse(Console.ReadLine());
                array[i] = var;
                if (var > 0 && var % 2 == 0) {
                    sumPosEven += var; }
                if (var > maxPositive) {
                    maxPositive = var; }
                else {
                    isNegativeExist = true; }
            }

            Console.WriteLine("Макс. положительный эл-т: {0}", maxPositive);
            Console.WriteLine("Сумма полож. четных эл-тов: {0}", sumPosEven);
            if (isNegativeExist) {
                Console.WriteLine("Отрицательные эл-ты в обратном порядке:");
                for (int i = array.Length - 1; i >= 0; --i) {
                    if (array[i] < 0) {
                        Console.Write(array[i] + " ");
                    }
                }
                Console.WriteLine();
            } else {
                Console.WriteLine("В массиве отсутствуют отрицательные эл-ты.");
            }
        }
    }
}
