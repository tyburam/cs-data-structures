namespace DataStructures.Elements
{
    /// <summary>
    /// This class represents an object of iterable sequence which contains value 
    /// and references to the next element of that sequence
    /// </summary>
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
