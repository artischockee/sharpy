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

        public DataStructure(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException();

            this.list = new List<T>(list);
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

        // this method implements adding elements in Array, Stack and Queue;
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
        public Array(List<T> list) : base(list) {}

        public override void Display()
        {
            Console.Write("Array: ");
            base.Display();
        }

        public static void Clear(
            Array<T> array, int index, int length
        )
        {
            if (array == null)
                throw new ArgumentNullException();

            int listSize = array.list.Count;
            int clBound = index + length; // i.e. clearing bound (upper)

            if (
                index < 0 || length < 0 ||
                index > listSize || clBound > listSize
            ) throw new IndexOutOfRangeException();
            else
                for (int i = index; i < clBound; ++i)
                    array.list[i] = default(T);
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

        public static T Find(
            Array<T> array, Predicate<T> match
        )
        {
            if (array == null || match == null)
                throw new ArgumentNullException();
            else
                return array.list.Find(match);
        }

        public static Array<T> FindAll(
            Array<T> array, Predicate<T> match
        )
        {
            if (array == null || match == null)
                throw new ArgumentNullException();

            var result = new Array<T>(
                array.list.FindAll(match)
            );
            return result;
        }

        public static void Sort(Array<T> array)
        {
            array.list.Sort();
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

    public class Queue<T> : DataStructure<T>
    {
        public Queue() : base() {}
        public Queue(int capacity) : base(capacity) {}

        public int Count
        {
            get { return base.Length; }
        }

        public override void Display()
        {
            Console.Write("Queue: ");
            base.Display();
        }

        public void Clear()
        {
            list.Clear();
        }


    } // public class Queue<T> : DataStructure<T>
} // namespace LW07T1
