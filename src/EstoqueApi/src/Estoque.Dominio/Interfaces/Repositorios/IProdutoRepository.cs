using System.Collections.Generic;

namespace Estoque.Dominio.Interfaces.Repositorios
{
    using Dominio.Entidades;

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
