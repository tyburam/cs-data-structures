using System;

namespace DataStructures.Tests.Enumerators.BinarySearchTree
{
    public class BaseTreeEnumeratorTests
    {
        protected readonly int[] PreOrderedElements = new int[5] {5, 6, 3, 4, 1};
        protected readonly int[] PostOrderedElements = new int[5] {1, 4, 3, 6, 5};
        protected readonly int[] LevelOrderedElements = new int[5] {5, 3, 6, 1, 4};

        protected BinarySearchTree<int> GetTreeWithElements()
        {
            var bst = new BinarySearchTree<int>();
            foreach(var e in PreOrderedElements){
                bst.Add(e);
            }
            return bst; 
        }
    }
}
