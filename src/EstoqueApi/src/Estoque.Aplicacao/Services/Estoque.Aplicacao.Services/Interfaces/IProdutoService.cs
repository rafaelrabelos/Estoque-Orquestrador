using System;
using System.Collections.Generic;
using Estoque.Dominio.Entidades;

namespace Estoque.Aplicacao.Services.Interfaces
{
    public interface IProdutoService
    {
        public IEnumerable<ProdutoEntity> ObterProdutos();
        public ProdutoEntity ObterProdutoPorId(int produtoId);
        public ProdutoEntity AtualizarProduto(ProdutoEntity produto);
        public ProdutoEntity DeletarProduto(int produtoId);
        public ProdutoEntity InserirProduto(ProdutoEntity produto);
    }
}
