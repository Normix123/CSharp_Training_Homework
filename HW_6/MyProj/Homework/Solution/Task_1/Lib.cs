using System;
using System.Collections.Generic;
using System.Numerics;

namespace Task_1
{
    public static class Lib
    {
        public static IEnumerable<BigInteger> Factorization(BigInteger N)
        {
            if (N < 2) throw new ArgumentOutOfRangeException(nameof(N));

            // Method of iterating over division

            BigInteger div = 2;

            while (N % div == 0)
            {
                yield return div;
                N /= div;
            }

            div = 3;

            while (div * div <= N)
            {
                if (N % div == 0)
                {
                    yield return div;
                    N /= div;
                }
                else
                {
                    div += 2;
                }
            }

            if (N > 1) yield return N;
        }
    }
}