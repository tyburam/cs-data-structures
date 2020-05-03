using System;
using DataStructures.Elements;
using DataStructures.Interfaces;

namespace DataStructures
{
    /// <summary>
    /// This class represents a collection of elements organised into binary search tree
    /// </summary>
    public class BinarySearchTree<T>: IModificableDataStructure<T> where T: IComparable 
    {
        public int NodesCount { get; set; }
        public BinaryNode<T> RootNode { get; private set; }


        /// <summary>
        /// Adds element to the tree
        /// </summary>
        /// <param name="element">Element that will be added</param>
        public void Add(T element)
        {
            if(RootNode == null) {
                RootNode = new BinaryNode<T>(element);
                ++NodesCount;
                return;
            }

            AddNode(RootNode, element);
            ++NodesCount;
        }

        private void AddNode(BinaryNode<T> parentNode, T element)
        {
            if(element.CompareTo(parentNode.Value) < 0)
            {
                if(parentNode.Left == null) 
                {
                    parentNode.Left = new BinaryNode<T>(element);
                    return;
                }
                AddNode(parentNode.Left, element);
            }

            if(parentNode.Right == null) 
            {
                parentNode.Right = new BinaryNode<T>(element);
                return;
            }
            AddNode(parentNode.Right, element);
        }

        /// <summary>
        /// Removes element from the tree
        /// </summary>
        /// <param name="element">Element that will be removed</param>
        public void Remove(T element)
        {
            if(RootNode == null) 
            {
                return;
            }
            
            RootNode = RemoveNode(RootNode, element);
            --NodesCount;
        }

        private BinaryNode<T> RemoveNode(BinaryNode<T> parentNode, T element)
        {
            if(parentNode == null) 
            {
                return parentNode;
            }

            var cmp = element.CompareTo(parentNode.Value);
            if(cmp < 0) 
            {
                parentNode.Left = RemoveNode(parentNode.Left, element);
            }
            else if(cmp > 0)
            {
                parentNode.Right = RemoveNode(parentNode.Right, element);
            }
            else
            {
                if(parentNode.Left == null) 
                {
                    var rightChild = parentNode.Right;
                    parentNode = null;
                    return rightChild;
                }

                if(parentNode.Right == null) 
                {
                    var leftChild = parentNode.Left;
                    parentNode = null;
                    return leftChild;
                }

                var smallest = FindMinimalValueNode(parentNode.Right);
                parentNode.Value = smallest.Value;
                parentNode.Right = RemoveNode(parentNode.Right, smallest.Value);
            }
            return parentNode;
        }

        private BinaryNode<T> FindMinimalValueNode(BinaryNode<T> node)
        {
            var minimalNode = node;
            while(minimalNode.Left != null) 
            {
                minimalNode = minimalNode.Left;
            }
            return minimalNode;
        }
    }
}
