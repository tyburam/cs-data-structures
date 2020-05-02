using System;
using DataStructures.Elements;

namespace DataStructures
{
    /// <summary>
    /// This class represents a collection of elements stored and accessed in LIFO way
    /// </summary>
    public class Stack<T>
    {
        private DoubleLinkedElement<T> _first;
        private DoubleLinkedElement<T> _last;

        public int Length { get; private set; }

        /// <summary>
        /// Returns the element from the end of the collection without actually removing it
        /// </summary>
        /// <returns>
        /// Element at the end of the collection
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the collection is empty</exception>
        public T Peek()
        {
            if(_last == null) {
                throw new IndexOutOfRangeException();
            }
            return _last.Value;
        }

        /// <summary>
        /// Adds element to collection
        /// </summary>
        /// <param name="element">Element</param>
        public void Push(T element)
        {
            ++Length;
            if(_last == null) {
                _last = new DoubleLinkedElement<T>(element);
                if(_first == null) {
                    _first = _last;
                } else {
                    _first.Next = _last;
                    _last.Prev = _first;
                }
                return;
            }

            _last.Next = new DoubleLinkedElement<T>(element, _last);
            _last = _last.Next;
        }

        /// <summary>
        /// Returns the last element of the collection
        /// </summary>
        /// <returns>
        /// The last element of the collection
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the collection is empty</exception>
        public T Pop()
        {
            if(_last == null) {
                throw new IndexOutOfRangeException();
            }

            --Length;
            var currentLast = _last;
            _last = currentLast.Prev;
            return currentLast.Value;
        }
    }
}
