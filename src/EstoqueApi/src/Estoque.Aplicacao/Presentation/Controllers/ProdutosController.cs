using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Estorquestrador.Controllers
{
    using Estoque.Aplicacao.Services.Interfaces;
    using Estoque.Dominio.Entidades;

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ObtemProdutos() {

            var result = this._produtoService.ObterProdutos();

            return new OkObjectResult(new
            {
                success = result.Any(),
                message = result.Any() ? null : "Nenhum produto encontrado",
                data = result
            });
        }

        [HttpGet]
        [Route("{produtoId:int}")]
        public IActionResult ObtemProduto (int produtoId) {

            var result =  this._produtoService.ObterProdutoPorId(produtoId);

            return new OkObjectResult(new
            {
                success = result != null,
                message = result != null ? null : "Produto não encontrado",
                data = result
            });
        }

        [HttpPut]
        [Route("")]
        public IActionResult AtualizaProduto ([FromBody] ProdutoEntity produto) {

            var result = this._produtoService.AtualizarProduto(produto);

            return new OkObjectResult(new
            {
                success = result != null,
                message = result != null ? null : "Produto não atualizado",
                data = result
            });
        }

        [HttpDelete]
        [Route("{produtoId:int}")]
        public IActionResult DeletaProdutos (int produtoId) {

            var result = this._produtoService.DeletarProduto(produtoId);

            return new OkObjectResult(new
            {
                success = result != null,
                message = result != null ? null : "Produto não removido",
                data = result
            });
        }
            
        [HttpPost]
        [Route("")]
        public IActionResult InsereProdutos ([FromBody] ProdutoEntity model) {

            var result = this._produtoService.InserirProduto(model);

            return new OkObjectResult(new
            {
                success = result != null,
                message = result != null ? null : "Produto não removido",
                data = result
            });
        }
        
    }
}
