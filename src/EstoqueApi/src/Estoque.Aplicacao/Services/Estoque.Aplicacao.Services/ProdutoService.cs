using System;
using System.Linq;
using System.Collections.Generic;

namespace Estoque.Aplicacao.Services
{
    using Estoque.Dominio.Entidades;
    using Estoque.Dominio.Interfaces.Repositorios;
    using Interfaces;
   


    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService( IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoEntity> ObterProdutos()
        {
            return _produtoRepository.ObtemTodos();
        }

        public ProdutoEntity ObterProdutoPorId(int produtoId)
        {
            return _produtoRepository.ObtemPorId(produtoId).Single();
        }

        public ProdutoEntity AtualizarProduto(ProdutoEntity produto)
        {
            return _produtoRepository.AtualizaExistente(produto).Single();
        }

        public ProdutoEntity DeletarProduto(int produtoId)
        {
            return _produtoRepository.Deleta(produtoId).Single();
        }

        public ProdutoEntity InserirProduto(ProdutoEntity produto)
        {
            return _produtoRepository.InsereNovo(produto).Single();
        }
    }
}
