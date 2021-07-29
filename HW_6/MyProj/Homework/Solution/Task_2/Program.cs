using System;
using System.IO;

namespace Task_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "data.txt");
                var algorithm = new Algorithm("data.txt");

                Console.WriteLine("Point is (5, 6), k = 5");

                Console.WriteLine("Closest points are: ");

                foreach (var element in algorithm.GetClosestEntities((5, 6), 5)) Console.WriteLine(element);

                Console.WriteLine("Trying to guess object..");
                Console.WriteLine($"The class is {algorithm.GetLikelyNameOfEntity((5, 6), 5)}\n");


                Console.WriteLine("Point is (5.2, 6), k = 4");

                Console.WriteLine("Closest points are: ");

                foreach (var element in algorithm.GetClosestEntities((5.2, 6), 4)) Console.WriteLine(element);

                Console.WriteLine("Trying to guess object..");
                Console.WriteLine($"The class is {algorithm.GetLikelyNameOfEntity((5.2, 6), 4)}");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}