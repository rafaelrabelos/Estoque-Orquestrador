using System;
using System.Collections.Generic;

namespace Estoque.Dominio.Interfaces.Repositorios
{
    using Dominio.Entidades;

    public interface IImpostoRepository
    {
        public IEnumerable<ImpostoEntity> ObtemTodos();

        public IEnumerable<ImpostoEntity> ObtemPorId(Guid produtoId);

    }
}
