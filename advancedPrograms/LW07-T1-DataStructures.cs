using System;
using System.Collections;
using System.Collections.Generic;

namespace LW07T1
{
    public class DataStructure<T>
    {
        protected List<T> list;

        public DataStructure()
        {
            this.list = new List<T>();
        }

        public DataStructure(int capacity)
        {
            this.list = new List<T>(capacity);
        }

        public DataStructure(T obj, int length)
        {
            this.list = new List<T>(length);
            for (int i = 0; i < this.list.Capacity; ++i)
                this.list.Add(obj);
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
                Console.Write("{0,-3}", v);
            Console.WriteLine();
        }

        public virtual void Add(params T[] list)
        {
            for (int i = 0; i < list.Length; ++i)
                this.list.Add(list[i]);
        }
    } // public class DataStructure

    public class Array<T> : DataStructure<T>
    {
        public Array() : base() {}
        public Array(int capacity) : base(capacity) {}
        public Array(T obj, int length) : base(obj, length) {}

        public override void Display()
        {
            Console.Write("Array: ");
            base.Display();
        }

        public void Clear(int index, int length)
        {
            int listSize = list.Count;
            int clBound = index + length; // i.e. clearing bound (upper)

            if (
                index < 0 || length < 0 ||
                index > listSize || clBound > listSize
            ) throw new IndexOutOfRangeException();
            else
                for (int i = index; i < clBound; ++i)
                    list[i] = default(T);
        }

        public static void Copy(Array<T> src, Array<T> dest, int length)
        {
            if (src == null || dest == null)
                throw new ArgumentNullException();
            else
            if (length < 0)
                throw new ArgumentOutOfRangeException();
            else
            if (length > src.Length || length > dest.Length)
                throw new ArgumentException();

            for (int i = 0; i < length; ++i)
                dest[i] = src[i];
        }

        public static void Copy(
            Array<T> src, int srcIndex, Array<T> dest, int destIndex,
            int length
        )
        {
            if (src == null || dest == null)
                throw new ArgumentNullException();
            else
            if (srcIndex < 0 || destIndex < 0 || length < 0)
                throw new ArgumentOutOfRangeException();

            int srcLen = src.Length;
            int destLen = dest.Length;
            int cpBound = srcIndex + length; // i.e. copying bound (upper)

            if (cpBound > srcLen || cpBound > destLen)
                throw new ArgumentException();

            for (int i = srcIndex, j = destIndex; i < cpBound; ++i, ++j)
                dest[j] = src[i];
        }

        public void CopyTo(Array<T> destination, int index)
        {
            if (destination == null)
                throw new ArgumentNullException();
            else
            if (index < 0)
                throw new ArgumentOutOfRangeException();

            int srcLen = this.Length;
            int cpBound = srcLen + index; // i.e. copying bound (upper)

            if (cpBound > destination.Length)
                throw new ArgumentException();

            for (int i = 0, j = index; i < srcLen; ++i, ++j)
                destination[j] = this[i];
        }
    } // public class Array<T> : DataStructure<T>

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



    } // public class Stack<T> : DataStructure<T>
} // namespace LW07T1
