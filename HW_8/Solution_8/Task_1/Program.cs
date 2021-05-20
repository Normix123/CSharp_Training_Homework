using System;

namespace Task_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Reader from file
            var reader = new DataReader("data.csv");
            // Using info from file add tables
            DataProcessingUsingDb.FillTables(reader.Read());

            Console.WriteLine("Filled");
        }
    }
}