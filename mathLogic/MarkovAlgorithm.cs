using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace mathLogic
{
    internal struct RegulationsTable
    {
        public readonly string LeftWord;
        public readonly string RightWord;
        public readonly byte Statement;

        public RegulationsTable(string lword, string rword, byte statement)
        {
            LeftWord = lword;
            RightWord = rword;
            Statement = statement;
        }
    }
    
    internal class MarkovAlgorithm
    {
        private const char Zero = '#';
        private readonly List<RegulationsTable> _regulationsTable;
        private string _operatedWord;

        public void Disp()
        {
            Console.WriteLine(_operatedWord);
        }
        
        public MarkovAlgorithm()
        {
            _regulationsTable = new List<RegulationsTable>();
        }

        public void ExportWord(StreamWriter outputFile)
        {
            outputFile.WriteLine(_operatedWord);
        }

        // Trims all leading and trailing zeroes
        private void TrimWord()
        {
            _operatedWord = _operatedWord.Trim(Zero);
            if (string.IsNullOrEmpty(_operatedWord))
                _operatedWord += Zero;
        }
        
        // Imitates the Markov Algorithm's work in accordance to specified regulations
        public void PerformTask()
        {
            Console.Write($"[Initial] {_operatedWord} ");
            foreach (var reg in _regulationsTable)
            {
                var isClosingRegulation = false;
                while (_operatedWord.Contains(reg.LeftWord))
                {
                    var regex = new Regex(Regex.Escape(reg.LeftWord));
                    _operatedWord = regex.Replace(_operatedWord, reg.RightWord, 1);
                    
                    Console.Write($"-> {_operatedWord} ");

                    if (reg.Statement == 1)
                    {
                        isClosingRegulation = true;
                        break;
                    }
                }
                
                if (isClosingRegulation)
                    break;
            }
            Console.WriteLine();

            TrimWord();
        }

        // Reads parameters and regulations from specified file
        public void ImportParameters(StreamReader inputFile)
        {
            if (inputFile.EndOfStream)
                throw new EndOfStreamException("Input file is empty.");

            var buffer = inputFile.ReadLine();
            if (string.IsNullOrEmpty(buffer))
                throw new Exception("First line of input file was empty.");

            var regulationsAmount = int.Parse(buffer);
            for (var i = 0; i < regulationsAmount; ++i)
            {
                var regulation = inputFile.ReadLine()?.Split();
                if (string.IsNullOrEmpty(regulation?.ToString()))
                    throw new Exception("One of the parsed regulation lines was empty.");

                _regulationsTable.Add(
                    new RegulationsTable(
                        regulation[0],
                        regulation[1],
                        byte.Parse(regulation[2]))
                );
            }
            
            buffer = inputFile.ReadLine();
            if (string.IsNullOrEmpty(buffer))
                throw new Exception("Last line (an initial word) of input file was empty.");

            _operatedWord = buffer;

            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("File ending not found. One should contain 2 lines with integers.");
        }
    }

    public class MainMarkovAlgorithm : Program
    {
        private const string ProgramName = "Markov Algorithm";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }
        
        protected internal override void Execute()
        {
            const string inputFile = "input";
            const string outputFile = "output";
            
            var markov = new MarkovAlgorithm();
            
            try
            {
                using (var input = new StreamReader(inputFile))
                    markov.ImportParameters(input);
                    
                markov.PerformTask();
                markov.Disp();

                using (var output = new StreamWriter(outputFile, false))
                    markov.ExportWord(output);
                
                Console.WriteLine("Operations were successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}