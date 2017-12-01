using System;
using System.Collections;
using System.Collections.Generic;

namespace LW07T1
{
    public class DataStructure<T>
    {
        // List presents a way to implement classes, such as Array, Stack and Queue
        protected List<T> list;

        protected DataStructure()
        {
            this.list = new List<T>();
        }

        protected DataStructure(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            else
                this.list = new List<T>(capacity);
        }

        protected DataStructure(T obj, int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException();
            else {
                this.list = new List<T>(length);
                for (int i = 0; i < this.list.Capacity; ++i)
                this.list.Add(obj);
            }
        }

        protected DataStructure(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException();
            else
                this.list = new List<T>(list);
        }

        public virtual void Clear()
        {
            list.Clear();
        }

        public int Length
        {
            get { return list.Count; }
        }

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        public virtual IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public virtual void Display()
        {
            foreach (var v in list)
                Console.Write(v + " ");
            Console.WriteLine();
        }

        // this method implements adding elements in Array, Stack and Queue;
        public virtual void Add(params T[] list)
        {
            for (int i = 0; i < list.Length; ++i)
                this.list.Add(list[i]);
        }
    } // public class DataStructure
} // namespace LW07T1
