using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models.Paciente
{
    public class PacienteConsultaModel
    {
        public string IdPaciente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
