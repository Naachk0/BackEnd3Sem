using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioRepository : IComentarioEventoRepository
{
    private readonly EventContext _context;

    public ComentarioRepository(EventContext context)
    {
        _context = context;

    }
    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        {
            
            var usuarioIdBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(evento => evento.IdUsuario == IdEvento);

            }

            return null;
        }

    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }

    public void Deletar(Guid IdComentarioEvento)
    {
        var ComentarioBuscado = _context.ComentarioEventos.Find(IdComentarioEvento);


        if (ComentarioBuscado != null)
        {
            _context.ComentarioEventos.Remove(ComentarioBuscado);
            _context.SaveChanges();
        }
    }

    public List<ComentarioEvento> List(Guid IdEvento)
    {
        return _context.ComentarioEventos.OrderBy(IdEvento => IdEvento.DataComentario)
      .ThenBy(IdEvento => IdEvento.Descricao).ToList();
    }

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _context.ComentarioEventos.Where(c => c.Exibe == true && c.IdEvento == IdEvento).ToList();
    }
}
