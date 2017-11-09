using System;
using System.Collections.Generic;

namespace LW07T1
{
    public class Stack<T> : DataStructure<T>
    {
        public Stack() : base() {}
        public Stack(int capacity) : base(capacity) {}

        public int Count
        {
            get { return base.Length; }
        }

        public override void Display()
        {
            Console.Write("Stack: ");
            base.Display();
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T obj)
        {
            for (int i = (list.Count - 1); i >= 0; --i)
                if (list[i].Equals(obj))
                    return true;
            return false;
        }

        public T Peek()
        {
            int lastIndex = list.Count - 1;

            if (lastIndex == -1)
                throw new InvalidOperationException();
            else
                return (list[lastIndex]);
        }

        public T Pop()
        {
            int lastIndex = list.Count - 1;

            if (lastIndex == -1)
                throw new InvalidOperationException();

            T upperElement = list[lastIndex];
            list.RemoveAt(lastIndex);
            return upperElement;
        }

        public void Push(params T[] list)
        {
            base.Add(list);
        }
    } // public class Stack<T> : DataStructure<T>
} // namespace LW07T1
