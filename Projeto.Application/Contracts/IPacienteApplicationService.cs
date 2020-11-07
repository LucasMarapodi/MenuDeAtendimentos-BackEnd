using Projeto.Application.Models.Paciente;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IPacienteApplicationService
    {
        void Create(PacienteCadastroModel model);
        void Delete(int IdPaciente);
        void Update(PacienteEdicaoModel model);
        List<PacienteConsultaModel> GetAll();
        PacienteConsultaModel GetById(int IdPaciente);
    }
}
