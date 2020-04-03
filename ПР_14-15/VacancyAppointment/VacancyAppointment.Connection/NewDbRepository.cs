using System.Data.SqlClient;

namespace VacancyAppointment.Connection
{
    public partial class NewDbRepository
    {
        private readonly string _connectionString;

        public NewDbRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NewDbRepository()
            : this(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=NewDb;Integrated Security=true;")
        { }

        public SqlConnection GetOpenedConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
