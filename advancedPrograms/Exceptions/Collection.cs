using System;
using System.Collections;
using System.Collections.Generic;

namespace Exceptions
{
    internal abstract class Program
    {
        protected internal virtual void ShowName()
        {
            Console.WriteLine("An empty field (virtual method of ClassesContainer class)");
        }

        protected internal virtual void Execute()
        {
            Console.WriteLine("Warning: Nothing to execute from ClassesContainer class");
        }
    }
    
    internal  class Collection : Program, IEnumerable<Program>
    {
        // Please, don't touch this constant.
        // The program feels itself pretty good with this very number (1).
        // Otherwise, see usages of this one - especially in Execute() method.
        private const int InitialIndexOfProgram = 1;
        private readonly List<Program> _programs;

        // Add new instances here
        public Collection()
        {
            _programs = new List<Program>
            {
                new ThreeArrays(),
                new Notations(),
                new Transportation(),
                new Functions(),
                new VectorMain(),
                new SortingMain()
            };
        }

        public void Display()
        {
            var index = InitialIndexOfProgram;
            foreach (var item in _programs)
            {
                Console.Write($"[{index++}] ");
                item.ShowName();
            }
        }

        public void Execute(int programIndex)
        {
            if (programIndex < InitialIndexOfProgram || programIndex > _programs.Count)
                throw new ArgumentOutOfRangeException(nameof(programIndex));
            
            _programs[--programIndex].Execute();
        }

        IEnumerator<Program> IEnumerable<Program>.GetEnumerator()
        {
            return _programs.GetEnumerator();
        }
        
        public IEnumerator GetEnumerator()
        {
            return _programs.GetEnumerator();
        }
    }
}