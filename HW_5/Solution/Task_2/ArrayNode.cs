using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class ArrayNode<TKey, TValue>
    {
        private LinkedList<NodePair<TKey, TValue>>[] _items;

        private const double LoadFactor = 0.72;

        public int Capacity { get; private set; }
     
        public int Size { get; private set; }

        public TValue this[TKey key]
        {
            get
            {
                if(_items[Hash(key)] != null)
                return _items[Hash(key)].First.Value.Value;
                else throw new ArgumentException($"{nameof(key)} doesn't exist.");
            }

            set
            {
                if(value == null ) throw new ArgumentNullException($"{nameof(value)} is null.");
                if (_items[Hash(key)] != null)
                    Update(key, value);
                else throw new ArgumentException($"{nameof(key)} doesn't exist.");
            }
        }

        public ArrayNode() : this(100) { }

        public ArrayNode(int capasity)
        {
            if (capasity > 0)
            {
                Capacity = capasity;
                _items = new LinkedList<NodePair<TKey, TValue>>[Capacity];
            }
            else throw new ArgumentException($"{nameof(capasity)} must be more than zero.");
        }

        private int Hash(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % Capacity;
        }

        private double GetLoadFactor()
        {
            if (Capacity > 0)
                return Size / Capacity;
            else return 0;
        }

        private void Resize()
        {
            Capacity = Capacity * 2;
            var oldArr = _items;
            Size = 0;
            _items = new LinkedList<NodePair<TKey, TValue>>[Capacity];

            foreach (var item in oldArr)
            {
                if (item != null)
                {
                    foreach (var pair in item)
                    {
                        if (pair != null)
                            Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                    {
                        if (node != null)
                            yield return node.First.Value.Value;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                    {
                        if (node != null)
                            yield return node.First.Value.Key;
                    }
                }
            }
        }

        public IEnumerable<NodePair<TKey, TValue>> Items
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                    {
                        if (node != null)
                            yield return node.First.Value;
                    }
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            CheckPairOnNull(key, value);

            if (GetLoadFactor() >= LoadFactor)
            {
                Resize();
            }

            var index = Hash(key);

            if (_items == null)
                _items = new LinkedList<NodePair<TKey, TValue>>[Capacity];


            if (_items[index] == null)
            {
                _items[index] = new LinkedList<NodePair<TKey, TValue>>();

                var pair = new NodePair<TKey, TValue>(key, value);

                var node = new LinkedListNode<NodePair<TKey, TValue>>(pair);

                _items[index].AddFirst(node);

                Size++;
            }

            else throw new ArgumentException($"{nameof(key)} must be uniq.");

        }

        public void Update(TKey key, TValue value)
        {

            CheckPairOnNull(key, value);

            if (_items != null)
            {
                var index = Hash(key);

                var pair = new NodePair<TKey, TValue>(key, value);

                if (_items[index] != null)
                {
                    _items[index].RemoveFirst();
                    _items[index].AddFirst(pair);
                }

                else throw new ArgumentException($"{nameof(key)} doesn't exist.");
            }

            else throw new NullReferenceException($"{_items}");
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            if (_items == null)
                return false;

            CheckPairOnNull(key, value);

            var index = Hash(key);

            if (_items[index] == null)
                return false;

            if (Equals(_items[index].First.Value.Key, key))
            {
                value = _items[index].First.Value.Value;
                return true;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            var index = Hash(key);

            if (_items == null)
                return false;

            if (_items[index] == null)
                return false;

            TValue value;
            TryGetValue(key, out value);

            var pair = new NodePair<TKey, TValue>(key, value);
            _items[index].Remove(pair);
            
            Size--;

            return true;
        }

        private void CheckPairOnNull(TKey key, TValue value)
        {
            Check(key, nameof(key));
            Check(value, nameof(value));

            void Check(Object element, string elementName)
            {
                if (element == null)
                {
                    throw new ArgumentNullException(elementName);
                }
            }
        }

        public void Clear()
        {
            Size = 0;
            _items = new LinkedList<NodePair<TKey, TValue>>[Capacity];
        }
    }
}
