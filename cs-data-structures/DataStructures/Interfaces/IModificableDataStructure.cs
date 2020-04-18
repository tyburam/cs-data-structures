using System;

namespace DataStructures.Interfaces
{
    public interface IModificableDataStructure<T>
    {
        void Add(T element);
        void Remove(T element);
    }
}
