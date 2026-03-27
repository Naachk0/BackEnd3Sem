using ConnectPlus.DTO;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using ConnectPlus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        /// <summary>
        /// chamada para o metodo cadastrar tipo contato
        /// </summary>
        /// <param name="tipoContatoDTO">status code 200 e tipo contato cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoContatoDTO tipoContatoDTO)
        {

            try
            {
                var novoTipocontato = new TipoContato
                {
                   Titulo = tipoContatoDTO.Titulo!
                };
                _tipoContatoRepository.Cadastrar(novoTipocontato);

                return StatusCode(201, novoTipocontato);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// chamada para o metodo de deletar tipo  contato
        /// </summary>
        /// <param name="Id">id do tipo contato a ser excluido</param>
        /// <returns>status code 204 w tipo contato deletado</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(Guid Id)
        {
            try
            {
                _tipoContatoRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
        /// <summary>
        /// metodo de atualizar o tipo contato
        /// </summary>
        /// <param name="Id">id do tipo contato a ser atualizado</param>
        /// <param name="contato">tipo contato com os dados atualizados</param>
        /// <returns>code 204 e o tipo contato atualizado</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(Guid Id, TipoContatoDTO tipoContatoDTO)
        {
            try
            {
                var tipoContato = new TipoContato
                {
                    Titulo = tipoContatoDTO.Titulo
                };
                _tipoContatoRepository.atualizar(Id, tipoContato);
                return Ok("Tipo de contato atualizado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// chamada para o metodo de listar os tipos de contatos
        /// </summary>
        /// <returns>Status code 200 e o tipo contato listado</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoContatoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// chamada para o metodo de listar o id do tipo contato
        /// </summary>
        /// <param name="Id">id do tipo contato a ser listado</param>
        /// <returns>Status code 200 e o tipo contato listado</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(Guid Id)
        {
            try
            {
                return Ok(_tipoContatoRepository.BuscarPorId(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
