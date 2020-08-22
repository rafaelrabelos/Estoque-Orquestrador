using System;
using Estoque.Dominio.Entidades;
using Estoque.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using RebelQuery;

namespace Estoque.Infra.DAL.Repositorios
{
    public class ImpostoRepository : IImpostoRepository
    {
        private readonly IRQuery _rebelQuery;
        public ImpostoRepository(IRQuery rebelQuery)
        {
            this._rebelQuery = rebelQuery;
        }

        public IEnumerable<ImpostoEntity> ObtemPorId(Guid produtoId)
        {
            var result = this._rebelQuery
                .RQueryExecute<ImpostoEntity>(@"SELECT Id, Nome, Valor, ValorReferencia  FROM Impostos WHERE id =@produtoid",new { produtoid=produtoId });
            return result.Content;
        }

        public IEnumerable<ImpostoEntity> ObtemTodos()
        {
            var result = this._rebelQuery.RQueryExecute<ImpostoEntity>(@"SELECT Id, Nome, Valor, ValorReferencia FROM Impostos",null);
            return result.Content;
        }
    }
}
