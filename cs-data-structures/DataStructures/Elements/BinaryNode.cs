namespace DataStructures.Elements
{
    /// <summary>
    /// This class represents an node with value and two child nodes
    /// </summary>
    public class BinaryNode<T>
    {
        public T Value { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }

        public BinaryNode(T value, BinaryNode<T> left = null, BinaryNode<T> right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
