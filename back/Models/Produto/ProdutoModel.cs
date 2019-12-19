using System;
using System.Collections.Generic;
namespace Estorquestrador.Models.Produto
{
    
    public class ProdutoModel
    {
        public int id { get; set; }
        public String Nome { get; set; }
        public int Qtd { get; set; }
        public long Valor { get; set; }
        public bool Excluido { get; set; }
        public DateTime Criado_em { get; set; }
        public DateTime Alterado_em { get; set; }
    }
}