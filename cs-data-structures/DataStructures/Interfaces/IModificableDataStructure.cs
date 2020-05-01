using System;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// This interface is for any class that represents a collection of elements
    /// and allows to add and remove an element
    /// </summary>
    public interface IModificableDataStructure<T>
    {
        void Add(T element);
        void Remove(T element);
    }
}
