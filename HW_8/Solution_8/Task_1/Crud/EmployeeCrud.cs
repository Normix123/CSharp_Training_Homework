using System;
using Microsoft.Data.SqlClient;

namespace Task_1.Crud
{
    public class EmployeeCrud : EntityCrud
    {
        public void DeleteAll()
        {
            var sql = new SqlCommand("DELETE FROM Employee");
            ExecuteNonQuery(sql);
        }

        public Guid Create(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            if (string.IsNullOrEmpty(employee.FirstName.Trim()))
                throw new ArgumentException(nameof(employee.FirstName));
            if (string.IsNullOrEmpty(employee.LastName.Trim())) throw new ArgumentException(nameof(employee.LastName));

            var sql = new SqlCommand("INSERT INTO Employee VALUES (@Id, @Email, @FirstName, @LastName)");

            var guid = Guid.NewGuid();

            sql.Parameters.AddWithValue("@Id", guid);
            sql.Parameters.AddWithValue("@Email", CreateEmail(employee.FirstName, employee.LastName));
            sql.Parameters.AddWithValue("@FirstName", employee.FirstName);
            sql.Parameters.AddWithValue("@LastName", employee.LastName);

            ExecuteNonQuery(sql);

            return guid;
        }

        private string CreateEmail(string FirstName, string LastName)
        {
            return FirstName + LastName + "@issoft.by";
        }
    }
}