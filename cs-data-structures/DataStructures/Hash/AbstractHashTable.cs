using System;

namespace DataStructures.Hash 
{
    public abstract class AbstractHashTable<TKey,TValue>
    {
        protected int _capacity;

        protected AbstractHashTable(int capacity)
        {
            if(capacity <= 0)
            {
                throw new ArgumentException(nameof(capacity));
            }
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

            return DoGet(key);
        }

        // <summary>
        /// Returns the value associated with given key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>
        /// Value associated with given key or default value for the value type if couldn't get the value
        /// </returns>
        public TValue GetOrDefault(TKey key)
        {
            try {
                return Get(key);
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
            
            DoRemove(key);
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

            return CheckContainsKey(key);
        }
        protected void AddOrSet(TKey key, TValue value, bool throwOnDuplicateKey=false)
        {
            if(key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }

            DoAddOrSet(key, value, throwOnDuplicateKey);
        }

        protected int GetIndex(TKey key)
        {
            var hashCode = key.GetHashCode();
            return (hashCode & 0x7FFFFFFF) % _capacity;
        }

        /// <summary>
        /// Removes all keys and values
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Checks if given value is present in hash table
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>
        /// True if found, false otherwise
        /// </returns>
        public abstract bool ContainsValue(TValue value);

        protected abstract TValue DoGet(TKey key);
        protected abstract void DoRemove(TKey key);
        protected abstract bool CheckContainsKey(TKey key);
        protected abstract void DoAddOrSet(TKey key, TValue value, bool throwOnDuplicateKey=false);

    }
}