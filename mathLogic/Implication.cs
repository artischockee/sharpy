using System;
using System.Collections.Generic;
using System.IO;

namespace mathLogic
{
    internal struct Regulation
    {
        public byte[] RegLine { get; }
        public int Index { get; }

        public Regulation(byte[] regLine, int index)
        {
            if (regLine.Length == 0)
                throw new ArgumentNullException(nameof(regLine));
            if (index <= 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            RegLine = regLine;
            Index = index;
        }
    }
    
    internal class Implication
    {
        private const int ScaleOfNotation = 2;
        private const int VariablesAmount = 3;
        private readonly int _tableLinesAmount;
        private List<Regulation> _formulasTable;

        public Implication()
        {
            _tableLinesAmount = (int) Math.Pow(ScaleOfNotation, VariablesAmount);
            _formulasTable = new List<Regulation>();
        }

        public void DisplayTable()
        {
            foreach (var formula in _formulasTable)
            {
                Console.Write($"#{formula.Index}: ");
                foreach (var digit in formula.RegLine)
                    Console.Write($"{digit} ");
                Console.WriteLine();
            }
        }

//        public static bool IsImplicate(byte a, byte b)
//        {
//            return a == 0 || b == 1;
//        }

        private void Swap(int indexOne, int indexTwo)
        {
            // write Exceptions here
            
//            var buffer = _formulasTable[indexOne];
//            _formulasTable[indexOne] = _formulasTable[indexTwo];
//            _formulasTable[indexTwo] = buffer;
        }
        
        // Solves the sequence of formulas presented in formulasTable
        public void PerformTask()
        {
            
        }

        private void ConvertToTable(byte[,] matrix)
        {
            for (var j = 0; j < matrix.GetLength(1); ++j)
            {
                var column = new Regulation(new byte[_tableLinesAmount], j + 1);
                for (var i = 0; i < matrix.GetLength(0); ++i)
                    column.RegLine[i] = matrix[i, j];
                
                _formulasTable.Add(column);
            }
        }

        // Parses the second half of the lines, taking only regulations' digits
        private void ParseIntoMatrix(List<string[]> parsedString, int formulasAmount)
        {
            if (string.IsNullOrEmpty(parsedString?.ToString()))
                throw new Exception("One of the parsed regulation lines was empty.");
            if (formulasAmount <= 0)
                throw new ArgumentOutOfRangeException("Formulas amount cannot be lesser or equal to 0");

            var regMatrix = new byte[_tableLinesAmount, formulasAmount];

            for (var i = 0; i < parsedString.Count; ++i)
                for (int j = VariablesAmount, k = 0; j < parsedString[i].Length; ++j, ++k)
                    regMatrix[i, k] = byte.Parse(parsedString[i][j]);

            ConvertToTable(regMatrix);
        }

        // Reads parameters and regulations from specified file
        public void ImportParameters(StreamReader inputFile)
        {
            if (inputFile.EndOfStream)
                throw new EndOfStreamException("Input file is empty.");

            var buffer = inputFile.ReadLine();
            if (string.IsNullOrEmpty(buffer))
                throw new Exception("First line of input file was empty.");

            var formulasAmount = int.Parse(buffer);
            var inputLines = new List<string[]>();

            for (var i = 0; i < _tableLinesAmount; ++i)
            {
                var line = inputFile.ReadLine()?.Split();
                inputLines.Add(line);
            }
            
            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("Input file ending not found.");
            
            ParseIntoMatrix(inputLines, formulasAmount);
        }
    }
    
    public class MainImplication : Program
    {
        private const string ProgramName = "Implication";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }
        
        protected internal override void Execute()
        {
            const string inputFile = "input";
            const string outputFile = "output";
            
            var implication = new Implication();
            
            try
            {
                using (var input = new StreamReader(inputFile))
                    implication.ImportParameters(input);
                    
                implication.DisplayTable();

                using (var output = new StreamWriter(outputFile, false))
                    // ...
                
                Console.WriteLine("Operations were successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}