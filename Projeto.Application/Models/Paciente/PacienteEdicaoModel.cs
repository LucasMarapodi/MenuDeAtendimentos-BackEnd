using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Paciente
{
    public class PacienteEdicaoModel
    {
        [Required(ErrorMessage ="Informe o Id do Paciente.")]
        public string IdPaciente { get; set; }

        [Required(ErrorMessage = "Por favor, Informe um Nome.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no maximo {1} Letras.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no minimo {1} Letras.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Por favor, Informe um Cpf.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe um Cpf valido, sem pontuação.")]
        public string Cpf { get; set; }


        [Required(ErrorMessage = "Por favor, Informe a Data de Nascimento do Paciente.")]
        public string DataNascimento { get; set; }


        [Required(ErrorMessage = "Por favor, Informe Telefone.")]
        public string Telefone { get; set; }


        [EmailAddress(ErrorMessage = "Por favor, Informe um Email Valido.")]
        [Required(ErrorMessage = "Por favor, Informe um Email.")]
        public string Email { get; set; }
    }
}
