using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{
    public static class ThreadLib
    {
        public static Task<IEnumerable<BigInteger>> FactorizationAsync(BigInteger N)
        {
            var tcs = new TaskCompletionSource<IEnumerable<BigInteger>>();

            new Thread(Calculation).Start();

            return tcs.Task;

            void Calculation()
            {
                try
                {
                    var result = Lib.Factorization(N);
                    tcs.SetResult(result);
                }

                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }
    }
}