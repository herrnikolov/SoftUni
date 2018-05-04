namespace Employees.Data
{
    public class Configuration
    {
        public static string ConnectionString => $@"Server=(LocalDb)\MSSQLLocalDB;Database=EmployeeDb;Integrated Security=True";
    }
}
