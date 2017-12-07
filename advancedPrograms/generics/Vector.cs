using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace generics
{
    public class Vector<T> : IEnumerable<T>, IEquatable<Vector<T>>
    {
        private readonly List<T> _vector;
        private int Count => _vector.Count;

        public Vector()
        {
            _vector = new List<T>();
        }

        public Vector(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            
            _vector = new List<T>(collection);
        }
        
        public void Clear()
        {
            _vector.Clear();
        }
        
        public void Add(params T[] list)
        {
            foreach (var t in list)
                _vector.Add(t);
        }

        public static bool operator ==(Vector<T> obj1, Vector<T> obj2)
        {
            if ((object)obj1 == null || (object)obj2 == null)
                throw new ArgumentNullException();
            if (obj1.Count != obj2.Count)
                throw new ArgumentException("Vectors should be of one size");

            return !obj1.Where((t, i) => !Equals(t, obj2[i])).Any();
        }
        
        public static bool operator !=(Vector<T> obj1, Vector<T> obj2)
        {
            return !(obj1 == obj2);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Vector<T>)) return false;
            return Equals((Vector<T>) obj);
        }

        public bool Equals(Vector<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_vector, other._vector);
        }

        public override int GetHashCode()
        {
            return _vector != null ? _vector.GetHashCode() : 0;
        }

        private T this[int i]
        {
            get { return _vector[i]; }
            set { _vector[i] = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _vector.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}