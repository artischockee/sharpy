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
        public string OperatedWord { get; private set; }
        
        public MarkovAlgorithm()
        {
            _regulationsTable = new List<RegulationsTable>();
        }

        // Trims all leading and trailing zeroes
        private void TrimWord()
        {
            OperatedWord = OperatedWord.Trim(Zero); 
            if (string.IsNullOrEmpty(OperatedWord))
                OperatedWord += Zero;
        }
        
        // Imitates the Markov Algorithm's work in accordance to specified regulations
        public void PerformTask()
        {
            Console.Write($"[Initial] {OperatedWord} ");
            var isClosingRegulation = false;
            
            while (!isClosingRegulation)
            {
                foreach (var reg in _regulationsTable)
                {
                    if (!OperatedWord.Contains(reg.LeftWord)) continue;
                    
                    var regex = new Regex(Regex.Escape(reg.LeftWord));
                    OperatedWord = regex.Replace(OperatedWord, reg.RightWord, 1);
                        
                    Console.Write($"-> {OperatedWord} ");

                    if (reg.Statement == 1)
                        isClosingRegulation = true;
                        
                    break;
                }
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

            OperatedWord = string.Concat("#", buffer);

            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("Input file ending not found.");
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
                Console.WriteLine(markov.OperatedWord);

                using (var output = new StreamWriter(outputFile, false))
                    output.WriteLine(markov.OperatedWord);
                
                Console.WriteLine("Operations were successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}