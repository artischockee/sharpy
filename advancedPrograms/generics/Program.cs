using System;
using System.Collections.Generic;
using System.Linq;

namespace generics
{
    internal static class Program
    {
        public static void Main()
        {
            try
            {
                var collection = new List<Vector<int>>
                {
                    new Vector<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new Vector<int> { 10, 8, 6, 4, 2, 1, 3, 5, 7, 9 }, // 1st
                    new Vector<int> { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 },
                    new Vector<int> { 10, 8, 6, 4, 2, 1, 3, 5, 7, 9 }, // 2nd
                    new Vector<int> { 10, 8, 6, 4, 2, 1, 3, 5, 7, 9 }, // 3rd
                    new Vector<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }
                };
            
                var compare = new Vector<int> { 10, 8, 6, 4, 2, 1, 3, 5, 7, 9 };
                var amount = collection.Count(x => x == compare);
                Console.WriteLine($"Amount of same arrays: {amount}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}