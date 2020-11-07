using Projeto.Application.Contracts;
using Projeto.Application.Models.Paciente;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using Projeto.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class PacienteApplicationService : IPacienteApplicationService
    {
        private readonly IPacienteDomainService pacienteDomainService;

        public PacienteApplicationService(IPacienteDomainService pacienteDomainService)
        {
            this.pacienteDomainService = pacienteDomainService;
        }

        public void Create(PacienteCadastroModel model)
        {
            var paciente = new Paciente();

            paciente.Nome = model.Nome;
            paciente.Email = model.Email;
            paciente.Cpf = model.Cpf;
            paciente.DataNascimento = DateTime.Parse(model.DataNascimento);
            paciente.Telefone = model.Telefone;

            pacienteDomainService.Create(paciente);
        }

        public void Delete(int IdPaciente)
        {
            var paciente = pacienteDomainService.GetById(IdPaciente);

            pacienteDomainService.Delete(paciente);
        }

        public void Update(PacienteEdicaoModel model)
        {
            var paciente = new Paciente();

            paciente.IdPaciente = int.Parse(model.IdPaciente);
            paciente.Nome = model.Nome;
            paciente.Email = model.Email;
            paciente.Cpf = model.Cpf;
            paciente.DataNascimento = DateTime.Parse(model.DataNascimento);
            paciente.Telefone = model.Telefone;

            pacienteDomainService.Update(paciente);

        }

        public List<PacienteConsultaModel> GetAll()
        {
            var pacientes = new List<PacienteConsultaModel>();

            foreach (var paciente in pacienteDomainService.GetAll())
            {
                var model = new PacienteConsultaModel();

                model.IdPaciente = paciente.IdPaciente.ToString();
                model.Nome = paciente.Nome;
                model.Email = paciente.Email;
                model.Cpf = paciente.Cpf;
                model.DataNascimento = paciente.DataNascimento.ToString("dd/MM/yyyy");
                model.Telefone = paciente.Telefone;

                pacientes.Add(model);
            }
            return pacientes;
        }

        public PacienteConsultaModel GetById(int IdPaciente)
        {
            var paciente = pacienteDomainService.GetById(IdPaciente);

            var model = new PacienteConsultaModel();

            model.IdPaciente = paciente.IdPaciente.ToString();
            model.Nome = paciente.Nome;
            model.Email = paciente.Email;
            model.Cpf = paciente.Cpf;
            model.DataNascimento = paciente.DataNascimento.ToString("dd/MM/YYYY");
            model.Telefone = paciente.Telefone;

            return model;
        }
    }
}
