using System;
using System.IO;

namespace mathLogic
{
    internal class Implication
    {
        private const int ScaleOfNotation = 2;
        private const int VariablesAmount = 3;
        private readonly int _tableLinesAmount;
        private byte[,] _formulasTable;

        public Implication()
        {
            _tableLinesAmount = (int) Math.Pow(ScaleOfNotation, VariablesAmount);
        }

        public void DisplayTable()
        {
            for (var i = 0; i < _formulasTable.GetLength(0); i++)
            {
                for (var j = 0; j < _formulasTable.GetLength(1); j++)
                    Console.Write($"{_formulasTable[i, j]} ");
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

        // Parses the second half of a string, taking only regulations' digits
        private void ParseIntoTable(string[] parsedString, int tableIndex)
        {
            if (string.IsNullOrEmpty(parsedString?.ToString()))
                throw new Exception("One of the parsed regulation lines was empty.");
            
            for (int j = 0, k = VariablesAmount; j < _formulasTable.GetLength(1); ++j, ++k)
                _formulasTable[tableIndex, j] = byte.Parse(parsedString[k]);
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

            _formulasTable = new byte[_tableLinesAmount, formulasAmount];

            for (var i = 0; i < _tableLinesAmount; ++i)
            {
                var regulation = inputFile.ReadLine()?.Split();
                ParseIntoTable(regulation, i);
            }
            
            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("Input file ending not found.");
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