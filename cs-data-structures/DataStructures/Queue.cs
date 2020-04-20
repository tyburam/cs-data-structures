using System;
using DataStructures.Elements;

namespace DataStructures
{
    public class Queue<T>
    {
        private LinkedElement<T> _first;
        private LinkedElement<T> _last;

        public int Length { get; private set; }

        public T Peek()
        {
            if(_first == null) {
                throw new IndexOutOfRangeException();
            }
            return _first.Value;
        }

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
