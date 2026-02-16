using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class Connection : IConnection {
        private readonly string _connectionString;
        public Connection(string connectionString) {
            _connectionString = connectionString;
        }
        public IDbConnection GetConnection() {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
