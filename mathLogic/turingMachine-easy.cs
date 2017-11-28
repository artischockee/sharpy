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
        private readonly List<char> _instructionTape;
        private int _conditionsAmount;

        public TuringMachine()
        {
            _funcScheme = new List<FuncScheme>();
            _instructionTape = new List<char>();
            _conditionsAmount = 0;
        }

        private void DisplayTape()
        {
            foreach (var symbol in _instructionTape)
                Console.Write($"{symbol}");
            Console.Write(" -> ");
        }
        
        public void PerformTask(int state = 1, int pos = 0)
        {
            if (state < 1 || state >= _conditionsAmount)
                throw new ArgumentOutOfRangeException(
                    $"Initial state cannot be equal {state} (only from 1 to {_conditionsAmount}");
            if (pos < 0 || pos > _instructionTape.Count)
                throw new ArgumentOutOfRangeException(
                    $"Initial position cannot be equal {pos} (only from 0 to {_instructionTape.Count}");
            
            while (state != 0)
            {
                if (state < 0 || state >= _conditionsAmount)
                    throw new ArgumentOutOfRangeException(
                        $"While performing the task, 'state' argument has gone out of range. Value: {state}");
                if (pos < 0 || pos > _instructionTape.Count)
                    throw new ArgumentOutOfRangeException(
                        $"While performing the task, 'pos' argument has gone out of range. Value: {pos}");
                
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

                DisplayTape();
            }
        }

        // Reads parameters, regulations and instructions from specified file
        public void ReadParameters(StreamReader inputFile)
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
            
            var tape = inputFile.ReadLine()?.ToArray();
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
                    turing.ReadParameters(input);

                turing.PerformTask();

//                using (var output = new StreamWriter(outputFile, false))
//                {
//                    turing.WriteOut(output);
//                }
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