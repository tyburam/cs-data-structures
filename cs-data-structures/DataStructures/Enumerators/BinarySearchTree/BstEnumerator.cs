using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Elements;

namespace DataStructures.Enumerators.BinarySearchTree
{
    public abstract class BstEnumerator<T> : IEnumerator<BinaryNode<T>>
    {
        protected List<BinaryNode<T>> _nodes;
        protected int _current;

        public BstEnumerator(BinaryNode<T> root)
        {
            _current = -1;
            _nodes = new List<BinaryNode<T>>();
            FillNodes(root);
        }

        protected abstract void FillNodes(BinaryNode<T> node);

        public BinaryNode<T> Current 
        {
            get
            {
                try
                {
                    return _nodes[_current];
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            ++_current;
            return (_current >= _nodes.Count);
        }

        public void Reset()
        {
            _current = -1;
        }
    }
}
