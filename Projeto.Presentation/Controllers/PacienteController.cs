using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Paciente;
using Projeto.Domain.Entities;

namespace Projeto.Presentation.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteApplicationService pacienteApplicationService;

        public PacienteController(IPacienteApplicationService pacienteApplicationService)
        {
            this.pacienteApplicationService = pacienteApplicationService;
        }

        [HttpPost]
        public IActionResult Post(PacienteCadastroModel model)
        {
            try
            {
                pacienteApplicationService.Create(model);
                return Ok("Paciente Cadastrado Com Sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                pacienteApplicationService.Delete(id);
                return Ok("Paciente Excluido Com Sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult put(PacienteEdicaoModel model)
        {
            try
            {
                pacienteApplicationService.Update(model);
                return Ok("Paciente Atualizado Com Sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                
                return Ok(pacienteApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                
                return Ok(pacienteApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
