namespace DataStructures.Elements
{
    public class LinkedElement<T>
    {
        public T Value { get; set; }
        public LinkedElement<T> Next { get; set; }

        public LinkedElement(T value, LinkedElement<T> next = null)
        {
            Value = value;
            Next = next;
        }
    }
}
