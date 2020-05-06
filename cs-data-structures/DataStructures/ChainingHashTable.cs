using System;

namespace DataStructures
{
    /// <summary>
    /// This class represents a collection of elements stored as key => value pairs
    /// with internal mechanism of collision handling which allows hash collision
    /// but do not allow both hash and key collision
    /// </summary>
    public class ChainingHashTable<TKey,TValue>
    {
        public DynamicArray<DynamicArray<TKey>> Keys { get; private set; }
        public DynamicArray<DynamicArray<TValue>> Values { get; private set; }

        private int _capacity;

        public ChainingHashTable(int capacity)
        {
            if(capacity <= 0)
            {
                throw new ArgumentException(nameof(capacity));
            }

            Keys = new DynamicArray<DynamicArray<TKey>>(capacity);
            Values = new DynamicArray<DynamicArray<TValue>>(capacity);
            _capacity = capacity;
        }

        public TValue this[TKey key]
        {  
            get 
            {
                return Get(key);
            }

            set
            {
                AddOrSet(key, value);
            }
        }

        /// <summary>
        /// Returns the value associated with given key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>
        /// Value  associated with given key
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the key is null</exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown when the key is not found</exception>
        public TValue Get(TKey key)
        {
            if(key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }

            var wholeIndex = GetIndexAndInnerIndex(key);
            if(Keys.Length == 0 || Keys[wholeIndex.Item1] == null || Keys[wholeIndex.Item1].Length == 0 
                || wholeIndex.Item2 == -1) {
                throw new System.Collections.Generic.KeyNotFoundException();
            }

            return Values[wholeIndex.Item1][wholeIndex.Item2];
        }

        /// <summary>
        /// Returns the value associated with given key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>
        /// Value associated with given key or default value for the value type if couldn't get the value
        /// </returns>
        public TValue GetOrDefault(TKey key)
        {
            try {
                var value = Get(key);
                return value;
            } 
            catch(Exception)
            {
                return default(TValue);
            }
        }

        /// <summary>
        /// Adds value to the hash table
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the key is null</exception>
        /// <exception cref="System.ArgumentException">Thrown when both the key and hash collides</exception>
        public void Add(TKey key, TValue value)
        {
            AddOrSet(key, value, true);
        }

        /// <summary>
        /// Removes key and its associated value from hash table
        /// </summary>
        /// <param name="key">key</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the key is null</exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown when the key is not found</exception>
        public void Remove(TKey key)
        {
            if(key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }

            var wholeIndex = GetIndexAndInnerIndex(key);
            if(Keys[wholeIndex.Item1].Length == 0 || wholeIndex.Item2 == -1) {
                throw new System.Collections.Generic.KeyNotFoundException();
            }

            Keys[wholeIndex.Item1].RemoveAt(wholeIndex.Item2);
            Values[wholeIndex.Item1].RemoveAt(wholeIndex.Item2);
        }

        /// <summary>
        /// Removes all keys and values
        /// </summary>
        public void Clear()
        {
            Keys.Clear();
            Values.Clear();
        }

        /// <summary>
        /// Checks if given key is present in hash table
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>
        /// True if found, false otherwise
        /// </returns>
        public bool ContainsKey(TKey key)
        {
            if(key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }

            var wholeIndex = GetIndexAndInnerIndex(key);
            if(Keys[wholeIndex.Item1].Length == 0 || wholeIndex.Item2 == -1) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if given value is present in hash table
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>
        /// True if found, false otherwise
        /// </returns>
        public bool ContainsValue(TValue value)
        {
            for(var i = 0; i < Values.Length; i++)
            {
                for(var j = 0; j < Values[i].Length; j++)
                {
                    if(Values[i][j].Equals(value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int GetIndex(TKey key)
        {
            var hashCode = key.GetHashCode();
            return (hashCode & 0x7FFFFFFF) % _capacity;
        }

        private Tuple<int, int> GetIndexAndInnerIndex(TKey key)
        {
            int outerIndex = GetIndex(key);
    
            if(Keys.Length > 0 && Keys[outerIndex] != null && Keys[outerIndex].Length > 0) {
                for(var i = 0; i < Keys[outerIndex].Length; i++)
                {
                    if(key.Equals(Keys[outerIndex][i]))
                    {
                        return new Tuple<int, int>(outerIndex, i);
                    }
                }
            }

            return new Tuple<int, int>(outerIndex, -1);
        }

        private void AddOrSet(TKey key, TValue value, bool throwOnDuplicateKey=false)
        {
            if(key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }

            var wholeIndex = GetIndexAndInnerIndex(key);
            if(Keys.Length > 0 && Keys[wholeIndex.Item1] != null && Keys[wholeIndex.Item1].Length > 0 
                && wholeIndex.Item2 != -1) 
            {
                if(throwOnDuplicateKey)
                {
                    throw new ArgumentException();
                }
                Values[wholeIndex.Item1][wholeIndex.Item2] = value;
                return;
            }

            if(Keys[wholeIndex.Item1] == null)
            {
                Keys[wholeIndex.Item1] = new DynamicArray<TKey>(10);
                Values[wholeIndex.Item1] = new DynamicArray<TValue>(10);
            }

            Keys[wholeIndex.Item1].Add(key);
            Values[wholeIndex.Item1].Add(value);
        }
    }
}
