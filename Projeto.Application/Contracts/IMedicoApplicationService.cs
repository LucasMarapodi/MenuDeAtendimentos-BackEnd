using Projeto.Application.Models.Medico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IMedicoApplicationService
    {
        void Create(MedicoCadastroModel model);
        void Delete(int IdMedico);
        void Update(MedicoEdicaoModel model);
        List<MedicoConsultaModel> GetAll();
        MedicoConsultaModel GetById(int IdMedico);
    }
}
