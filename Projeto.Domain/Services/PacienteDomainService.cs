using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class PacienteDomainService : BaseDomainService<Paciente>, IPacienteDomainService
    {
        private readonly IPacienteRepository pacienteRepository;

        public PacienteDomainService(IPacienteRepository pacienteRepository) : base(pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }

        public override void Create(Paciente obj)
        {
            if ((pacienteRepository.GetByCpf(obj.Cpf) == null) && (pacienteRepository.GetByEmail(obj.Email) == null))
            {
                pacienteRepository.Create(obj);

            }
            else
            {
                if (pacienteRepository.GetByCpf(obj.Cpf) != null)
                {
                    throw new Exception("Cpf já cadastrado.");
                }

                if (pacienteRepository.GetByEmail(obj.Email) != null)
                {
                    throw new Exception("Email já cadastrado.");
                }
            }
               
        }

        public Paciente GetByEmail(string email)
        {
            return pacienteRepository.GetByEmail(email);
        }

        public Paciente GetByCpf(string cpf)
        {
            return pacienteRepository.GetByCpf(cpf);
        }

        public override void Delete(Paciente obj)
        {
            if (pacienteRepository.CountAtendimentos(obj.IdPaciente) != 0)
            {
                throw new Exception("Paciente não pode ser Excluido pois possui Atendimentos já marcados.");
            }
            else
            {
                pacienteRepository.Delete(obj);
            }
        }
    }
}
