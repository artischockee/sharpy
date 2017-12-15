using System;
using System.Collections;
using System.Collections.Generic;

namespace Exceptions
{
    internal class Vector : IEnumerable<int>
    {
        public const int MaxSize = 30;

        private readonly List<int> _vector;
        public int Count => _vector.Count;

        public Vector()
        {
            _vector = new List<int>(MaxSize);
        }

        public Vector(int size)
        {
            if (size <= 0 || size > MaxSize)
                throw new ArgumentOutOfRangeException(nameof(size));

            _vector = new List<int>(size);
        }
        
        public void Clear()
        {
            _vector.Clear();
        }
        
        public void Add(params int[] list)
        {
            if (list.Length > MaxSize - _vector.Count)
                throw new ArgumentOutOfRangeException();
            
            foreach (var t in list)
                _vector.Add(t);
        }

        public void Display()
        {
            foreach (var element in _vector)
                Console.Write($"{element} ");
            Console.WriteLine();
        }

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= Count)
                    throw new IndexOutOfRangeException("Cannot get access to the specified index.");
                
                return _vector[i];
            }
            private set
            {
                if (i < 0 || i >= Count)
                    throw new IndexOutOfRangeException("Cannot get access to the specified index.");
                
                _vector[i] = value;
            }
        }

        public static Vector operator --(Vector vector)
        {
            if (vector.Count == 0)
                throw new IndexOutOfRangeException();
            
            var temp = vector;
            temp._vector.RemoveAt(0);
            return temp;
        }

        public static Vector operator +(Vector vector, int newElement)
        {
            if (vector.Count >= MaxSize)
                throw new IndexOutOfRangeException();

            var temp = vector;
            temp.Add(newElement);
            return temp;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _vector.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    internal class VectorMain : Program
    {
        private const string ProgramName = "Vector Implementation";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }
        
        protected internal override void Execute()
        {
            try
            {
                var vector = new Vector(5)
                {
                    4, 16, 11, 6, 2
                };

                vector += 14;
                vector.Display();
                vector += 24;
                vector.Display();
                
                Console.WriteLine($"Vector\'s size is {vector.Count}");
                Console.WriteLine("Program has been successfully completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}