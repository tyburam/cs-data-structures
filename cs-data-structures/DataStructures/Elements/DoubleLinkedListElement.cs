namespace DataStructures.Elements
{
    public class DoubleLinkedListElement<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListElement<T> Prev { get; set; }
        public DoubleLinkedListElement<T> Next { get; set; }

        public DoubleLinkedListElement(T value, DoubleLinkedListElement<T> prev = null, DoubleLinkedListElement<T> next = null)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }
    }
}
