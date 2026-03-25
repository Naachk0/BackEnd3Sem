using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]

public class EventoController : Controller
{
    private readonly IEventoRepository _eventoRepository;

    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }
    /// <summary>
    /// Endpoint da Api que faz a chamada para o metodo de listar eventos filtrado por usuario
    /// </summary>
    /// <param name="IdUsuario">id de usuario para filtragem</param>
    /// <returns>lista de eventos filtrados por usuario</returns>
    [HttpGet("Usuario/{IdUsuario}")]
    public IActionResult ListarPorId(Guid IdUsuario) 
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(IdUsuario));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz chamada da lista de proximos eventos
    /// </summary>
    /// <returns>status code 200 e uma lisya de proximos eventos</returns>
    [HttpGet("ListarProximosEventos")]
    public IActionResult BuscarProximosEventos()
    {
        try
        {
            return Ok(_eventoRepository.ListarProximosEventos());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de cadastrar evento
    /// </summary>
    /// <param name="evento">evento a ser cadastrado </param>
    /// <returns>Status code 201 e o evento cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                Descricao = evento.Descricao!,
                DataEvento = evento.DataEvento,
                IdTipoEvento = evento.IdTipoEvento
            };

            _eventoRepository.Cadastrar(novoEvento);

            return StatusCode(201, novoEvento);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

}

