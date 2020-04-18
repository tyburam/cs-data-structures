using System;
using DataStructures.Interfaces;

namespace DataStructures
{
    public class LinkedList<T> : IndexedDataStructure<T>, IIndexedModificableDataStructure<T>
    {
        private LinkedListElement<T> _head;

        public LinkedList()
        {
            _head = null;
        }

        public void Add(T element)
        {
            ++Length;
            if(_head == null) 
            {
                _head = new LinkedListElement<T>(element);
                return;
            }

            var current = _head;
            while(current.Next != null) {
                current = current.Next;
            }
            current.Next = new LinkedListElement<T>(element);
        }

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
                _head = new LinkedListElement<T>(element, prevHead);
                ++Length;
                return;
            }

            var current = _head;
            for(var i = 0; i < index-1; i++) {
                current = current.Next;
            }
            var previousNext = current.Next;
            current.Next = new LinkedListElement<T>(element, previousNext);
            ++Length;
        }

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
            LinkedListElement<T> previous = null;
            for(var i = 0; i < removeIndex; i++) {
                previous = current;
                current = current.Next;
            }
            previous.Next = current.Next;
            current = null;
            --Length;
        }
    }
}
