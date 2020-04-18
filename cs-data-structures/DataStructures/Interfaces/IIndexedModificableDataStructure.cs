using System;

namespace DataStructures.Interfaces
{
    public interface IIndexedModificableDataStructure<T> : IModificableDataStructure<T>
    {
        void InsertAt(T element, int index);
        void RemoveAt(int removeIndex);
    }
}
