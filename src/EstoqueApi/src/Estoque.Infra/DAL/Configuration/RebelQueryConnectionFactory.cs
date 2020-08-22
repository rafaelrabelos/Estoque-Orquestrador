using System;
using RebelQuery;

namespace Estoque.Infra.DAL.Configuration
{
    public class RebelQueryConnectionFactory : RQuery
    {
        private readonly string _connectionString;
        public RebelQueryConnectionFactory(String connectionString)
        {
            this._connectionString = connectionString;
        }
        protected override string ConnectionString => this._connectionString;
    }
}
