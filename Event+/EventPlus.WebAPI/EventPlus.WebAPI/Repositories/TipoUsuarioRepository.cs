using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{

    private readonly EventContext _context;

    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }



    /// <summary>

    /// </summary>
    /// <param name="Id">id do tipoUsuario a ser atualizado</param>
    /// <param name="tipoUsuario">Adiciona novos dados do TIpoUSuario</param>
    public void atualizar(Guid Id, TipoUsuario tipoUsuario)
    {
        var tipoUsuarioBuscando = _context.TipoUsuarios.Find(Id);

        if (tipoUsuarioBuscando != null)
        {
            tipoUsuarioBuscando.Titulo = tipoUsuario.Titulo;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um Usuario Pelo Id dele
    /// </summary>
    /// <param name="Id">Objeto do tipo Usuario com as informacoes dele</param>
    /// <returns></returns>
    public TipoUsuario BuscarPorId(Guid Id)
    {
        return _context.TipoUsuarios.Find(Id)!;
    }

    /// <summary>
    /// cadastra um novo tipousuario
    /// </summary>
    /// <param name="tipoUsuario">tipoUsuario a ser cadastrado</param>
    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }


    /// <summary>
    /// Deleta um tipo de Usuario
    /// </summary>
    /// <param name="Id">id do tipoUsuario a ser deletado</param>
    public void Deletar(Guid Id)
    {
        var TipoUsuarioBuscado = _context.TipoUsuarios.Find(Id);


        if (TipoUsuarioBuscado != null)
        {
            _context.TipoUsuarios.Remove(TipoUsuarioBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca lista de tipoUsuario cadastrados
    /// </summary>
    /// <returns>lista de tipoUsuario</returns>
    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.OrderBy(tipoUsuario => tipoUsuario.Titulo).ToList(); ;
    }
}
