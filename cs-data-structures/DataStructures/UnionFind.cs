using System;

namespace DataStructures
{
    /// <summary>
    /// This class represent a special usage data structure used for grouping elements
    /// of any collection
    /// </summary>
    public class UnionFind
    {
        public int InitialComponentsCount { get; }
        public int ComponentsCount { get; private set; }

        private int[] _componentsSizes;
        private int[] _parentNodes;

        public UnionFind(int componentsCount)
        {
            if(componentsCount <= 0) {
                throw new ArgumentException(nameof(componentsCount));
            }

            InitialComponentsCount = ComponentsCount = componentsCount;
            _componentsSizes = new int[componentsCount];
            _parentNodes = new int[componentsCount];

            for(var i = 0; i < componentsCount; i++) {
                _componentsSizes[i] = 1;
                _parentNodes[i] = i;
            }
        }

        /// <summary>
        /// Returns the index of the root element for the group to element belongs
        /// </summary>
        /// <param name="elementIndex">Index of the element</param>
        /// <returns>
        /// Index of the root element
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is greater or equal to
        /// the initial number of components</exception>
        public int Find(int elementIndex)
        {
            if(elementIndex >= InitialComponentsCount) 
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

        /// <summary>
        /// Merges elements into group
        /// </summary>
        /// <param name="p">Index of the first element</param>
        /// <param name="q">Index of the second element</param>
        /// <returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is greater or equal to
        /// the initial number of components</exception>
        public void Unify(int p, int q)
        {
            if(p >= InitialComponentsCount || q >= InitialComponentsCount)
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
            
            --ComponentsCount;
        }
    }
}
