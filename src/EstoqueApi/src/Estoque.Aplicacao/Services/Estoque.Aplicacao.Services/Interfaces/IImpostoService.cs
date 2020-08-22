using System;
using System.Collections.Generic;
using Estoque.Dominio.Entidades;

namespace Estoque.Aplicacao.Services.Interfaces
{
    public interface IImpostoService
    {
        public IEnumerable<ImpostoEntity> ObterImpostos();
        public ImpostoEntity ObterImpostoPorId(Guid produtoId);
    }
}
