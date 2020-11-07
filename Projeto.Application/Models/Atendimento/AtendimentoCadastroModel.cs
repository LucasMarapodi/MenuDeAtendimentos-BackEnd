using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Atendimento
{
    public class AtendimentoCadastroModel
    {
        [Required(ErrorMessage ="Por favor, Informe a data do Atendimento.")]
        public string DataAtendimento { get; set; }


        [Required(ErrorMessage ="Por favor, informe o local do atendimento.")]
        public string Local { get; set; }
        [Required(ErrorMessage ="Por favor, informe as Observações.")]
        [MaxLength(ErrorMessage ="Por favor, informe no maximo {1} Caracteres.")]
        public string Observacoes { get; set; }


        [Required(ErrorMessage ="Por favor, Informe o Medico.")]
        public string IdMedico { get; set; }

        [Required(ErrorMessage = "Por favor, Informe o Paciente.")]
        public string IdPaciente { get; set; }
    }
}
