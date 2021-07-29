using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class NodePair<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; set; }

        public NodePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
