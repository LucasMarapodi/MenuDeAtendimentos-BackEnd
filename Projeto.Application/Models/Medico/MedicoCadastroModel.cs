using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Medico
{
    public class MedicoCadastroModel
    {
        [Required(ErrorMessage ="Por favor, informe o Nome do Medico.")]
        [MaxLength(150, ErrorMessage ="Por favor, informe no maximo {1} Caracteres.")]
        [MinLength(3, ErrorMessage ="Por favor, informe no minimoo {1} Caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CRM.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no maximo {1} Caracteres.")]
        public string Crm { get; set; }

        [MaxLength(300,ErrorMessage ="Por favor, informe no maximo {1} Caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a Especialização.")]
        public string Especializacao { get; set; }
    }
}
