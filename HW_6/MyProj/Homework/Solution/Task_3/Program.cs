using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // The path to the file for the example
            var path = Path.Combine(Directory.GetCurrentDirectory(), "data.csv");

            // Create it for data processing
            var statistic = new StatisticOfVacations(path); // Also read the file (out of path)

            // Show 10 last records with 1 day vacation (simulate data sampling and processing)
            Console.WriteLine("10 last persons");
            Parallel.ForEach( statistic.Where(x => x.Length == 1).TakeLast(10), Console.WriteLine);

            // Write information about vacations of the second half of Year
            statistic.WriteFile("persons.json", Directory.GetCurrentDirectory());

            Console.WriteLine("Completed!");
        }
    }
}