using System;

namespace LabWork02
{
    class Task3
    {
        static void Operate(ref string init)
        {
            string[] substrings = init.Split();
            foreach (var substring in substrings) {
                if (substring.Length == 4 || substring.Length == 5) {
                    if (substring.Length == 4 &&
                       (substring.EndsWith(".") || substring.EndsWith(",") ||
                        substring.EndsWith(":") || substring.EndsWith("?") ||
                    substring.EndsWith("!"))) { /* do nothing */ }
                    else if (substring.Length == 5 &&
                       (substring.EndsWith(".") || substring.EndsWith(",") ||
                        substring.EndsWith(":") || substring.EndsWith("?") ||
                        substring.EndsWith("!"))) {
                        Console.WriteLine(substring);
                    } else if (substring.Length == 4)
                        Console.WriteLine(substring);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст с точкой на конце:");
            string initialText = Console.ReadLine();

            Operate(ref initialText);
        }
    }
}
