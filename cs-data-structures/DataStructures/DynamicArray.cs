using System;
using DataStructures.Interfaces;

namespace DataStructures
{
    public class DynamicArray<T> : IndexedDataStructure<T>, IIndexedModificableDataStructure<T>
    {
        private Array _array;
        private int _capacity;

        public DynamicArray() : this(10) {}

        public DynamicArray(int initialCapacity)
        {
            _array = Array.CreateInstance(typeof(T), initialCapacity);
            _capacity = initialCapacity;
        }

        public override T GetAt(int index)
        {
            if(index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }
            return (T)_array.GetValue(index);
        } 

        public override void SetAt(T element, int index)
        {
            if(index < 0 || index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }
            _array.SetValue(element, index);
        }

        public void Add(T element)
        {
            if(Length == _capacity) {
                ResizeAndCopy();
            }

            _array.SetValue(element, Length);
            ++Length;
        }

        public override void InsertAt(T element, int index)
        {
            if(index == 0 && Length == 0) {
                Add(element);
                return;
            }

            if(index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }

            if(Length + 1 >= _capacity) {
                _capacity += 10;
            }
            var newArray = Array.CreateInstance(typeof(T), _capacity);
            for(int i = 0, j = 0 ; i < Length; i++, j++) 
            {
                if(i == index) {
                    newArray.SetValue(element, j);
                    --i;
                    continue;
                }

                newArray.SetValue((T)_array.GetValue(i), j);
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
            if(removeIndex < 0 || removeIndex >= Length) {
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
            --Length;
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