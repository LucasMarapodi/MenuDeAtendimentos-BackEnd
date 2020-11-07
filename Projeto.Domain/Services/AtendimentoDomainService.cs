using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class AtendimentoDomainService : BaseDomainService<Atendimento>, IAtendimentoDomainService
    {
        private readonly IAtendimentoRepository atendimentoRepository;

        public AtendimentoDomainService(IAtendimentoRepository atendimentoRepository) : base(atendimentoRepository)
        {
            this.atendimentoRepository = atendimentoRepository;
        }
    }
}
