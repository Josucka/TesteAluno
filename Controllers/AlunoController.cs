using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using TesteAluno.Models;
using TesteAluno.Services;

namespace TesteAluno.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        IAlunoService _alunoService;
        public AlunoController(IAlunoService service)
        {
            _alunoService = service;
        }

        /// <summary>
        /// Index geral onde retorna tudo que tem listado no banco de dados
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult ListAluno()
        {
            try
            {
                var aluno = _alunoService.GetList();
                if (aluno == null)
                    return NotFound();
                return Ok(aluno);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna o item especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult AlunoById(int? id)
        {
            try
            {
                var aluno = _alunoService.Get(id);
                if (aluno == null)
                    return NotFound();
                return Ok(aluno);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Chamada pra criar um novo item
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateAluno([FromBody] Aluno aluno)
        {
            try
            {
                var novoAluno = _alunoService.Create(aluno);
                return Ok(novoAluno);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// chamada de atualizaçao de item
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateAluno([FromBody] Aluno aluno)
        {
            try
            {
                var atualizarAluno = _alunoService.Update(aluno);
                return Ok(atualizarAluno);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Chamada pra deletar item cadastrado errado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteAluno(int? id)
        {
            try
            {
                var deleteAluno = _alunoService.Delete(id);
                return Ok(deleteAluno);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } 
    }
}
