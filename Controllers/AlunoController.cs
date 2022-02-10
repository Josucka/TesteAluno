using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TesteAluno.Models;
using TesteAluno.Services;

namespace TesteAluno.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("/api/[controller]")]
    public class AlunoController : ApiBaseController
    {
        IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Index geral onde retorna tudo que tem listado no banco de dados
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());

        /// <summary>
        /// Retorna o item especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Aluno alunoExistente = _service.Get(id);

            return alunoExistente == null ? ApiNotFound("Id não encontrado") : ApiOk(alunoExistente);
        }
        
        /// <summary>
        /// Chamada pra criar um novo item
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public IActionResult Create([FromBody] Aluno aluno)
        {
            return _service.Create(aluno) ? ApiOk(aluno, "Item criado com sucesso") : ApiNotFound("Falha ao criar item");
        }

        /// <summary>
        /// chamada de atualizaçao de item
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Aluno aluno)
        {
            return _service.Update(aluno) ? ApiOk("item atualizado com sucesso") : ApiNotFound("Erro ao atualizar item");
        }

        /// <summary>
        /// Chamada pra deletar item cadastrado errado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) => _service.Delete(id) ? ApiOk("Apagado com sucesso") : ApiNotFound("Erro ao tentar apagar item");
    }
}
