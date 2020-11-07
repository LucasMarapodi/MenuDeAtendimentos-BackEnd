using Projeto.Application.Models.Atendimento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IAtendimentoApplicationService
    {
        void Create(AtendimentoCadastroModel model);
        void Delete(int IdAtendimento);
        void Update(AtendimentoEdicaoModel model);
        List<AtendimentoConsultaModel> GetAll();
        AtendimentoConsultaModel GetById(int IdAtendimento);
    }
}
