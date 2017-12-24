using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mathLogic
{
    public class Set
    {
        public readonly List<int> List;

        public Set(string[] set)
        {
            if (set.Length == 0)
                throw new ArgumentNullException(nameof(set));
            
            List = new List<int>(set.Select(int.Parse));
        }
    }
    
    public class TruthSets
    {
        private const int SetsAmount = 3;
        
        private readonly List<Set> _sets;
        private readonly List<string> _resultSets;

        public TruthSets()
        {
            _sets = new List<Set>();
            _resultSets = new List<string>();
        }
        
        private void PredicateOne()
        {
            var list = _sets[0].List.Where(i => _sets[1].List.Contains(i) && _sets[2].List.Contains(i)).ToArray();
            _resultSets.Add(string.Join(" ", list));
        }
        
        private void PredicateTwo()
        {
            var list = _sets[0].List.Where(i => _sets[1].List.Contains(i) || _sets[2].List.Contains(i)).ToArray();
            _resultSets.Add(string.Join(" ", list));
        }
        
        private void PredicateThree()
        {
            var list = _sets[0].List.Where(i => !_sets[1].List.Contains(i)).ToArray();
            _resultSets.Add(string.Join(" ", list));
        }
        
        private void PredicateFour()
        {
            var list = _sets[0].List.Where(i => _sets[1].List.Contains(i) && !_sets[2].List.Contains(i)).ToArray();
            _resultSets.Add(string.Join(" ", list));
        }
        
        public void Export(StreamWriter outputFile)
        {
            foreach (var set in _resultSets)
                outputFile.WriteLine(set);
        }

        public void PerformTask()
        {
            PredicateOne();
            PredicateTwo();
            PredicateThree();
            PredicateFour();
        }
        
        public void ImportSets(StreamReader inputFile)
        {
            if (inputFile.EndOfStream)
                throw new EndOfStreamException("Input file is empty.");

            for (var i = 0; i < SetsAmount; ++i)
            {
                var buffer = inputFile.ReadLine();
                if (string.IsNullOrEmpty(buffer))
                    throw new Exception("Empty line in the input file found.");

                var setSize = int.Parse(buffer);
            
                buffer = inputFile.ReadLine();
                var set = buffer?.Split();
                if (set.Length != setSize)
                    throw new ArgumentOutOfRangeException("Error in set size.");

                _sets.Add(new Set(set));
            }
            
            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("Input file ending not found.");
        }
    }
    
    public class MainTruthSets : IProgram
    {
        private const string ProgramName = "Truth Sets";
        public string Name => ProgramName;
        
        public void Execute()
        {
            const string inputFile = "input-05";
            const string outputFile = "output-05";
            
            var sets = new TruthSets();
            
            try
            {
                using (var input = new StreamReader(inputFile))
                    sets.ImportSets(input);

                sets.PerformTask();
                
                using (var output = new StreamWriter(outputFile, false))
                    sets.Export(output);
                
                Console.WriteLine("Operations were successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Operations were not successfully completed.");
            }
        }
    }
}