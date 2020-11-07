using Projeto.Application.Contracts;
using Projeto.Application.Models.Medico;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class MedicoApplicationService : IMedicoApplicationService
    {
        private readonly IMedicoDomainService medicoDomainService;

        public MedicoApplicationService(IMedicoDomainService medicoDomainService)
        {
            this.medicoDomainService = medicoDomainService;
        }

        public void Create(MedicoCadastroModel model)
        {
            var medico = new Medico();

            medico.Nome = model.Nome;
            medico.Crm = model.Crm;
            medico.Especializacao = model.Especializacao;

            medicoDomainService.Create(medico);
        }

        public void Delete(int IdMedico)
        {
            var medico = medicoDomainService.GetById(IdMedico);

            medicoDomainService.Delete(medico);
        }

        public void Update(MedicoEdicaoModel model)
        {
            var medico = new Medico();

            medico.IdMedico = int.Parse(model.IdMedico);
            medico.Nome = model.Nome;
            medico.Crm = model.Crm;
            medico.Especializacao = model.Especializacao;

            medicoDomainService.Update(medico);
        }

        public List<MedicoConsultaModel> GetAll()
        {
            var medicos = new List<MedicoConsultaModel>();

            foreach ( var medico in medicoDomainService.GetAll())
            {
                var model = new MedicoConsultaModel();

                model.Nome = medico.Nome;
                model.Crm = medico.Crm;
                model.Especializacao = medico.Especializacao;
                model.IdMedico = medico.IdMedico.ToString();


                medicos.Add(model);
            }

            return medicos;
        }

        public MedicoConsultaModel GetById(int IdMedico)
        {
            var medico = medicoDomainService.GetById(IdMedico);

            var model = new MedicoConsultaModel();

            model.Nome = medico.Nome;
            model.Crm = medico.Crm;
            model.Especializacao = medico.Especializacao;
            model.IdMedico = medico.IdMedico.ToString() ;

            return model;
        }
    }
}
