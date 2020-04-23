using System;
using DataStructures.Elements;

namespace DataStructures
{
    public class Stack<T>
    {
        private DoubleLinkedElement<T> _first;
        private DoubleLinkedElement<T> _last;

        public int Length { get; private set; }

        public T Peek()
        {
            if(_last == null) {
                throw new IndexOutOfRangeException();
            }
            return _last.Value;
        }

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
