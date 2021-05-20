using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Task_1.Crud
{
    public class EntityCrud
    {
        private readonly SqlConnection _connection;

        public EntityCrud()
        {
            const string connectionString =
                "Server=(localdb)\\mssqllocaldb; Database=EmployeeInfo; Trusted_Connection=true; Pooling=true";
            _connection = new SqlConnection(connectionString);
        }

        public void ExecuteNonQuery(SqlCommand sqlQuery)
        {
            try
            {
                sqlQuery.Connection = _connection;
                _connection.Open();
                sqlQuery.ExecuteNonQuery();
                _connection.Close();
            }

            catch (SqlException ex)
            {
                var error = new StringBuilder();
                error.AppendLine(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    error.Append("Message: ").AppendLine(err.Message);
                    error.Append("Level: ").Append(err.Class).AppendLine();
                    error.Append("Procedure: ").AppendLine(err.Procedure);
                    error.Append("Line Number: ").Append(err.LineNumber).AppendLine();
                }

                Console.Write(error.ToString());
            }
        }
    }
}