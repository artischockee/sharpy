using System;
using System.IO;

namespace mathLogic
{
    internal class Implication
    {
        
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
            
//            var markov = new MarkovAlgorithm();
            
            try
            {
                using (var input = new StreamReader(inputFile))
//                    markov.ImportParameters(input);
                    
//                markov.PerformTask();
//                markov.Disp();

                using (var output = new StreamWriter(outputFile, false))
//                    markov.ExportWord(output);
                
                Console.WriteLine("Operations were successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}