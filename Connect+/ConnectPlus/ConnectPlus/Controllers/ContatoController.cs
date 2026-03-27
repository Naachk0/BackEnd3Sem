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
    public async Task<IActionResult> Post([FromForm] ContatoDTO novoContato)
    {
        // Validação básica baseada no seu exemplo
        if (string.IsNullOrEmpty(novoContato.Nome) || novoContato.IdTipoContato == Guid.Empty)
            return BadRequest("É obrigatório que o contato tenha nome e tipo de usuário");

        Contato contato = new Contato();
        contato.IdContato = Guid.NewGuid();
        contato.Nome = novoContato.Nome;
        contato.FormaContato = novoContato.FormaContato;
        contato.IdTipoContato = novoContato.IdTipoContato;

        if (novoContato.Imagem != null && novoContato.Imagem.Length > 0)
        {
            var extensao = Path.GetExtension(novoContato.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await novoContato.Imagem.CopyToAsync(stream);
            }

            contato.Imagem = nomeArquivo;
        }

        try
        {
            _contatoRepository.Cadastrar(contato);
            return StatusCode(201);
        }
        catch (Exception e)
        {
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
    public async Task<IActionResult> Put(Guid Id, [FromForm] ContatoDTO contato)
    {
        var contatoBuscado = _contatoRepository.listarContatosEspecificos(Id);

        if (contatoBuscado == null)
            return NotFound("Contato não encontrado");

        // Atualização de campos simples
        if (!string.IsNullOrWhiteSpace(contato.Nome))
            contatoBuscado.Nome = contato.Nome;

        if (!string.IsNullOrWhiteSpace(contato.FormaContato))
            contatoBuscado.FormaContato = contato.FormaContato;

        if (contato.IdTipoContato != null && contato.IdTipoContato != Guid.Empty)
            contatoBuscado.IdTipoContato = contato.IdTipoContato;

        // Lógica de imagem (Substituição)
        if (contato.Imagem != null && contato.Imagem.Length != 0)
        {
            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            // Deletar arquivo antigo se existir
            if (!string.IsNullOrEmpty(contatoBuscado.Imagem))
            {
                var caminhoAntigo = Path.Combine(caminhoPasta, contatoBuscado.Imagem);
                if (System.IO.File.Exists(caminhoAntigo))
                    System.IO.File.Delete(caminhoAntigo);
            }

            // Salva a nova imagem
            var extensao = Path.GetExtension(contato.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await contato.Imagem.CopyToAsync(stream);
            }

            contatoBuscado.Imagem = nomeArquivo;
        }

        try
        {
            _contatoRepository.atualizar(Id, contatoBuscado);
            return NoContent();
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
    [HttpGet]
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
    [HttpGet("{Id}")]
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
