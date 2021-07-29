using System;
using System.Diagnostics;
using System.Numerics;

namespace Task_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            foreach (var element in Lib.Factorization(2005000000000050000))
                Console.WriteLine(element);
            sw.Stop();

            Console.WriteLine($"Factorization = {sw.ElapsedMilliseconds} ms");


            sw.Restart();
            var task = ThreadLib.FactorizationAsync(2005000000000050000);
            foreach (var element in task.Result)
                Console.WriteLine(element);
            sw.Stop();

            Console.WriteLine($"FactorizationAsync = {sw.ElapsedMilliseconds} ms");

            try
            {
                var bigInteger1 = new BigInteger(192634096486);
                bigInteger1 *= 2120778898307;
                var bigInteger2 = new BigInteger(2120778898307);

                Console.WriteLine($"Processing GSD of {bigInteger1} and  {bigInteger2}");
                Console.WriteLine($"GSD = {AsyncLibGcd.Gcd(bigInteger1, bigInteger2).Result}");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}