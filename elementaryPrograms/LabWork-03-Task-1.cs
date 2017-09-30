using System;

namespace LabWork03
{
    class Task1
    {
        // calculate Greatest Common Divisor
        // based on Euclidean algorithm (binary version)
        // recursive algorithm is used
        static uint GCD(uint a, uint b)
        {
            // if function will be used separately from LCM,
            // it should be checking if any of arguments equals zero!

            if (a == b)
                return a;

            if (a == 1 || b == 1)
                return 1;

            // if 'a' is even
            if ((~a & 1) == 1) {
                // if 'b' is odd
                if ((b & 1) == 1)
                    return GCD((a >> 1), b);
                else
                    return GCD((a >> 1), (b >> 1)) << 1;
            }

            // if 'b' is even
            if ((~b & 1) == 1)
                return GCD(a, (b >> 1));

            if (a < b)
                return GCD(a, ((b - a) >> 1));
            else
                return GCD(((a - b) >> 1), b);
        }

        // calculate Least Common Multiple
        static uint LCM(uint a, uint b)
        {
            if (a == 0 || b == 0)
                return 0;

            uint gcd = GCD(a, b);

            // auxiliary info:
            uint result = (a * b) / gcd;
            Console.WriteLine("НОК({0},{1}) = {2}", a, b, result);

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите целые положительные a и b:");
            uint a = uint.Parse(Console.ReadLine());
            uint b = uint.Parse(Console.ReadLine());

            uint Z = LCM((a + b), (a * b)) + LCM(a, b);
            if (Z == 0)
                Console.WriteLine("Невозможно вычислить НОК, если в аргументах присутствует хотя бы один ноль.");
            else
                Console.WriteLine("Результат: Z = {0}", Z);
        }
    }
}
