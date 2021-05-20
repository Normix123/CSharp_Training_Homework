using System;
using System.Collections.Generic;
using System.Linq;
using Task_1.Crud;

namespace Task_1
{
    public static class DataProcessingUsingDb
    {
        // Fill tables Employee and Vacation based on tuples
        public static void FillTables(List<(string, DateTime, DateTime)> list)
        {
            // Grouping employees by names
            var linesTuples = from line in list
                group line by line.Item1;

            var lineNumber = 1;

            // Temp variables to add in tables
            var tempEmployee = new Employee();
            var tempVacation = new Vacation();

            // Temp variables to modify tables
            var vacationCrud = new VacationCrud();
            var employeeCrud = new EmployeeCrud();

            // Delete all information from Vacation and Employee tables
            vacationCrud.DeleteAll();
            employeeCrud.DeleteAll();

            foreach (var lineTuple in linesTuples)
            {
                try
                {
                    tempEmployee.FirstName = lineTuple.Key.Split()[0];
                    tempEmployee.LastName = lineTuple.Key.Split()[1];

                    // Employee addition in table
                    tempEmployee.Id = employeeCrud.Create(tempEmployee);

                    foreach (var lineVacation in lineTuple)
                    {
                        tempVacation.DateStart = lineVacation.Item2;
                        tempVacation.DateEnd = lineVacation.Item3;
                        tempVacation.EmployeeId = tempEmployee.Id;

                        // Vacation addition in table
                        vacationCrud.Create(tempVacation);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{lineNumber}: {ex.Message}");
                }

                lineNumber++;
            }
        }
    }
}