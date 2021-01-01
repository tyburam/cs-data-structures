using System;

namespace DataStructures.Hash
{
    public enum ProbingType 
    {
        Linear,
        Quadratic
    }

    /// <summary>
    /// This class represents a collection of elements stored as key => value pairs
    /// with chaining used as a hash collision resolution mechanism
    /// </summary>
    public class OpenAddressingHashTable<TKey, TValue> : AbstractHashTable<TKey, TValue>
    {
        public NullableArray<TKey> Keys { get; private set; }
        public DynamicArray<TValue> Values { get; private set; }

        private int _elements;
        private Func<int, int> _probe;

        public OpenAddressingHashTable(int capacity, ProbingType type = ProbingType.Linear) : base(capacity)
        {
            _elements = 0;
            Keys = new NullableArray<TKey>(capacity);
            Values = new DynamicArray<TValue>(capacity);

            switch(type) {
                case ProbingType.Linear:
                    _probe = (x) => x * 17;
                    break;
                case ProbingType.Quadratic:
                    _probe = (x) => (x * x + x) >> 1;
                    break;
            }
        }

        public override void Clear()
        {
            Keys = new NullableArray<TKey>(_capacity);
            Values.Clear();
        }

        public override bool ContainsValue(TValue value)
        {
            for(var i = 0; i < Values.Length; i++)
            {
                if(Values[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        protected override bool CheckContainsKey(TKey key)
        {
            return Keys.HasValueAt(GetIndex(key));
        }

        protected override void DoAddOrSet(TKey key, TValue value, bool throwOnDuplicateKey = false)
        {
            var index = GetIndex(key);

            if(!Keys.HasValueAt(index)) 
            {
                Keys[index] = key;
                Values[index] = value;
                ++_elements;
                return;
            }

            if(Keys[index].Equals(key)) 
            {
                Values[index] = value;
                return;
            }

            if(_elements == _capacity)
            {
                throw new Exception("No free space to add element");
            }

            var i = 1;
            do 
            {
                index += _probe(i);
                index %= _capacity;
                ++i;
            } while(Keys.HasValueAt(index));

            Keys[index] = key;
            Values[index] = value;
            ++_elements;
        }

        protected override TValue DoGet(TKey key)
        {
            var index = GetIndex(key);
            var i = 1;
            
            while(Keys.HasValueAt(index))
            {
                if(Keys[index].Equals(key))
                {
                    return Values[index];
                }

                index += _probe(i);
                index %= _capacity;
                ++i;
            }

            throw new System.Collections.Generic.KeyNotFoundException();
        }

        protected override void DoRemove(TKey key)
        {
            var index = GetIndex(key);

            if(!Keys.HasValueAt(index))
            {
                return;
            }

            Keys.RemoveAt(index);
        }
    }
}