using System;

namespace DataStructures
{
    public class NullableArray<T>
    {
        private object[] _array;

        public NullableArray(int capacity)
        {
            if(capacity <= 0) 
            {
                throw new ArgumentException(nameof(capacity));
            }

            _array = new object[capacity];
            for(var i = 0; i < _array.Length; i++) 
            {
                _array[i] = null;
            }
        }

        public T this[int index]
        {
            get 
            {
                if(index < 0 || index >= _array.Length) 
                {
                    throw new IndexOutOfRangeException();
                }
                return (T)_array[index];
            }
            set
            {
                if(index < 0 || index >= _array.Length) 
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        public bool HasValueAt(int index)
        {
            try {
                var temp = this[index];
                if(temp == null) 
                {
                    return false;
                } 
            } catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index >= _array.Length) 
            {
                throw new IndexOutOfRangeException();
            }

            _array[index] = null;
        }
    }
}