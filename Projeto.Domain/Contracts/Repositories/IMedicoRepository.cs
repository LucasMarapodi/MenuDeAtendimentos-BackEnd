using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        public int CountAtendimentos(int id);
    }
}
