using System;
using System.Collections.Generic;

namespace LW07T1
{
    public class Queue<T> : DataStructure<T>
    {
        public Queue() : base() {}
        public Queue(int capacity) : base(capacity) {}

        public int Count
        {
            get { return base.Length; }
        }

        public bool Contains(T obj)
        {
            for (int i = 0; i < list.Count - 1; ++i)
                if (list[i].Equals(obj))
                    return true;
            return false;
        }

        public T Dequeue()
        {
            if (list.Count == 0)
                throw new InvalidOperationException();

            T firstElement = list[0];
            list.RemoveAt(0);
            return firstElement;
        }

        public override void Display()
        {
            Console.Write("Queue: ");
            base.Display();
        }

        public void Enqueue(params T[] list)
        {
            base.Add(list);
        }

        public T Peek()
        {
            if (list.Count == 0)
                throw new InvalidOperationException();
            else
                return (list[0]);
        }
    } // public class Queue<T> : DataStructure<T>
}
