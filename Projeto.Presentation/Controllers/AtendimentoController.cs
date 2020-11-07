using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Atendimento;

namespace Projeto.Presentation.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoApplicationService atendimentoApplicationService;

        public AtendimentoController(IAtendimentoApplicationService atendimentoApplicationService)
        {
            this.atendimentoApplicationService = atendimentoApplicationService;
        }


        [HttpPost]
        public IActionResult Post(AtendimentoCadastroModel model)
        {
            try
            {
                atendimentoApplicationService.Create(model);
                return Ok("Atendimento Cadastrado Com Sucesso.");
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
                atendimentoApplicationService.Delete(id);
                return Ok("Atendimento Excluido Com Sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult put(AtendimentoEdicaoModel model)
        {
            try
            {
                atendimentoApplicationService.Update(model);
                return Ok("Atendimento Atualizado Com Sucesso.");
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

                return Ok(atendimentoApplicationService.GetAll());
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

                return Ok(atendimentoApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
