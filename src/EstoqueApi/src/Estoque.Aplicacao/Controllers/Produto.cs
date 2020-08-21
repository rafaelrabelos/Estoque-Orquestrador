using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using static Estorquestrador.Services.DependencyInjection;

namespace Estorquestrador.Controllers
{
    using Fluxos.Produto;
    using Models.Produto;
    using Models.RequestResponse;

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        #region Produto CRUD

            [HttpGet]
            [Route("")]
            public Object ObtemProdutos() {

                try{
                    var result = Service<FluxoProduto>().ObtemTodosAtivos<ProdutoModel>();

                    return new Response<ProdutoModel>{ 
                        Status = true,
                        Resposta = result
                    };
                }catch(Exception e)
                {
                    return new Response<ProdutoModel>{ 
                        Status=false,
                        Resposta= null,
                        Erro = e
                    };
                }
            }

            [HttpGet]
            [Route("{produtoId:int}")]
            public Object ObtemProduto (int produtoId) {

                try{
                    var result = Service<FluxoProduto>().ObtemPorId<ProdutoModel>(produtoId);

                    return new Response<ProdutoModel>{ 
                        Status = true,
                        Resposta = result
                    };
                }catch(Exception e)
                {
                    return new Response<ProdutoModel>{ 
                        Status=false,
                        Resposta= null,
                        Erro = e
                    };
                }
            }

            [HttpPut]
            [Route("")]
            public Object AtualizaProduto ([FromBody] ProdutoModel model) {

                try{
                    var result = Service<FluxoProduto>().AtualizaExistente<ProdutoModel>(model);

                    return new Response<ProdutoModel>{ 
                        Status = true,
                        Resposta = result
                    };
                }catch(Exception e)
                {
                    return new Response<ProdutoModel>{ 
                        Status=false,
                        Resposta= null,
                        Erro = e
                    };
                }
            }

            [HttpDelete]
            [Route("{produtoId:int}")]
            public Object DeletaProdutos (int produtoId) {

                try{
                    var result = Service<FluxoProduto>().Deleta<ProdutoModel>(produtoId, false);

                    return new Response<ProdutoModel>{ 
                        Status = true,
                        Resposta = result
                    };
                }catch(Exception e)
                {
                    return new Response<ProdutoModel>{ 
                        Status=false,
                        Resposta= null,
                        Erro = e
                    };
                }
            }
            
            [HttpPost]
            [Route("")]
            public Object InsereProdutos ([FromBody] ProdutoModel model) {

                try{
                    var result = Service<FluxoProduto>().InsereNovo<ProdutoModel>(model);

                    return new Response<ProdutoModel>{ 
                        Status = true,
                        Resposta = result
                    };
                }catch(Exception e)
                {
                    return new Response<ProdutoModel>{ 
                        Status=false,
                        Resposta= null,
                        Erro = e
                    };
                }
            }

        #endregion
        
    }
}
