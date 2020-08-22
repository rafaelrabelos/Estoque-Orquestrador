using System.Collections.Generic;
using Estoque.Dominio.Entidades;

namespace Estoque.Dominio.Interfaces.Repositorios
{
    public interface IProdutoRepository
    {
        public IEnumerable<ProdutoEntity> ObtemTodos();

        public IEnumerable<ProdutoEntity> ObtemTodosAtivos();

        public IEnumerable<ProdutoEntity> ObtemPorId(int produtoId);

        public IEnumerable<ProdutoEntity> AtualizaExistente(ProdutoEntity produto);

        public IEnumerable<ProdutoEntity> InsereNovo(ProdutoEntity produto);

        public IEnumerable<ProdutoEntity> Deleta(int produtoId, bool hard = false);

    }
}
