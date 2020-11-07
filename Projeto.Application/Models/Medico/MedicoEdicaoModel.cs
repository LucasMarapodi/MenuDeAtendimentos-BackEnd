using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.Models.Medico
{
    public class MedicoEdicaoModel
    {
        [Required(ErrorMessage ="Por favor, Informe o Id do Medico")]
        public string IdMedico { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Nome do Medico.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no maximo {1} Caracteres.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no minimoo {1} Caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CRM.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no maximo {1} Caracteres.")]
        public string Crm { get; set; }

        [MaxLength(300, ErrorMessage = "Por favor, informe no maximo {1} Caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a Especialização.")]
        public string Especializacao { get; set; }
    }
}
