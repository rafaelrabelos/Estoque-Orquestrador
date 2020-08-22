using System;

namespace Estoque.Dominio.Entidades
{
    public class ImpostoEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string ValorReferencia { get; set; }
    }
}
