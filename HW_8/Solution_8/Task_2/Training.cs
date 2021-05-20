using System;
using System.Collections.Generic;

#nullable disable

namespace Task_2
{
    public class Training
    {
        public Training()
        {
            EmployeeTrainings = new HashSet<EmployeeTraining>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
    }
}