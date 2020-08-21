using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using static Estorquestrador.Services.DependencyInjection;

namespace Estorquestrador.Models.RequestResponse
{
    
    public class Response<T>{

        public bool Status { get; set; }
        public object Erro { get; set; }
        public IEnumerable<T> Resposta { get; set; }

    }
    
}

