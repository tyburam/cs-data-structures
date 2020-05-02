using System;

namespace DataStructures
{
    /// <summary>
    /// This class represents a collection of elements stored and accessed in FIFO way
    /// but internally ordered using CompareTo method 
    /// </summary>
    public class PriorityQueue<T> where T: IComparable
    {
        public int Length { get; private set; }
        private DynamicArray<T> _elements;

        public PriorityQueue()
        {
            _elements = new DynamicArray<T>(15);
        }

        /// <summary>
        /// Returns the element from the beggining of the collection without actually removing it
        /// </summary>
        /// <returns>
        /// Element at the begging on the collection
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the collection is empty</exception>
        public T Peek()
        {
            if(Length == 0) {
                throw new IndexOutOfRangeException();
            }
            return _elements[0];
        }

        /// <summary>
        /// Adds element to collection
        /// </summary>
        /// <param name="element">Element</param>
        public void Enqueue(T element)
        {
            var addedIndex = Length;
            ++Length;
            _elements.Add(element);
            
            var parentIndex = (addedIndex - 1) / 2;
            while(addedIndex > 0 && _elements[addedIndex].CompareTo(_elements[parentIndex]) == -1)
            {
                var tmp = _elements[parentIndex];
                _elements[parentIndex] = _elements[addedIndex];
                _elements[addedIndex] = tmp;

                addedIndex = parentIndex;
                parentIndex = (addedIndex - 1) / 2;
            }
        }

        /// <summary>
        /// Returns the first element of the collection
        /// </summary>
        /// <param name="index">Index of the element</param>
        /// <returns>
        /// The element on that particular index
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the collection is empty</exception>
        public T Dequeue()
        {
            if(Length == 0) {
                throw new IndexOutOfRangeException();
            }

            var retValue = _elements[0];
            --Length;

            if(Length == 0) {
                return retValue;
            }

            var currentIndex = 0;
            while(true) 
            {
                int left = 2 * currentIndex + 1, right = 2 * currentIndex + 2, smallest = left;

                if(right < Length && _elements[right].CompareTo(_elements[left]) == -1)
                {
                    smallest = right;
                }

                if(left >= Length || _elements[currentIndex].CompareTo(_elements[smallest]) != -1) {
                    break;
                }

                var tmp = _elements[smallest];
                _elements[smallest] = _elements[currentIndex];
                _elements[currentIndex] = tmp;
                currentIndex = smallest;
            }

            return retValue;
        }
    }
}
