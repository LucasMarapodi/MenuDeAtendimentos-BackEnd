using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class AtendimentoRepository : BaseRepository<Atendimento>, IAtendimentoRepository
    {
        private readonly DataContext dataContext;

        public AtendimentoRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public override Atendimento GetById(int id)
        {
            return dataContext.Atendimento.Include(a => a.Medico).Include(a => a.Paciente).FirstOrDefault(a => a.IdAtendimento == id );
        }

        public override List<Atendimento> GetAll()
        {
            return dataContext.Atendimento.Include(a => a.Medico).Include(a => a.Paciente).ToList();
        }
    }
}
