using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

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

        public int ZeroesAmount
        {
            get
            {
                return RegLine.Count(digit => digit == 0);
            }
        }
    }
    
    internal class Implication
    {
        private const int ScaleOfNotation = 2;
        private const int VariablesAmount = 3;
        private readonly int _tableLinesAmount;
        private readonly List<Regulation> _formulasTable;

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

        public static bool IsImplicate(byte a, byte b)
        {
            return a == 0 || b == 1;
        }
        
        private string GetTableIndexes()
        {
            string result = null;

            foreach (var regulation in _formulasTable)
                result = result + regulation.Index + " ";

            return result;
        }

        // Checks if there are an equal formulas in the _formulasTable.
        // This method only works correct when the _formulasTable
        // already sorted (like in PerformTask method)
        public bool IsEquivalentFormulas()
        {
            if (_formulasTable == null)
                throw new NullReferenceException("Can\'t perform any actions in nullable _formulasTable");
            if (_formulasTable.Count < 2)
            {
                Console.WriteLine($"There is/are {_formulasTable.Count} formula(s) in the _formulasTable" +
                                  "So, \"IsEquivalentFormulas\" method returns false.");
                return false;
            }
            
            for (var i = 0; i < _formulasTable.Count - 1; ++i)
            {
                if (_formulasTable[i].ZeroesAmount != _formulasTable[i + 1].ZeroesAmount)
                    continue;
                if (_formulasTable[i].RegLine == _formulasTable[i + 1].RegLine)
                    return true;
            }

            return false;
        }

        // Solves the sequence of formulas presented in formulasTable
        public void PerformTask(StreamWriter outputFile)
        {
            _formulasTable.Sort((reg1, reg2) => reg2.ZeroesAmount.CompareTo(reg1.ZeroesAmount));
            
            if (IsEquivalentFormulas())
                throw new DataException("An equivalent formulas has been detected in the _formulasTable");
            
            for (var i = 0; i < _tableLinesAmount; ++i)
                for (var j = 0; j < _formulasTable.Count - 1; ++j)
                {
                    if (IsImplicate(_formulasTable[j].RegLine[i], _formulasTable[j + 1].RegLine[i]))
                        continue;
                    
                    outputFile.WriteLine("-1");
                    return;
                }

            var indexesInLine = GetTableIndexes();
            outputFile.WriteLine(indexesInLine);
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
            // This variable collects all the lines from an input file:
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
    
    public class MainImplication : IProgram
    {
        private const string ProgramName = "Implication";
        public string Name => ProgramName;
        
        public void Execute()
        {
            const string inputFile = "input";
            const string outputFile = "output";
            
            var implication = new Implication();
            
            try
            {
                using (var input = new StreamReader(inputFile))
                    implication.ImportParameters(input);
                
                using (var output = new StreamWriter(outputFile, false))
                    implication.PerformTask(output);
                
                Console.WriteLine("Operations were successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}