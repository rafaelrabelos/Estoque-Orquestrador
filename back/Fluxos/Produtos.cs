using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dapper;

using static Estorquestrador.Services.DependencyInjection;

namespace Estorquestrador.Fluxos.Produto
{
    using Models.Services;
    using Models.Produto;

    public class FluxoProduto
    {
      
        #region Fluxos de Produto CRUD
        public IEnumerable<T> ObtemTodos<T>() {

            using (var connection  = Service<AppOrm>().Connection() )
            {
                return connection.Query<T>("SELECT * FROM Produto ORDER BY Nome ASC");
            }
            
        }

        public IEnumerable<T> ObtemTodosAtivos<T> () {

            using (var connection  = Service<AppOrm>().Connection() )
            {
                return connection.Query<T>("SELECT * FROM Produto WHERE Excluido <> 1 ORDER BY Nome ASC");
            }
        }

        public IEnumerable<T> ObtemPorId<T> (int produtoId) {

            using (var connection  = Service<AppOrm>().Connection() )
            {
                return connection.Query<T>("SELECT * FROM Produto WHERE id = @id", new{ @id = produtoId});
            }
        }

        public IEnumerable<T> AtualizaExistente<T> (ProdutoModel produto )
        {
            using (var connection  = Service<AppOrm>().Connection() )
            {
                var update = connection
                .Execute(@"UPDATE Produto 
                                SET Nome=@Nome,
                                Qtd=@Qtd,
                                Valor=@Valor,
                                Alterado_em=GETDATE()
                            WHERE id=@id", new{ @id = produto.id, @Valor=produto.Valor, @Nome = produto.Nome, @Qtd = produto.Qtd});

                if(update > 0)
                    return this.ObtemPorId<T>(produto.id);
                else
                    return null;
            }
        }

        public IEnumerable<T> InsereNovo<T> (ProdutoModel produto)
        {
            using (var connection  = Service<AppOrm>().Connection() )
            {
                var insert = connection
                .Query<int>( @"INSERT INTO Produto 
                            (Nome, Qtd, Valor)
                            OUTPUT INSERTED.id
                            VALUES(@Nome, @Qtd, @Valor)
                        ", new{ @Nome = produto.Nome, @Qtd = produto.Qtd, @Valor=produto.Valor, }).Single();

                if(insert > 0)
                    return this.ObtemPorId<T>(insert);
                else
                    return null;
            }
        }

        public IEnumerable<T> Deleta<T> (int produtoId, bool hard = false)
        {
            using (var connection  = Service<AppOrm>().Connection() )
            {
                var update = !hard ? 
                connection
                .Execute(@"UPDATE Produto 
                                SET Excluido=1,
                                Alterado_em=GETDATE()
                            WHERE id=@id", new{ @id = produtoId })
                            :
                connection
                .Execute(@"DELETE FROM Produto WHERE id=@id", new{ @id = produtoId });

                if(update > 0)
                    return this.ObtemPorId<T>(produtoId);
                else
                    return null;
            }
        }

        #endregion
        
    }
}
