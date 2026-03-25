using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _eventoRepository;

    //injecao de dependencia
    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _eventoRepository = tipoEventoRepository;
    }



    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de lista os tipos de eventos
    /// </summary>
    /// <returns>Statusmcode 200 e alista de tipos de eventos</returns>
    [HttpGet]
    public IActionResult Listar() {

        try
        {
            return Ok(_eventoRepository.Listar());
        }

        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }
    /// <summary>
    /// EndPoint fa API que faz a chamada para o metodo de buscar um tipo de evento especifico
    /// </summary>
    /// <param name="Id">Id do tipo de evento buscado</param>
    /// <returns>Status code 200 e o tipo de evento buscado</returns>
    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_eventoRepository.BuscarPorId(Id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
   
    /// <summary>
    /// Nedpoint da API que faz chamada parar o metodo de cadastro de um tipo de evento
    /// </summary>
    /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>
    /// <returns>code 201 e o tipo de evento a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!

            };
           _eventoRepository.Cadastrar(novoTipoEvento);

            return StatusCode(201, tipoEvento);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da APi que faz o metodo de atualizar um tipo de evento
    /// </summary>
    /// <param name="Id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">tipo de evento com os dados atualizados</param>
    /// <returns>code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{Id}")]
    public IActionResult Atualizar(Guid Id, TipoEvento tipoEvento)
    {

        var tipoEventoAtualizado = new TipoEvento
        {
            Titulo = tipoEvento.Titulo!
        };
        try
        {
            _eventoRepository.atualizar(Id, tipoEvento);
            return StatusCode(204, tipoEvento);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar
    /// </summary>
    /// <param name="Id">id do tipo de evento a ser excluido</param>
    /// <returns>status code 204</returns>
    [HttpDelete("{Id}")]
    public IActionResult Delete(Guid Id)
    {
        try
        {
            _eventoRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
}

