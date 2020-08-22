using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Estoque.Dominio.Entidades;
using Estoque.Dominio.Interfaces.Repositorios;

namespace Estoque.Infra.DAL.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _dapperConnection;
        public ProdutoRepository(IDbConnection dapperCnn)
        {
            this._dapperConnection = dapperCnn;
        }
        public IEnumerable<ProdutoEntity> ObtemTodos()
        {

            using (var db = this._dapperConnection)
            {
                _dapperConnection.Open();
                
                return db.Query<ProdutoEntity>("SELECT * FROM Produtos ORDER BY Nome ASC");
            }
        }

        public IEnumerable<ProdutoEntity> ObtemTodosAtivos()
        {

            using (var db = this._dapperConnection)
            {
                _dapperConnection.Open();
                return db.Query<ProdutoEntity>("SELECT * FROM Produto WHERE Excluido <> 1 ORDER BY Nome ASC");
            }
        }

        public IEnumerable<ProdutoEntity> ObtemPorId(int produtoId)
        {

            using (var db = this._dapperConnection)
            {
                _dapperConnection.Open();
                return db.Query<ProdutoEntity>("SELECT * FROM Produto WHERE id = @id", new { @id = produtoId });
            }
        }

        public IEnumerable<ProdutoEntity> AtualizaExistente(ProdutoEntity produto)
        {
            using (var db = this._dapperConnection)
            {
                var update = db
                .Execute(@"UPDATE Produto 
                                SET Nome=@Nome,
                                Qtd=@Qtd,
                                Valor=@Valor,
                                Alterado_em=GETDATE()
                            WHERE id=@id", new { @id = produto.id, @Valor = produto.Valor, @Nome = produto.Nome, @Qtd = produto.Qtd });

                if (update > 0)
                    return this.ObtemPorId(produto.id);
                else
                    return null;
            }
        }

        public IEnumerable<ProdutoEntity> InsereNovo(ProdutoEntity produto)
        {
            using (var db = this._dapperConnection)
            {
                var insert = db
                .Query<int>(@"INSERT INTO Produto 
                            (Nome, Qtd, Valor)
                            OUTPUT INSERTED.id
                            VALUES(@Nome, @Qtd, @Valor)
                        ", new { @Nome = produto.Nome, @Qtd = produto.Qtd, @Valor = produto.Valor, }).Single();

                if (insert > 0)
                    return this.ObtemPorId(insert);
                else
                    return null;
            }
        }

        public IEnumerable<ProdutoEntity> Deleta(int produtoId, bool hard = false)
        {
            using (var db = this._dapperConnection)
            {
                var update = !hard ?
                db.Execute(@"UPDATE Produto 
                                SET Excluido=1,
                                Alterado_em=GETDATE()
                            WHERE id=@id", new { @id = produtoId })
                            :
                db.Execute(@"DELETE FROM Produto WHERE id=@id", new { @id = produtoId });

                if (update > 0)
                    return this.ObtemPorId(produtoId);
                else
                    return null;
            }
        }

    }
}
