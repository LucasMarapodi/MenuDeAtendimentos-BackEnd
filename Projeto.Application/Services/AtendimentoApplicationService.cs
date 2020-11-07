using Projeto.Application.Contracts;
using Projeto.Application.Models.Atendimento;
using Projeto.Application.Models.Medico;
using Projeto.Application.Models.Paciente;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class AtendimentoApplicationService : IAtendimentoApplicationService
    {
        private readonly IAtendimentoDomainService atendimentoDomainService;

        public AtendimentoApplicationService(IAtendimentoDomainService atendimentoDomainService)
        {
            this.atendimentoDomainService = atendimentoDomainService;
        }

        public void Create(AtendimentoCadastroModel model)
        {
            var atendimento = new Atendimento();

            atendimento.IdMedico = int.Parse(model.IdMedico);
            atendimento.IdPaciente = int.Parse(model.IdPaciente);
            atendimento.Local = model.Local;
            atendimento.Observacoes = model.Observacoes;
            atendimento.DataAtendimento = DateTime.Parse(model.DataAtendimento);

            atendimentoDomainService.Create(atendimento);
        }

        public void Delete(int IdAtendimento)
        {
            var atendimento = atendimentoDomainService.GetById(IdAtendimento);

            atendimentoDomainService.Delete(atendimento);
        }

        public void Update(AtendimentoEdicaoModel model)
        {
            var atendimento = new Atendimento();

            atendimento.IdAtendimento = int.Parse(model.IdAtendimento);
            atendimento.DataAtendimento = DateTime.Parse(model.DataAtendimento);
            atendimento.IdMedico = int.Parse(model.IdMedico);
            atendimento.IdPaciente = int.Parse(model.IdPaciente);
            atendimento.Local = model.Local;
            atendimento.Observacoes = model.Observacoes;

            atendimentoDomainService.Update(atendimento);
        }

        public List<AtendimentoConsultaModel> GetAll()
        {
            var atendimentos = new List<AtendimentoConsultaModel>();

            foreach (var atendimento in atendimentoDomainService.GetAll())
            {
                var model = new AtendimentoConsultaModel();

                model.IdAtendimento = atendimento.IdAtendimento.ToString();
                model.DataAtendimento = atendimento.DataAtendimento.ToString("dd/MM/yyyy");
                model.Local = atendimento.Local;
                model.Observacoes = atendimento.Observacoes;

                model.Medico = new MedicoConsultaModel();
                model.Paciente = new PacienteConsultaModel();

                model.Medico.IdMedico = atendimento.Medico.IdMedico.ToString();
                model.Medico.Nome = atendimento.Medico.Nome;
                model.Medico.Crm = atendimento.Medico.Crm;
                model.Medico.Especializacao = atendimento.Medico.Especializacao;

                model.Paciente.IdPaciente = atendimento.Paciente.IdPaciente.ToString();
                model.Paciente.Nome = atendimento.Paciente.Nome;
                model.Paciente.DataNascimento = atendimento.Paciente.DataNascimento.ToString("dd/MM/yyyy");
                model.Paciente.Cpf = atendimento.Paciente.Cpf;
                model.Paciente.Email = atendimento.Paciente.Email;
                model.Paciente.Telefone = atendimento.Paciente.Telefone;

                atendimentos.Add(model);
            }

            return atendimentos;
        }

        public AtendimentoConsultaModel GetById(int IdAtendimento)
        {
            var model = new AtendimentoConsultaModel();

            var atendimento = atendimentoDomainService.GetById(IdAtendimento);

            model.IdAtendimento = atendimento.IdAtendimento.ToString();
            model.DataAtendimento = atendimento.DataAtendimento.ToString("dd/MM/yyyy");
            model.Local = atendimento.Local;
            model.Observacoes = atendimento.Observacoes;

            model.Medico = new MedicoConsultaModel();
            model.Paciente = new PacienteConsultaModel();

            model.Medico.IdMedico = atendimento.Medico.IdMedico.ToString();
            model.Medico.Nome = atendimento.Medico.Nome;
            model.Medico.Crm = atendimento.Medico.Crm;
            model.Medico.Especializacao = atendimento.Medico.Especializacao;

            model.Paciente.IdPaciente = atendimento.Paciente.IdPaciente.ToString();
            model.Paciente.Nome = atendimento.Paciente.Nome;
            model.Paciente.DataNascimento = atendimento.Paciente.DataNascimento.ToString("dd/MM/yyyy");
            model.Paciente.Cpf = atendimento.Paciente.Cpf;
            model.Paciente.Email = atendimento.Paciente.Email;
            model.Paciente.Telefone = atendimento.Paciente.Telefone;

            return model;
        }
    }
}
