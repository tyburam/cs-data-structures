using System;

namespace DataStructures
{
    public class UnionFind
    {
        public int Length { get; }
        public int Components { get; private set; }

        private int[] _componentsSizes;
        private int[] _parentNodes;

        public UnionFind(int length)
        {
            if(length <= 0) {
                throw new ArgumentException(nameof(length));
            }

            Length = Components = length;
            _componentsSizes = new int[length];
            _parentNodes = new int[length];

            for(var i = 0; i < length; i++) {
                _componentsSizes[i] = 1;
                _parentNodes[i] = i;
            }
        }

        public int Find(int elementIndex)
        {
            if(elementIndex >= Length) 
            {
                throw new IndexOutOfRangeException();
            }

            int rootIndex = elementIndex;
            while(rootIndex != _parentNodes[rootIndex]) 
            {
                rootIndex = _parentNodes[rootIndex];
            }

            while(elementIndex != rootIndex)
            {
                int parentIndex = _parentNodes[elementIndex];
                _parentNodes[elementIndex] = rootIndex;
                elementIndex = parentIndex; 
            }

            return rootIndex;
        }

        public void Unify(int p, int q)
        {
            if(p >= Length || q >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if(p == q) {
                return;
            }

            int rootOfP = Find(p), rootOfQ = Find(q);
            if(rootOfP == rootOfQ) return; //already in the same qroup

            // move smaller group into larger group
            if(_componentsSizes[rootOfP] < _componentsSizes[rootOfQ])
            {
                _componentsSizes[rootOfQ] += _componentsSizes[rootOfP];
                _parentNodes[rootOfP] = rootOfQ;
            }
            else 
            {
            _componentsSizes[rootOfP] += _componentsSizes[rootOfQ];
            _parentNodes[rootOfQ] = rootOfP;
            }
            
            --Components;
        }
    }
}
