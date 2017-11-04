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

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        public virtual IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
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

        // temporarily, perhaps
        public int Length
        {
            get { return list.Count; }
        }

        public void Display()
        {
            foreach (var v in list)
                Console.Write("{0,-3}", v);
            Console.WriteLine();
        }

        public void Clear(int index, int length)
        {
            int listSize = list.Count;
            if (
                index < 0 ||
                index > listSize ||
                (index + length) > listSize
            ) throw new IndexOutOfRangeException();

            else for (int i = index; i < (index + length); ++i)
                list[i] = default(T);
        }

        public static void Copy(Array<T> src, Array<T> dest, int length)
        {
            for (int i = 0; i < length; ++i)
                dest[i] = src[i];
        }

        public static void Copy(
            Array<T> src, int srcIndex, Array<T> dest, int destIndex,
            int length
        )
        {
            for (
                int i = srcIndex, j = destIndex;
                i < (srcIndex + length) && j < (destIndex + length);
                ++i, ++j
            )
                dest[j] = src[i];
        }

    } // public class Array : DataStructure<T>
} // namespace LW07T1
