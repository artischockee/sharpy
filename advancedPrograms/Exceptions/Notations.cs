using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exceptions
{
    internal struct Numeration
    {
        public char Letter { get; }
        public int Number { get; }

        public Numeration(char letter, int number)
        {
            if (char.IsWhiteSpace(letter))
                throw new ArgumentNullException(nameof(letter));
            
            Letter = letter;
            Number = number;
        }
    }
    
    internal struct Number
    {
        private const int MinNotationScale = 2;
        private const int MaxNotationScale = 16;
        
        public string Value { get; }
        public int Notation { get; }

        public Number(string value, int notation)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (notation < MinNotationScale || notation > MaxNotationScale)
                throw new ArgumentOutOfRangeException(nameof(notation));

            Value = value;
            Notation = notation;
        }

        public bool IsNull()
        {
            return string.IsNullOrEmpty(Value) || Notation == default(int);
        }
    }

    internal static class Letters
    {
        private static readonly List<Numeration> _lettersList;

        static Letters()
        {
            _lettersList = new List<Numeration>();
            char i;
            int n;
            for (i = 'A', n = 10; i <= 'Z'; ++i, ++n)
                _lettersList.Add(new Numeration(i, n));
        }

        public static void Disp()
        {
            foreach (var t in _lettersList)
            {
                Console.WriteLine($"{t.Letter} = {t.Number}");
            }
        }

        public static int GetDecimalRepresent(char letter)
        {
            return _lettersList.First(x => x.Letter == letter).Number;
        }
    }
    
    internal static class Translator
    {
        private const int BasicNotationScale = 10;
        
        private static int Parse(char number)
        {
            int result;
            if (!int.TryParse(number.ToString(), out result))
                result = Letters.GetDecimalRepresent(number);

            return result;
        }
        
        private static int GetDecimal(string number, int notation)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));
            
            if (notation == BasicNotationScale)
                return int.Parse(number);

            var decNumber = 0;

            {
                var numLen = number.Length;
                var lastIndex = numLen - 1;
                int i, pos;
                for (i = lastIndex, pos = 0; i >= 0; --i, ++pos)
                {
                    var currDigit = Parse(number[i]);
                    var sum = currDigit * (int) Math.Pow(notation, pos);
                    
                    decNumber += sum;
                }
            }
            
            return decNumber;
        }

        public static bool IsCorrectTranslation(Number initNumber, Number destNumber)
        {
            if (initNumber.IsNull() || destNumber.IsNull())
                throw new ArgumentNullException("Exception in IsCorrectTranslation().");

            var initDecimal = GetDecimal(initNumber.Value, initNumber.Notation);
            var destDecimal = GetDecimal(destNumber.Value, destNumber.Notation);
            
//            Console.WriteLine($"InitDecimal: {initDecimal}, DestDecimal: {destDecimal}");
            
            return initDecimal == destDecimal;
        }
    }
    
    internal class Notations : Program
    {
        private const string ProgramName = "Notations Translator";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }

        private Number NewNumber()
        {
            Console.ReadKey();
            Console.Write("Enter the initial number: ");
            var number = Console.ReadLine();
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number)); 
            
            Console.ReadKey();
            Console.Write("Define scale of notation: ");
            int notation;
            if (!int.TryParse(Console.ReadLine(), out notation))
                throw new InvalidDataException("Can\'t parse input line.");

            return new Number(number, notation);
        }
        
        protected internal override void Execute()
        {
            try
            {
//                var result = Translator.IsCorrectTranslation(
//                    new Number("6512", 7), new Number("1811", 11));
                
                var first = NewNumber();
                var second = NewNumber();
                var result = Translator.IsCorrectTranslation(first, second);
                
                Console.WriteLine(result == true
                    ? "Translation is correct."
                    : "Translation is invalid.");

                Console.WriteLine("Program has been successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}