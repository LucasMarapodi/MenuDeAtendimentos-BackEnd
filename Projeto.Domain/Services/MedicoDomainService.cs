using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class MedicoDomainService : BaseDomainService<Medico>, IMedicoDomainService
    {
        private readonly IMedicoRepository medicoRepository;

        public MedicoDomainService(IMedicoRepository medicoRepository) : base(medicoRepository)
        {
            this.medicoRepository = medicoRepository;
        }

        public override void Delete(Medico obj)
        {
            if (medicoRepository.CountAtendimentos(obj.IdMedico) != 0)
            {
                throw new Exception("Medico não pode ser Excluido pois possui Atendimentos já marcados.");
            }
            else
            {
                medicoRepository.Delete(obj);
            }
        }
    }
}
