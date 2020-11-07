using Projeto.Application.Models.Medico;
using Projeto.Application.Models.Paciente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models.Atendimento
{
    public class AtendimentoConsultaModel
    {
        public string IdAtendimento { get; set; }
        public string DataAtendimento { get; set; }
        public string Local { get; set; }
        public string Observacoes { get; set; }

        //Chamada do medico e do paciente durante a consulta do Atendimento

        public MedicoConsultaModel Medico{ get; set; }
        public PacienteConsultaModel Paciente { get; set; }
    }
}
