using System;

namespace Task_2
{
    public class Vacation
    {
        public Guid Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}