using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Paciente GetByEmail(string email);
        Paciente GetByCpf(string Cpf);
        int CountAtendimentos(int id);
    }
}
