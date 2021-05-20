using System;

namespace Task_1.Crud
{
    public class Vacation
    {
        public Guid Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}