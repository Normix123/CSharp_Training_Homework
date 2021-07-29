using System;
using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
                * Test class is described in Task_2.TestClass.cs
            */

            // Create an instance of test class
            var test = new Test();

            // Dictionary for storing the (name property or field) - (value)
            var dictionary = new Dictionary<string, string>();
            
            // Completion
            dictionary.TryAdd("_dAta", "32,5");
            dictionary.TryAdd("Auto", "This is auto");
            dictionary.TryAdd("_number", "we32,5AS");
            dictionary.TryAdd("Number", "32,456945");

            // Attempt to bind test class with dictionary
            SimpleBinder.GetInstance(test.GetType(), dictionary);

            // Get binded object
            test = SimpleBinder.ObjectBinded;

            // View test class
            Console.WriteLine(test.ToString());
        }
    }
}