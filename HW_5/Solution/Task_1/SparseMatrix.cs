using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1
{
    public class SparseMatrix : IEnumerable<int>
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        private Dictionary<(int,int), int> _values = new Dictionary<(int,int), int>();

        public SparseMatrix(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentOutOfRangeException($"Argument {nameof(rows)} must be more than 0");
            if (columns <= 0) throw new ArgumentOutOfRangeException($"Argument {nameof(columns)} must be more than 0");
            Rows = rows;
            Columns = columns;
        }

        public int this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                int result;
                if (_values.TryGetValue((i,j), out result)) return result;
                else return default(int);
            }
            set
            {
                CheckIndexes(i, j);
                if (value != 0) _values[(i, j)] = value;
            }
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    var element = this[i, j];
                    result += $"{(element == 0 ? "0" : element.ToString()),-10}";
                }

                result += Environment.NewLine;
            }
            return result;
        }

        private void CheckIndexes(int i, int j)
        {
            Check(i, nameof(i), Rows);
            Check(j, nameof(j), Columns);

            void Check(int index, string indexName, int border)
            {
                if (index < 0 || index >= border)
                {
                    throw new IndexOutOfRangeException(indexName);
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < Rows; i++)
                for (var j = 0; j < Columns; j++)
                    yield return this[i, j];        
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<(int, int, int)> GetNonzeroElements()
        {
            var result = new List<(int, int, int)>();
            
            foreach (var element in _values)
            {
                result.Add((element.Key.Item1, element.Key.Item2, element.Value));
            }

            result.Sort(CompareByIndexes);
            return result;
        }

        private static int CompareByIndexes((int, int, int) x, (int, int, int) y)
        {
            if(x.Item2 == y.Item2)
            {
                if (x.Item1 > y.Item1) return 1;
                else return -1;
            }
            if (x.Item2 > y.Item2) return 1;
            else return -1;
        }

        public long GetCount(int x)
        {
            long count = 0;

            if (x == 0) 
            {
                return Rows * Columns - _values.Count;
            }
            else
            {
                foreach (var element in _values)
                    if(element.Value == x && _values.ContainsValue(x))count++;

                return count;
            }
        }
    }
}
