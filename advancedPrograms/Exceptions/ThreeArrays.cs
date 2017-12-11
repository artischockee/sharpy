// This file implements FIRST TASK.
// FIRST TASK: Three different arrays. 

using System;
using System.Data;

namespace Exceptions
{
    internal static class Function
    {
        public const int LowerBound = -3;
        public const int UpperBound = 7;
        public const double Delta = 0.5;

        public static int ArraySize => (int) ((UpperBound - LowerBound) / Delta);

        public static void ArrayFill(double[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            var x = (double) LowerBound;
            
            for (var i = 0; i < array.Length; ++i)
            {
                try
                {
                    if (x >= UpperBound)
                        throw new ArgumentOutOfRangeException(
                            $"Argument \'x\' has gone out of range [{LowerBound}; {UpperBound}].");
                    
                    var numerator = x - 1;
                    var denominator = x + 1;
                    if (denominator == 0)
                        throw new DivideByZeroException("Attempt to divide by zero.");

                    var fractional = numerator / denominator;
                    if (fractional <= 0)
                        throw new InvalidExpressionException(
                            $"Real Log10 cannot exist due to value {fractional}.");
                    
                    array[i] = Math.Log10(fractional);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    array[i] = 0;
                }
                finally
                {
                    x += Delta;
                }
            }
        }
    }
    
    internal static class Randomize
    {
        private const int LowerInArrayBound = -99; 
        private const int UpperInArrayBound = 100;
        private const int LowerArraySize = 1;
        private const int UpperArraySize = 31;
        
        private static readonly Random Random;

        static Randomize()
        {
            Random = new Random();
        }
        
        public static int GetRandom => Random.Next(LowerArraySize, UpperArraySize);

        public static void FillWithRandom(int[] array)
        {
            for (var i = 0; i < array.Length; ++i)
            {
                array[i] = Random.Next(LowerInArrayBound, UpperInArrayBound);
            }
        }
    }
    
    internal class ThreeArrays : Program
    {
        // Fields
        
        private const string ProgramName = "Three Arrays";
        
        private const int Reserve = 10;
        private static double[] _arrayA;
        private static int[] _arrayB;
        private static double[] _arrayC;
        
        // Methods:

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }
        
        private static void Display(Array array)
        {
            Console.WriteLine($"Array size: {array.Length}");
            var index = 0;
            foreach (var element in array)
                Console.WriteLine($"{++index}. {element}");
        }

        private static void ConcatArrays()
        {
            for (var i = 0; i < _arrayC.Length; ++i)
            {
                try
                {
                    if (i >= _arrayA.Length || i >= _arrayB.Length)
                        throw new IndexOutOfRangeException();

                    var underSqrt = _arrayA[i] + _arrayB[i];
                    if (underSqrt < 0)
                        throw new ArgumentOutOfRangeException(nameof(underSqrt));

                    _arrayC[i] = Math.Sqrt(underSqrt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    _arrayC[i] = 0;
                }
            }
        }

        private static void OperateA()
        {
            try
            {
                var size = Function.ArraySize;
                if (size <= 0)
                    throw new ArgumentOutOfRangeException(
                        $"Array A size cannot be lesser or equal to 0. Attempt to make array with size \'{Reserve}\'");

                _arrayA = new double[size];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                _arrayA = new double[Reserve];
            }
            
            Function.ArrayFill(_arrayA);
            Display(_arrayA);
        }
        
        private static void OperateB()
        {
            try
            {
                var size = Randomize.GetRandom;
                if (size <= 0)
                    throw new ArgumentOutOfRangeException(
                        $"Array B size cannot be lesser or equal to 0. Attempt to make array with size \'{Reserve}\'");

                _arrayB = new int[size];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                _arrayB = new int[Reserve];
            }
            
            Randomize.FillWithRandom(_arrayB);
            Display(_arrayB);
        }

        private static void OperateC()
        {
            try
            {
                var size = Randomize.GetRandom;
                if (size <= 0)
                    throw new ArgumentOutOfRangeException(
                        $"Array C size cannot be lesser or equal to 0. Attempt to make array with size \'{Reserve}\'");

                _arrayC = new double[size];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                _arrayC = new double[Reserve];
            }
            
            ConcatArrays();
            Display(_arrayC);
        }
        
        // Main method:
        
        protected internal override void Execute()
        {
            try
            {
                OperateA();
                Console.WriteLine(new string('=', 80));
                OperateB();
                Console.WriteLine(new string('=', 80));
                OperateC();
                
                Console.WriteLine("Program has been successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}