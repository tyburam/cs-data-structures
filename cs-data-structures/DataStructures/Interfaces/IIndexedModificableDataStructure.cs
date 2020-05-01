using System;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// This interface is for any class that represents a collection of elements
    /// and allows to both insert and remove element at a certain index
    /// </summary>
    public interface IIndexedModificableDataStructure<T> : IModificableDataStructure<T>
    {
        void InsertAt(T element, int index);
        void RemoveAt(int removeIndex);
    }
}
