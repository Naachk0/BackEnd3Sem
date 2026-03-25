using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _TipoUsuarioRepository;

    //injecao de dependencia
    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _TipoUsuarioRepository = tipoUsuarioRepository;
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de lista os tipos de usuario
    /// </summary>
    /// <returns>Statusmcode 200 e alista de tipos de usuario</returns>
    [HttpGet]
    public IActionResult Listar()
    {

        try
        {
            return Ok(_TipoUsuarioRepository.Listar());
        }

        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }

    /// <summary>
    /// EndPoint fa API que faz a chamada para o metodo de buscar um tipo de usuario especifico
    /// </summary>
    /// <param name="Id">Id do tipo de usuario buscado</param>
    /// <returns>Status code 200 e o tipo de usuario buscado</returns>
    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_TipoUsuarioRepository.BuscarPorId(Id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Nedpoint da API que faz chamada parar o metodo de cadastro de um tipo de usuario
    /// </summary>
    /// <param name="tipoUSuario">tipo de usuario a ser cadastrado</param>
    /// <returns>code 201 e o tipo de usuario a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var novoTipoDeUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!

            };
            _TipoUsuarioRepository.Cadastrar(novoTipoDeUsuario);

            return StatusCode(201, tipoUsuario);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da APi que faz o metodo de atualizar um tipo de usuario
    /// </summary>
    /// <param name="Id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoUsuario">tipo de usuario com os dados atualizados</param>
    /// <returns>code 204 e o tipo de usuario atualizado</returns>
    [HttpPut("{Id}")]
    public IActionResult Atualizar(Guid Id, TipoUsuario tipoUsuario)
    {

        var tipoUsuarioAtualizado = new TipoUsuario
        {
            Titulo = tipoUsuario.Titulo!
        };
        try
        {
            _TipoUsuarioRepository.atualizar(Id, tipoUsuario);
            return StatusCode(204, tipoUsuario);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar
    /// </summary>
    /// <param name="Id">id do tipo de usuario a ser excluido</param>
    /// <returns>status code 204</returns>
    [HttpDelete("{Id}")]
    public IActionResult Delete(Guid Id)
    {
        try
        {
            _TipoUsuarioRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
}
