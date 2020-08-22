using System;

namespace Estoque.Dominio.Entidades
{
    public class ProdutoEntity
    {
        public int id { get; set; }
        public String Nome { get; set; }
        public String Codigo { get; set; }
        public int Qtd { get; set; }
        public double Valor { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
