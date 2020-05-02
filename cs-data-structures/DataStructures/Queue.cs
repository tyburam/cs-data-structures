using System;
using DataStructures.Elements;

namespace DataStructures
{
    /// <summary>
    /// This class represents a collection of elements stored and accessed in FIFO way
    /// </summary>
    public class Queue<T>
    {
        private LinkedElement<T> _first;
        private LinkedElement<T> _last;

        public int Length { get; private set; }

        /// <summary>
        /// Returns the element from the beggining of the collection without actually removing it
        /// </summary>
        /// <returns>
        /// Element at the begging on the collection
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the collection is empty</exception>
        public T Peek()
        {
            if(_first == null) {
                throw new IndexOutOfRangeException();
            }
            return _first.Value;
        }

        /// <summary>
        /// Adds element to collection
        /// </summary>
        /// <param name="element">Element</param>
        public void Enqueue(T element)
        {
            ++Length;
            if(_first == null) {
                _first = new LinkedElement<T>(element);
                _last = _first;
                return;
            }

            if(_last == null) {
                _last = new LinkedElement<T>(element);
                _first.Next = _last;
                return;
            }

            _last.Next = new LinkedElement<T>(element);
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
            if(_first == null) {
                throw new IndexOutOfRangeException();
            }

            --Length;
            var currentFirst = _first;
            if(currentFirst.Next == null) {
                _first = _last = null;
                return currentFirst.Value;
            }

            _first = currentFirst.Next;
            return currentFirst.Value;
        }
    }
}
