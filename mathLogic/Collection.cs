using System;
using System.Collections.Generic;

namespace mathLogic
{
    public class Collection
    {
        // Please, don't touch this constant.
        // The program feels itself pretty good with this very number (1).
        // Otherwise, see usages of this one - especially in Execute() method.
        private const int InitialIndexOfProgram = 1;
        private readonly List<IProgram> _programs;

        // Add new instances here
        public Collection()
        {
            _programs = new List<IProgram>
            {
                new MainNormalForms(),
                new MainTuringMachine(),
                new MainMarkovAlgorithm(),
                new MainImplication()
            };
        }

        public void Display()
        {
            var index = InitialIndexOfProgram;
            foreach (var item in _programs)
                Console.WriteLine($"[{index++}] {item.Name}");
        }

        public void Execute(int programIndex)
        {
            if (programIndex < InitialIndexOfProgram || programIndex > _programs.Count)
                throw new ArgumentOutOfRangeException(nameof(programIndex));
            
            _programs[--programIndex].Execute();
        }
    }
}