using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : Controller
{
    private readonly IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }

    /// <summary>
    /// endpoint da API que retorna uma lista de presencas de usuario
    /// </summary>
    /// <param name="IdUsuario">id do usuario para filtragem</param>
    /// <returns>status code 200 e uma linha de presencas</returns>
    [HttpGet("ListarMinhas/{IdUsuario}")]
    public IActionResult BuscarMinhas(Guid IdUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(IdUsuario));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// endpoint da api que faz metodo inscrever presenca
    /// </summary>
    /// <param name="presenca">presenca inscrita</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {
            var novaPresenca = new Presenca
            {

                Situacao = presenca.Situacao,
                IdEvento = presenca.IdEvento,
                IdUsuario = presenca.IdUsuario

            };
            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da APi que faz o metodo de atualizar uma presenca
    /// </summary>
    /// <param name="Id">id da presenca a ser atualizada</param>
    /// <param name="presenca">presenca com os dados atualizados</param>
    /// <returns>code 204 e a presenca atualizada</returns>
    [HttpPut("{Id}")]
    public IActionResult Atualizar(Guid Id, Presenca presenca)
    {
        try
        {

            var presencaAtualizada = new Presenca
            {
                Situacao = presenca.Situacao!
            };
            _presencaRepository.atualizar(Id, presenca);
            return StatusCode(204, presenca);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz o metodo de deletar presenca
    /// </summary>
    /// <param name="Id">id da presenca a ser excluida</param>
    /// <returns>status code 204</returns>
    [HttpDelete("{Id}")]
    public IActionResult Delete(Guid Id)
    {
        try
        {
            _presencaRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de lista as presencas
    /// </summary>
    /// <returns>Statusmcode 200 e alista de presenca</returns>
    [HttpGet]
    public IActionResult Listar()
    {

        try
        {
            return Ok(_presencaRepository.Listar());
        }

        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de listar as minhas presencas
    /// </summary>
    /// <returns>Statusmcode 200 e lista de minhas presencas</returns>
    [HttpGet("{IdUSuario}")]
    public IActionResult ListarMinhas(Guid IdUSuario)
    {

        try
        {
            return Ok(_presencaRepository.ListarMinhas(IdUSuario));
        }

        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

  
    /// <summary>
    /// EndPoint faz API que faz a chamada para o metodo de buscar uma presenca especifica
    /// </summary>
    /// <param name="Id">Id da presenca buscada</param>
    /// <returns>Status code 200 e a presenca buscada</returns>
    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(Id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

}
