using System;
using System.Linq;

namespace Exceptions
{
    internal static class Sorting
    {
        private static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            var length = array.Length;
            if (length == 0)
                throw new ArgumentNullException(nameof(array));
            if (firstIndex < 0 || firstIndex >= length
                || secondIndex < 0 || secondIndex >= length)
                throw new ArgumentOutOfRangeException();
            
            var temp = array[secondIndex];
            array[secondIndex] = array[firstIndex];
            array[firstIndex] = temp;
        }
        
        public static void Bubble(int[] array)
        {
            if (array.Length == 0)
                throw new ArgumentNullException(nameof(array));

            var size = array.Length;

            for (var j = 0; j < size; ++j)
            {
                var flag = false;
                for (var i = 0; i < size - (j + 1); ++i)
                {
                    if (array[i] <= array[i + 1]) continue;

                    Swap(array, i, i + 1);                    
                    flag = true;
                }
                if (flag == false)
                    break;
            }
        }
    }
    
    internal class SortingMain : Program
    {
        private const string ProgramName = "Bubble Sorting";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }

        private static void Display(int[] array)
        {
            foreach (var i in array)
                Console.Write($"{i} ");
            Console.WriteLine();
        }

        protected internal override void Execute()
        {
            try
            {
                Console.WriteLine("Input an array of integers:");
                var buffer = Console.ReadLine()?.Split();
                var array = buffer.Select(int.Parse).ToArray();

                Sorting.Bubble(array);
                Display(array);
                
                Console.WriteLine("Program has been successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}