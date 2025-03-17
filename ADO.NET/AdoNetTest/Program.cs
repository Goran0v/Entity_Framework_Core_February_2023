using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection(@"Server=.;Database=SoftUni;Integrated Security=true; Trust Server Certificate=true");

connection.Open();

using (connection)
{
    SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE DepartmentId = 7", connection);
    SqlDataReader reader = command.ExecuteReader();

    using (reader)
    {
        while (reader.Read())
        {
            string? firstName = reader["FirstName"].ToString();
            string? lastName = reader["LastName"].ToString();

            Console.WriteLine($"{firstName} {lastName}");
        }
    }
}