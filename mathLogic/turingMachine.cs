using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace turingMachine
{
    public struct FuncScheme
    {
        public readonly int Sprev;
        public readonly char Nprev;
        public readonly int Snext;
        public readonly char Nnext;
        public readonly short Move;

        public FuncScheme(int sprev, char nprev, int snext, char nnext, short move)
        {
            Sprev = sprev;
            Nprev = nprev;
            Snext = snext;
            Nnext = nnext;
            Move = move;
        }
    }
    
    public class TuringMachine
    {       
        private const int RegulationLength = 5;
        private readonly List<FuncScheme> _funcScheme;
        private List<char> _instructionTape;
        private int _conditionsAmount;

        public TuringMachine()
        {
            _funcScheme = new List<FuncScheme>();
            _instructionTape = new List<char>();
            _conditionsAmount = 0;
        }

        public void ExportTape(StreamWriter outputFile)
        {
            outputFile.WriteLine(_instructionTape.ToArray());
        }

        // Trims all leading and trailing zeroes except for the closest ones
        private void MakeDecentTape()
        {
            var stringTape = new string(_instructionTape.ToArray());
            stringTape = stringTape.Trim('0');
            stringTape = string.Concat("0", stringTape, "0");
            _instructionTape = stringTape.ToList();
        }
        
        private void DisplayTape(int pos = 0)
        {
            for (var i = 0; i < _instructionTape.Count; ++i)
                Console.Write(i == pos ? $"[{_instructionTape[i]}]" : $"{_instructionTape[i]}");
            Console.Write(" -> ");
        }
        
        // Imitates the Turing machine's work in accordance to specified parameters and schemes
        public void PerformTask(int state = 1, int pos = 0)
        {
            if (state <= 0 || state >= _conditionsAmount)
                throw new ArgumentOutOfRangeException(nameof(state));
            if (pos < 0 || pos > _instructionTape.Count)
                throw new ArgumentOutOfRangeException(nameof(pos));

            while (state != 0)
            {
                if (state < 0 || state >= _conditionsAmount)
                    throw new ArgumentOutOfRangeException(nameof(state));
                if (pos < 0 || pos > _instructionTape.Count)
                    throw new ArgumentOutOfRangeException(nameof(pos));
                
                var currRegulation = _funcScheme.First(row => row.Sprev == state && row.Nprev == _instructionTape[pos]);

                _instructionTape[pos] = currRegulation.Nnext;
                state = currRegulation.Snext;
                pos += currRegulation.Move;
                if (pos < 0)
                {
                    _instructionTape.Insert(0, '0');
                    ++pos;
                }
                else if (pos == _instructionTape.Count)
                    _instructionTape.Add('0');

                DisplayTape(pos);
            }

            MakeDecentTape();
        }

        // Reads parameters, regulations and instructions from specified file
        public void ImportParameters(StreamReader inputFile)
        {
            if (inputFile.EndOfStream)
                throw new EndOfStreamException("Input file is empty.");

            var buffer = inputFile.ReadLine()?.Split();
            if (buffer == null)
                throw new Exception("Input file buffer was empty. Check the input file.");

            var n = int.Parse(buffer[0]); // amount of inner conditions (states)
            var m = int.Parse(buffer[1]); // amount of regulations

            for (var i = 0; i < m; ++i)
            {
                var regulation = inputFile.ReadLine()?.Split();
                if (regulation == null)
                    throw new Exception(
                        "One of the parsed regulation lines was empty. Check the input file.");
                if (regulation.Length != RegulationLength)
                    throw new Exception(
                        $"Error in regulation rule (line {i + 1}): needed to contain {RegulationLength} numbers");

                _funcScheme.Add(
                    new FuncScheme(
                        int.Parse(regulation[0]),
                        char.Parse(regulation[1]),
                        int.Parse(regulation[2]),
                        char.Parse(regulation[3]),
                        short.Parse(regulation[4])
                    )
                );
            }
            
            var tape = inputFile.ReadLine()?.ToCharArray();
            if (tape == null)
                throw new Exception("Can't find the tape in the last line of the input file.");

            foreach (var symbol in tape)
                _instructionTape.Add(symbol);
            
            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("File ending not found. One should contain 2 lines with integers.");

            _conditionsAmount = n;
        } // public void ReadParameters(StreamReader inputFile)
    } // public class TuringMachine

    public static class MainModule
    {
        public static void Main()
        {
            const string inputFile = "input";
            const string outputFile = "output";
            
            var turing = new TuringMachine();
            
            try
            {
                using (var input = new StreamReader(inputFile))
                    turing.ImportParameters(input);

                turing.PerformTask();

                using (var output = new StreamWriter(outputFile, false))
                    turing.ExportTape(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(File.Exists(outputFile)
                ? "Output file has been created."
                : "Output file has not been created.");
        }
    }
}