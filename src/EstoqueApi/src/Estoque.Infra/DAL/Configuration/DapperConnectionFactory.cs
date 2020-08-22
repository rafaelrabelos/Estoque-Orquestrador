using System.Data.SqlClient;

namespace Estoque.Infra.DAL.Configuration
{
    public static class DapperConnectionFactory
    {
        public static SqlConnection Connection(string connectionStr) => new SqlConnection(connectionStr);

    }
}