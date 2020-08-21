import axios from 'axios';
import { baseURL } from 'Util/baseUrl';

export const ProdutoSvc = {
    ObtemTodos, Deleta, Atualiza, Salva
};

async function ObtemTodos(){

    try {
        const url = `${baseURL}Produto`;


        let resp = await axios.get( url)
            .then(
                (res) =>  res.data ,
                (err) =>  err.response.data 
            )
            .catch((err) => { return err;})
            
        return resp;
    } catch (err) {
        return err;
    }

}

async function Deleta(produtoId){

    try {
        const url = `${baseURL}Produto/${produtoId}`;

        return axios({ 
            method : 'DELETE',
            url : url
        })
        .then(
            (res) =>  res.data ,
            (err) =>  err.response.data 
        )
        .catch((err) => { return err;})
            
    } catch (err) {
        return err;
    }

}


async function Atualiza(id,NomeProduto, QtdProduto, ValorProduto){

    try {
        const url = `${baseURL}Produto`;

        return axios({ 
            method : 'PUT',
            url : url,
            data :{
                id,
                Nome: NomeProduto,
                Qtd: QtdProduto,
                Valor: ValorProduto
            }
        })
        .then(
            (res) =>  res.data ,
            (err) =>  err.response.data 
        )
        .catch((err) => { return err;})
            
    } catch (err) {
        return err;
    }

}

async function Salva(NomeProduto, QtdProduto, ValorProduto){

    try {
        const url = `${baseURL}Produto`;

        return axios({ 
            method : 'POST',
            url : url,
            data :{
                Nome: NomeProduto,
                Qtd: QtdProduto,
                Valor: ValorProduto
            }
        })
        .then(
            (res) =>  res.data ,
            (err) =>  err.response.data 
        )
        .catch((err) => { return err;})
            
    } catch (err) {
        return err;
    }

}