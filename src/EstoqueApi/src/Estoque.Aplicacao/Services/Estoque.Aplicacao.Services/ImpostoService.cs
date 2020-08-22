using System;
using System.Linq;
using System.Collections.Generic;
using Estoque.Dominio.Entidades;
using Estoque.Dominio.Interfaces.Repositorios;

namespace Estoque.Aplicacao.Services
{
    using Interfaces;

    public class ImpostoService : IImpostoService
    {
        private readonly IImpostoRepository _impostoRepository;
        public ImpostoService(IImpostoRepository impostoRepository)
        {
            this._impostoRepository = impostoRepository;
        }

        public IEnumerable<ImpostoEntity> ObterImpostos()
        {
            return _impostoRepository.ObtemTodos();
        }

        public ImpostoEntity ObterImpostoPorId(Guid produtoId)
        {
            return _impostoRepository.ObtemPorId(produtoId).Single();
        }
    }
}
