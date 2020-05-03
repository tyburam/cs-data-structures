using DataStructures.Elements;

namespace DataStructures.Enumerators.BinarySearchTree
{
    public class PostOrderEnumerator<T> : BstEnumerator<T>
    {
        public PostOrderEnumerator(BinaryNode<T> root) : base(root)
        {
        }

        protected override void FillNodes(BinaryNode<T> node)
        {
            if(node == null) 
            {
                return;
            }

            FillNodes(node.Left);
            FillNodes(node.Right);
            _nodes.Add(node);
        }
    }
}
