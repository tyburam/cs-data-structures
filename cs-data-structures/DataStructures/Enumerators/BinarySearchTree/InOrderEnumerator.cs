using DataStructures.Elements;

namespace DataStructures.Enumerators.BinarySearchTree
{
    public class InOrderEnumerator<T> : BstEnumerator<T>
    {
        public InOrderEnumerator(BinaryNode<T> root) : base(root)
        {
        }

        protected override void FillNodes(BinaryNode<T> node)
        {
            if(node == null) 
            {
                return;
            }

            FillNodes(node.Left);
            _nodes.Add(node);
            FillNodes(node.Right);
        }
    }
}
