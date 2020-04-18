using System;
using System.Text;

namespace DataStructures
{
    public class DynamicArray<T> 
    {
        private Array _array;
        private int _capacity;

        public int Length { get; private set; }

        public DynamicArray() : this(10) {}

        public DynamicArray(int initialCapacity)
        {
            _array = Array.CreateInstance(typeof(T), initialCapacity);
            _capacity = initialCapacity;
        }

        public T this[int index] 
        {  
            get 
            {
                return GetAt(index);
            }

            set
            {
                InsertAt(value, index);
            }
        }

        public T GetAt(int index)
        {
            if(index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }
            return (T)_array.GetValue(index);
        } 

        public void Add(T element)
        {
            if(Length == _capacity) {
                ResizeAndCopy();
            }

            _array.SetValue(element, Length);
            ++Length;
        }

        public void InsertAt(T element, int index)
        {
            if(index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }
            _array.SetValue(element, index);
        }

        public int IndexOf(T element)
        {
            for(var i = 0; i < Length; i++) 
            {
                if(((T)_array.GetValue(i)).Equals(element)) 
                {
                    return i;
                }
            }
            return -1;
        }

        public void Remove(T element)
        {
            var removeIndex = IndexOf(element);
            if(-1 == removeIndex) 
            {
                return;
            }
            RemoveAt(removeIndex);
        }

        public void RemoveAt(int removeIndex)
        {
            if(removeIndex >= Length) {
                throw new IndexOutOfRangeException();
            }

            var newArray = Array.CreateInstance(typeof(T), _capacity);
            for(int i = 0, j = 0 ; i < Length; i++, j++) 
            {
                if(i == removeIndex) {
                    --j;
                    continue;
                }

                newArray.SetValue((T)_array.GetValue(i), j);
            }
            _array = newArray;
        }

        public override string ToString() 
        {
            var sb = new StringBuilder("[");
            for(var i = 0; i < Length; i++) 
            {
                sb.Append((T)_array.GetValue(i));
                if(i < Length-1) {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        private void ResizeAndCopy()
        {
            _capacity += 10;
            var newArray = Array.CreateInstance(typeof(T), _capacity);
            Array.Copy (_array, 0, newArray, 0, Length);
            _array = newArray;
        }
    }
}