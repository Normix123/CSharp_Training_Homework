using System;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{
    public static class AsyncLibGcd
    {
        public static async Task<BigInteger> Gcd(BigInteger a, BigInteger b)  // GCD - Greatest common divisor
        {
            var tcs = new TaskCompletionSource<BigInteger>();
            new Thread(Calculation).Start();

            return await tcs.Task;

            async void Calculation()
            {
                try
                {
                    // Get a collection of prime numbers by decomposing the numbers a, b
                    var dataA = await ThreadLib.FactorizationAsync(a);
                    var dataB = await ThreadLib.FactorizationAsync(b);

                    // Get a collection of tuples (prime number, least count of repetitions) from two prime sets
                    var fin = from a1 in dataA.GroupBy(ab => ab).Select(g => new {Num = g.Key, Count = g.Count()})
                        from b1 in dataB.GroupBy(ab => ab).Select(g => new {Num = g.Key, Count = g.Count()})
                        where a1.Num == b1.Num
                        select a1.Count > b1.Count ? b1 : a1;

                    BigInteger gcd = 1;

                    // Multiply all primers from the fin query
                    foreach (var element in fin)
                    {
                        gcd *= BigInteger.Pow(element.Num, element.Count);
                    }

                    tcs.SetResult(gcd);
                }

                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }
    }
}