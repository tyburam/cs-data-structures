using System;
using DataStructures.Interfaces;

namespace DataStructures
{
    /// <summary>
    /// This class represents a collection of elements implemented as an dynamically resized array
    /// </summary>
    public class DynamicArray<T> : IndexedDataStructure<T>, IIndexedModificableDataStructure<T>
    {
        private Array _array;
        private int _capacity = 32;

        public DynamicArray() : this(0) {}

        public DynamicArray(int initialLength)
        {
            if(initialLength < 0) {
                throw new ArgumentException(nameof(initialLength));
            }

            if(initialLength > _capacity)
            {
                _capacity = initialLength;
            }

            _array = Array.CreateInstance(typeof(T), _capacity);
            Length = initialLength;
        }

        /// <summary>
        /// Returns the element at given index
        /// </summary>
        /// <param name="index">Index of the element</param>
        /// <returns>
        /// The element on that particular index
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the collection is empty or 
        /// the index is either lesser than 0 or greater or equal to the length of the collection</exception>
        public override T GetAt(int index)
        {
            if(Length == 0 || index < 0 || index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }
            return (T)_array.GetValue(index);
        } 

        /// <summary>
        /// Sets the value at given index
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="index">Index of the element</param>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is either lesser 
        /// than 0 or greater or equal to the current capacity of the collection</exception>
        public override void SetAt(T element, int index)
        {
            if(index < 0 || index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }
            _array.SetValue(element, index);
            if(index > Length)
            {
                Length = index+1;
            }
        }

        /// <summary>
        /// Adds element to the end of the collection
        /// </summary>
        /// <param name="element">Element that will be added</param>
        public void Add(T element)
        {
            if(Length == _capacity) {
                ResizeAndCopy();
            }

            _array.SetValue(element, Length);
            ++Length;
        }

        /// <summary>
        /// Inserts given element at given index
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="index">insertion index</param>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is either lesser 
        /// than 0 or greater than the length of the collection</exception>
        public override void InsertAt(T element, int index)
        {
            if(index < 0 || index > Length) 
            {
                throw new IndexOutOfRangeException();
            }

            if(index == 0 && Length == 0) {
                Add(element);
                return;
            }

            if(Length + 1 >= _capacity) {
                _capacity += 10;
            }

            var newArray = Array.CreateInstance(typeof(T), _capacity);
            newArray.SetValue(element, index);

            for(int i = 0, j = 0 ; i < Length; i++, j++) 
            {
                if(j == index) {
                    ++j;
                }

                newArray.SetValue((T)_array.GetValue(i), j);
            }
            ++Length;
            _array = newArray;
        }

        /// <summary>
        /// Finds index of the given element
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>
        /// Index of the element if it's in the collection or -1 if it's not
        /// </returns>
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

        /// <summary>
        /// Removes given element from the collection. 
        /// It does nothing if collection is empty or element is not in
        /// </summary>
        /// <param name="element">Element< to be removed</param>
        public void Remove(T element)
        {
            var removeIndex = IndexOf(element);
            if(-1 == removeIndex) 
            {
                return;
            }
            RemoveAt(removeIndex);
        }

        /// <summary>
        /// Removes element of the collection
        /// </summary>
        /// <param name="index">Deletion index</param>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is either lesser 
        /// than 0 or greater or equal to the length of the collection</exception>
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

        public void Clear()
        {
            _array = Array.CreateInstance(typeof(T), _capacity);
            Length = 0;
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