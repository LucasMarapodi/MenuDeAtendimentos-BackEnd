using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IPacienteDomainService : IBaseDomainService<Paciente>
    {
        Paciente GetByEmail(string email);
        Paciente GetByCpf(string cpf);
    }
}
