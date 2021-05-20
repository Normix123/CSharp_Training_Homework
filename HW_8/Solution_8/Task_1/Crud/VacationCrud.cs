using System;
using Microsoft.Data.SqlClient;

namespace Task_1.Crud
{
    public class VacationCrud : EntityCrud
    {
        public void DeleteAll()
        {
            var sql = new SqlCommand("DELETE FROM Vacation");
            ExecuteNonQuery(sql);
        }

        public Guid Create(Vacation vacation)
        {
            if (vacation == null) throw new ArgumentNullException(nameof(vacation));

            if (vacation.DateStart == DateTime.MinValue) throw new ArgumentException(nameof(vacation.DateStart));
            if (vacation.DateEnd == DateTime.MinValue) throw new ArgumentException(nameof(vacation.DateEnd));
            if (vacation.EmployeeId == Guid.Empty) throw new ArgumentException(nameof(vacation.EmployeeId));

            var sql = new SqlCommand("INSERT INTO Vacation VALUES (@Id, @DateStart, @DateEnd, @EmployeeId)");

            var guid = Guid.NewGuid();

            sql.Parameters.AddWithValue("@Id", guid);
            sql.Parameters.AddWithValue("@DateStart", vacation.DateStart);
            sql.Parameters.AddWithValue("@DateEnd", vacation.DateEnd);
            sql.Parameters.AddWithValue("@EmployeeId", vacation.EmployeeId);

            ExecuteNonQuery(sql);

            return guid;
        }
    }
}