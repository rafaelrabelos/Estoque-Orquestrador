import { ProdutoSvc } from 'Servicos/Produto';

export const Produto = {
    ObtemProdutos, DeletaProduto, AtualizaProduto, SalvaProduto
};

export{ ObtemProdutos, DeletaProduto, AtualizaProduto, SalvaProduto }

async function ObtemProdutos()
{
    return await ProdutoSvc.ObtemTodos()
    .then(
        res => {
            
            if (res && res.status)
            {
                return (res);
            }

            return {
                data:{ 
                    status:false,
                    data:res.data || { erros :[{"Get":"Erro desconhecido ao obter dados"}] } 
                }
            }
        },
        err => {
            console.log(err)
            return (err);
        }
    )
}

async function DeletaProduto(produtoId)
{
    return await ProdutoSvc.Deleta(produtoId)
    .then(
        res => {
            
            if (res && res.status)
            {
                return (res);
            }

            return {
                data:{ 
                    status:false,
                    data:res.data || { erros :[{"Get":"Erro desconhecido ao obter dados"}] } 
                }
            }
        },
        err => {
            console.log(err)
            return (err);
        }
    )
}

async function AtualizaProduto(id, NomeProduto, QtdProduto, ValorProduto)
{
    return await ProdutoSvc.Atualiza(id, NomeProduto, QtdProduto, ValorProduto)
    .then(
        res => {
            
            if (res && res.status)
            {
                return (res);
            }

            return {
                data:{ 
                    status:false,
                    data:res.data || { erros :[{"Get":"Erro desconhecido ao obter dados"}] } 
                }
            }
        },
        err => {
            console.log(err)
            return (err);
        }
    )
}

async function SalvaProduto(id, NomeProduto, QtdProduto, ValorProduto)
{
    return await ProdutoSvc.Salva(id, NomeProduto, QtdProduto, ValorProduto)
    .then(
        res => {
            
            if (res && res.status)
            {
                return (res);
            }

            return {
                data:{ 
                    status:false,
                    data:res.data || { erros :[{"Get":"Erro desconhecido ao obter dados"}] } 
                }
            }
        },
        err => {
            console.log(err)
            return (err);
        }
    )
}



