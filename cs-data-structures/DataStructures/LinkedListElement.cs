namespace DataStructures
{
    public class LinkedListElement<T>
    {
        public T Value { get; set; }
        public LinkedListElement<T> Next { get; set; }

        public LinkedListElement(T value, LinkedListElement<T> next = null)
        {
            Value = value;
            Next = next;
        }
    }
}
