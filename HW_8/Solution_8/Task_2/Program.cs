using System;

namespace Task_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Write users with vacations longer than 30 days
            WorkingWithData.WriteConsoleUsers();

            Console.WriteLine(new string('-', 81));

            // Fixed in database trainings completed by employees
            WorkingWithData.FixedDatabaseTrainingsEmployes();
        }
    }
}