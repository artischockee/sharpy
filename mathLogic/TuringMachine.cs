using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mathLogic
{
    internal struct FuncScheme
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
        private readonly List<FuncScheme> _funcScheme;
        private readonly List<char> _alphabetPower;
        private List<char> _instructionTape;
        private int _conditionsAmount;
        private int _initialState;
        private int _finalState;
        private int _position;
       
        public TuringMachine()
        {
            _funcScheme = new List<FuncScheme>();
            _alphabetPower = new List<char>();
            _instructionTape = new List<char>();
            _conditionsAmount = 0;
        }

        public void ExportTape(StreamWriter outputFile)
        {
            outputFile.WriteLine(_instructionTape.ToArray());
        }

        // Trims all leading and trailing zeroes except for the closest ones
        private void MakeDecentTape(bool isNeedToAddZeroesAround = true)
        {
            var zero = _alphabetPower[0];
            var stringTape = new string(_instructionTape.ToArray());
            stringTape = stringTape.Trim(zero);
            if (isNeedToAddZeroesAround)
                stringTape = string.Concat(zero, stringTape, zero);
            _instructionTape = stringTape.ToList();
        }
        
        private void DisplayTape(int pos = 0)
        {
            for (var i = 0; i < _instructionTape.Count; ++i)
                Console.Write(i == pos ? $"[{_instructionTape[i]}]" : $"{_instructionTape[i]}");
            Console.Write(" -> ");
        }

        public void PerformTask()
        {
            PerformTask(_initialState, _finalState, _position);
        }
        
        // Imitates the Turing machine's work in accordance to specified parameters and schemes
        public void PerformTask(int state, int finalState, int pos)
        {
            if (state < 0 || state > _conditionsAmount)
                throw new ArgumentOutOfRangeException(nameof(state));
            if (pos < 0 || pos > _instructionTape.Count)
                throw new ArgumentOutOfRangeException(nameof(pos));

            while (state != finalState)
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
                    _instructionTape.Insert(0, _alphabetPower[0]);
                    ++pos;
                }
                else if (pos == _instructionTape.Count)
                    _instructionTape.Add(_alphabetPower[0]);

                DisplayTape(pos);
            }

            MakeDecentTape(false);
        }

        // Reads parameters, regulations and instructions from specified file
        public void ImportParameters(StreamReader inputFile)
        {
            if (inputFile.EndOfStream)
                throw new EndOfStreamException("Input file is empty.");

            var buffer = inputFile.ReadLine()?.Split();
            if (string.IsNullOrEmpty(buffer?.ToString()))
                throw new Exception("Input file buffer was null or empty. Check the input file.");
            const int neededLen = 3;
            if (buffer.Length != neededLen)
                throw new Exception(
                    $"First line in input file contains {buffer.Length} symbols (needed: {neededLen}).");

            var statesAmount = int.Parse(buffer[0]);
            var regulationsAmount = int.Parse(buffer[1]);
            var alphabetPow = int.Parse(buffer[2]);

            buffer = inputFile.ReadLine()?.Split();
            if (string.IsNullOrEmpty(buffer?.ToString()))
                throw new Exception("Input file buffer was null or empty. Check the input file.");
            if (buffer.Length > alphabetPow)
                Console.WriteLine(
                    "Warning: Found an alphabet power greater than the specified one. " +
                    $"Only first {alphabetPow} entries will be used.");

            for (var i = 0; i < alphabetPow; ++i)
                _alphabetPower.Add(char.Parse(buffer[i]));

            const int regulationLength = 5;
            for (var i = 0; i < regulationsAmount; ++i)
            {
                var regulation = inputFile.ReadLine()?.Split();
                if (string.IsNullOrEmpty(regulation?.ToString()))
                    throw new Exception(
                        "One of the parsed regulation lines was empty. Check the input file.");
                if (regulation.Length != regulationLength)
                    throw new Exception(
                        $"Error in regulation rule (line {i + 1}): needed to contain {regulationLength} numbers");

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
            if (string.IsNullOrEmpty(tape?.ToString()))
                throw new Exception("Can't find the tape in the penultimate line of the input file.");

            foreach (var symbol in tape)
                _instructionTape.Add(symbol);

            var states = inputFile.ReadLine()?.Split();
            if (string.IsNullOrEmpty(states?.ToString()))
                throw new Exception("Can't find the state and position parameters in the last line of the input file.");
            
            _initialState = int.Parse(states[0]);
            _finalState = int.Parse(states[1]);
            _position = int.Parse(states[2]);
            
            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("File ending not found. One should contain 2 lines with integers.");

            _conditionsAmount = statesAmount;
        } // public void ReadParameters(StreamReader inputFile)
    } // public class TuringMachine

    public static class MainTuringMachine
    {
        public static void Execute()
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