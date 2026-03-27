using ConnectPlus.DTO;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    /// <summary>
    /// chamada para o metodo cadastrar contato
    /// </summary>
    /// <param name="contatoDTO">status code 200 e contato cadastrado</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Cadastrar(ContatoDTO contatoDTO)
    {

            try
            {
                var novoContato = new Contato
                {
                    Nome = contatoDTO.Nome!,
                    FormaContato = contatoDTO.FormaContato!,
                    Imagem = contatoDTO.Imagem,
                    IdTipoContato = contatoDTO.IdTipoContato
                };
            _contatoRepository.Cadastrar(novoContato);

            return StatusCode(201, novoContato);
        }
            catch (Exception e) { 

                return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// chamada para o metodo de deletar
    /// </summary>
    /// <param name="Id">id do contato a ser excluido</param>
    /// <returns>status code 204</returns>
    [HttpDelete("{Id}")]
    public IActionResult Deletar(Guid Id)
    {
        try
        {
            _contatoRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
    /// <summary>
    /// metodo de atualizar o contato
    /// </summary>
    /// <param name="Id">id do contato a ser atualizado</param>
    /// <param name="contato">contato com os dados atualizados</param>
    /// <returns>code 204 e o contato atualizado</returns>
    [HttpPut("{Id}")]
    public IActionResult Atualizar(Guid Id, Contato contato)
    {

        var ContatoAtualizado = new Contato
        {
            FormaContato = contato.FormaContato!,
            Imagem = contato.Imagem,
            Nome = contato.Nome!,
            IdTipoContato= contato.IdTipoContato
        };
        try
        {
            _contatoRepository.atualizar(Id, contato);
            return StatusCode(204, contato);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// chamada para o metodo de listar contatos
    /// </summary>
    /// <returns>Status code 200 e o contato listado</returns>
    public IActionResult Listar() 
    {
        try
        {
            return Ok(_contatoRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// chamada para o metodo de listar contatos especificos
    /// </summary>
    /// <param name="Id">id do contato a ser listado</param>
    /// <returns>Status code 200 e o contato listado</returns>
    [HttpGet]
    public IActionResult listarContatosEspecificos(Guid Id) 
    {
        try
        {
            return Ok(_contatoRepository.listarContatosEspecificos(Id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    }
