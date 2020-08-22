using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Estoque.Aplicacao.Services.Interfaces;

namespace Estoque.Orquestrador.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ImpostoController : ControllerBase
    {
        private readonly IImpostoService _impostoService;

        public ImpostoController(IImpostoService impostoService)
        {
            this._impostoService = impostoService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ObtemTodos() {

            var result = this._impostoService.ObterImpostos();

            return new OkObjectResult(new
            {
                success = result.Any(),
                message = result.Any() ? null : "Nenhum produto encontrado",
                data = result
            });
        }

        [HttpGet]
        [Route("{produtoId}")]
        public IActionResult ObtemImposto (Guid produtoId) {

            var result =  this._impostoService.ObterImpostoPorId(produtoId);

            return new OkObjectResult(new
            {
                success = result != null,
                message = result != null ? null : "Produto não encontrado",
                data = result
            });
        }
        
    }
}
