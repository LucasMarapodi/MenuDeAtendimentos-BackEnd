using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        private readonly DataContext dataContext;

        public PacienteRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Paciente GetByEmail(string email)
        {
            return dataContext.Paciente.FirstOrDefault(p => p.Email.Equals(email));
        }

        public Paciente GetByCpf(string Cpf)
        {
            return dataContext.Paciente.FirstOrDefault(p => p.Cpf.Equals(Cpf));
        }
        
        public int CountAtendimentos(int id)
        {
            return dataContext.Atendimento.Count(p => p.IdPaciente == (id));
        }

    }
}
