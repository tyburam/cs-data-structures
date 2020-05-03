using DataStructures.Elements;

namespace DataStructures.Enumerators.BinarySearchTree
{
    public class PreOrderEnumerator<T> : BstEnumerator<T>
    {
        public PreOrderEnumerator(BinaryNode<T> root) : base(root)
        {
        }

        protected override void FillNodes(BinaryNode<T> node)
        {
            if(node == null) 
            {
                return;
            }

            _nodes.Add(node);
            FillNodes(node.Left);
            FillNodes(node.Right);
        }
    }
}
