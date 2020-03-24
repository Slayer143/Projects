using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancySearch.Connection
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
