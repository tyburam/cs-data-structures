using System.Text;

namespace DataStructures
{
    /// <summary>
    /// This an abstract class that represents a collection of elements
    /// that allows accessing by index using [] and three access methods:
    /// GetAt, SetAt, InsertAt 
    /// </summary>
    public abstract class IndexedDataStructure<T>
    {
        public int Length { get; protected set; }

        public T this[int index] 
        {  
            get 
            {
                return GetAt(index);
            }

            set
            {
                SetAt(value, index);
            }
        }

        public abstract T GetAt(int index);
        public abstract void SetAt(T element, int index);
        public abstract void InsertAt(T element, int index);

        public override string ToString() 
        {
            var sb = new StringBuilder("[");
            for(var i = 0; i < Length; i++) 
            {
                sb.Append(GetAt(i));
                if(i < Length-1) {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
