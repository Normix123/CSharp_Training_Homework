using System;
using System.Collections.Generic;

#nullable disable

namespace Task_2
{
    public class Employee
    {
        public Employee()
        {
            EmployeeTrainings = new HashSet<EmployeeTraining>();
            Vacations = new HashSet<Vacation>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}