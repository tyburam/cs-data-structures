using System;

namespace DataStructures.Hash
{
    /// <summary>
    /// This class represents a collection of elements stored as key => value pairs
    /// with chaining used as a hash collision resolution mechanism
    /// </summary>
    public class ChainingHashTable<TKey,TValue> : AbstractHashTable<TKey, TValue>
    {
        public DynamicArray<DynamicArray<TKey>> Keys { get; private set; }
        public DynamicArray<DynamicArray<TValue>> Values { get; private set; }

        public ChainingHashTable(int capacity) : base(capacity)
        {
            Keys = new DynamicArray<DynamicArray<TKey>>(capacity);
            Values = new DynamicArray<DynamicArray<TValue>>(capacity);
        }

        public override void Clear()
        {
            Keys.Clear();
            Values.Clear();
        }

        protected override TValue DoGet(TKey key) 
        {
            var wholeIndex = GetIndexAndInnerIndex(key);
            if(Keys.Length == 0 || Keys[wholeIndex.Item1] == null || Keys[wholeIndex.Item1].Length == 0 
                || wholeIndex.Item2 == -1) {
                throw new System.Collections.Generic.KeyNotFoundException();
            }

            return Values[wholeIndex.Item1][wholeIndex.Item2];
        }

        protected override void DoRemove(TKey key)
        {
            var wholeIndex = GetIndexAndInnerIndex(key);
            if(Keys[wholeIndex.Item1].Length == 0 || wholeIndex.Item2 == -1) {
                throw new System.Collections.Generic.KeyNotFoundException();
            }

            Keys[wholeIndex.Item1].RemoveAt(wholeIndex.Item2);
            Values[wholeIndex.Item1].RemoveAt(wholeIndex.Item2);
        }

        protected override bool CheckContainsKey(TKey key)
        {
            var wholeIndex = GetIndexAndInnerIndex(key);
            if(Keys[wholeIndex.Item1].Length == 0 || wholeIndex.Item2 == -1) {
                return false;
            }

            return true;
        }

        public override bool ContainsValue(TValue value)
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

        protected override void DoAddOrSet(TKey key, TValue value, bool throwOnDuplicateKey=false)
        {
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
