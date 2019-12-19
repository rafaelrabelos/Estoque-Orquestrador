using Dapper;
using System.Data.SqlClient;
using static Estorquestrador.Services.DependencyInjection;

namespace Estorquestrador.Models.Services
{
    
    public class AppOrm{

        private string _connectionStr{ get; set; }
        public AppOrm(string connectionStr){
            this._connectionStr = connectionStr;
        }
        
        public SqlConnection Connection () =>  new SqlConnection( this._connectionStr );

    }
    
}

