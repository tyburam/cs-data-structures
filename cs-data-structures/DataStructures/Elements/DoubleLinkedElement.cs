namespace DataStructures.Elements
{
    public class DoubleLinkedElement<T>
    {
        public T Value { get; set; }
        public DoubleLinkedElement<T> Prev { get; set; }
        public DoubleLinkedElement<T> Next { get; set; }

        public DoubleLinkedElement(T value, DoubleLinkedElement<T> prev = null, DoubleLinkedElement<T> next = null)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }
    }
}
