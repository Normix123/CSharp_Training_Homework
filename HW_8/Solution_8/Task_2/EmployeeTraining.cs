using System;

namespace Task_2
{
    public class EmployeeTraining
    {
        public Guid EmployeeId { get; set; }
        public Guid TrainingId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Training Training { get; set; }
    }
}