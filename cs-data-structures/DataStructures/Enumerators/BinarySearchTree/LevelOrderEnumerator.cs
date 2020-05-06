using DataStructures.Elements;

namespace DataStructures.Enumerators.BinarySearchTree
{
    public class LevelOrderEnumerator<T> : BstEnumerator<T>
    {
        public LevelOrderEnumerator(BinaryNode<T> root) : base(root)
        {
        }

        protected override void FillNodes(BinaryNode<T> node)
        {
            var parents = new DynamicArray<BinaryNode<T>>(1);
            parents[0] = node;
            FillFirstParentThanChildren(parents);
        }

        private void FillFirstParentThanChildren(DynamicArray<BinaryNode<T>> nodes)
        {
            var childNodes = new DynamicArray<BinaryNode<T>>(0);
            for(var i = 0; i < nodes.Length; i++)
            {
                _nodes.Add(nodes[i]);

                if(nodes[i].Left != null) 
                {
                    childNodes.Add(nodes[i].Left);
                }

                if(nodes[i].Right != null)
                {
                    childNodes.Add(nodes[i].Right);
                }
            }

            if(childNodes.Length > 0) {
                FillFirstParentThanChildren(childNodes);
            }
        }
    }
}
