using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Task_2
{
    public static class WorkingWithData
    {
        public static void WriteConsoleUsers() // Vacations longer than 30 days
        {
            using (var context = new EmployeeInfoContext())
            {
                var names = context.Vacations.Where(v => EF.Functions.DateDiffDay(v.DateStart,
                                                             v.DateEnd) >
                                                         30)
                    .Include(x => x.Employee)
                    .Select(x => x.Employee)
                    .GroupBy(x => new
                    {
                        x.FirstName,
                        x.LastName
                    })
                    .Select(x => x.Key);

                foreach (var name in names) Console.WriteLine($"{name.FirstName} {name.LastName}");
            }
        }

        public static void FixedDatabaseTrainingsEmployes()
        {
            using (var context = new EmployeeInfoContext())
            {
                var q = context.training.ToList();

                // Clear database
                context.EmployeeTrainings.RemoveRange(context.EmployeeTrainings);

                foreach (var training in q)
                {
                    // Select vacations that do not overlap with Training and group them by employee
                    // The request is universal for any number of trainings
                    var vacations = context.Vacations.Where(x =>
                            // The formula for not intersecting two time segments
                            EF.Functions.DateDiffDay(x.DateStart,
                                x.DateEnd) +
                            EF.Functions.DateDiffDay(training.DateStart,
                                training.DateEnd) <
                            EF.Functions.DateDiffDay(training.DateEnd,
                                x.DateEnd) +
                            EF.Functions.DateDiffDay(training.DateStart,
                                x.DateStart))
                        .Include(x => x.Employee)
                        .ToList()
                        .GroupBy(x => x.Employee).ToList();


                    foreach (var vacation in vacations)
                        context.EmployeeTrainings.Add(new EmployeeTraining
                        {
                            EmployeeId = vacation.Key.Id,
                            TrainingId = training.Id
                        });

                    // Name of Training - count of employes
                    Console.WriteLine($"{training.Name}: {vacations.Count()}");
                }

                context.SaveChanges();
            }
        }
    }
}