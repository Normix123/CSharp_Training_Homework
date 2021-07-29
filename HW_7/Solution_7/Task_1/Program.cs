using System;
using System.IO;
using System.Reflection;

namespace Task_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Assembly assembly = null;

            try
            {
                assembly = Assembly.Load("Task_0");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                // Get type of Logger 
                var type = assembly.GetType("Task_0.Logger");

                // var instance = new Logger(nameFile)  -- if there were no assemblies
                // nameFile - log.json
                var instance = Activator.CreateInstance(type, "log.json");

                // Track method was found
                var methodTrack = type.GetMethod("Track");

                /*
                 * Test classes are described in Task_1.TestClasses.cs
                */

                // Test class #1 with some property
                var test1 = new Test1 { SomeProperty = "Name of this" };

                // Test class #2 with some property
                var test2 = new Test2{SomePropertyAgain =  "Again..."};

                // Execute method of both classes
                methodTrack?.Invoke(instance, new object[] {test1});
                methodTrack?.Invoke(instance, new object[] {test2});

                // Recorded information is in log.json
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}