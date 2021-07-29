using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix sparse = new SparseMatrix(10, 10);

            for (int i = 0, j = 0; i < 10; i++, j++) 
            sparse[i, j] = i + j;

            sparse[2, 3] = -10;
            sparse[2, 4] = -10;
            sparse[2, 5] = -10;
            sparse[3, 5] = -10;


            IEnumerable<(int, int, int)> enumerable = sparse.GetNonzeroElements();

            IEnumerator<(int, int, int)> enumerator = enumerable.GetEnumerator();

            while ( enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Item3);
            }

            Console.WriteLine(sparse.ToString() + $"{sparse.GetCount(0)} {sparse.GetCount(-10)}" ); 
        }
    }
}
