using System;
using DataStructures.Interfaces;
using DataStructures.Elements;

namespace DataStructures
{
    /// <summary>
    /// This class represents a collection of elements implemented as an list of double linked elements
    /// </summary>
    public class DoubleLinkedList<T> : IndexedDataStructure<T>, IIndexedModificableDataStructure<T>
    {
        private DoubleLinkedElement<T> _head;

        public DoubleLinkedList()
        {
            _head = null;
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
            if(_head == null || index < 0 || index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }

            var current = _head;
            for(var i = 0; i < index; i++) {
                current = current.Next;
            }
            return current.Value;
        }

        /// <summary>
        /// Changes the value at given index
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="index">Index of the element</param>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is either lesser 
        /// than 0 or greater or equal to the length of the collection</exception>
        public override void SetAt(T element, int index)
        {
            if(index < 0 || index >= Length) 
            {
                throw new IndexOutOfRangeException();
            }
            
            var current = _head;
            for(var i = 0; i < index; i++) {
                current = current.Next;
            }
            current.Value = element;
        }

        /// <summary>
        /// Adds element to the end of the collection
        /// </summary>
        /// <param name="element">Element that will be added</param>
        public void Add(T element)
        {
            ++Length;
            if(_head == null) 
            {
                _head = new DoubleLinkedElement<T>(element);
                return;
            }

            var current = _head;
            while(current.Next != null) {
                current = current.Next;
            }
            current.Next = new DoubleLinkedElement<T>(element, current);
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

            if(index == 0) {
                if(_head == null ) 
                {
                    Add(element);
                    return;
                }
                var prevHead = _head;
                _head = new DoubleLinkedElement<T>(element, null, prevHead);
                prevHead.Prev = _head;
                ++Length;
                return;
            }

            var current = _head;
            for(var i = 0; i < index-1; i++) {
                current = current.Next;
            }
            var previousNext = current.Next;
            current.Next = new DoubleLinkedElement<T>(element, current, previousNext);
            previousNext.Prev = current.Next;
            ++Length;
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
            if(_head == null) 
            {
                return -1;
            }

            var current = _head;
            for(var i = 0; i < Length; i++) {
                if(current.Value.Equals(element)) {
                    return i;
                }
                current = current.Next;
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
            if(_head == null) {
                return;
            }

            var removeIndex = IndexOf(element);
            if(removeIndex == -1) {
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
            if(_head == null) {
                return;
            }

            if(removeIndex < 0 || removeIndex >= Length) {
                throw new IndexOutOfRangeException();
            }

            if(removeIndex == 0) {
                _head = _head.Next;
                --Length;
                return;
            }

            var current = _head;
            for(var i = 0; i < removeIndex; i++) {
                current = current.Next;
            }
            current.Prev.Next = current.Next;
            current = null;
            --Length;
        }
    }
}
