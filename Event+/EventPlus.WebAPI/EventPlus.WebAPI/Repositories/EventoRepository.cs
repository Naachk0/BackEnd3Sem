using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{

    private readonly EventContext _context;

    public EventoRepository(EventContext context) 
    {
     _context = context;

    }

    /// <summary>
    /// atualiza o evento
    /// </summary>
    /// <param name="guid"></param>
    /// <param name=""></param>
    /// <param name="evento"></param>
    public void atualizar(Guid Id, Evento evento)
    {
        var EventoBuscados = _context.Eventos.Find(Id);

        if (EventoBuscados != null)
        {
            EventoBuscados.DataEvento = evento.DataEvento;

            _context.SaveChanges();
        }
    }

    public void atualizar(Guid guid, Presenca presenca)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Buscar os eventos pelo Id
    /// </summary>
    /// <param name="Id">Obejtos eventos que contem informacoes do evento</param>
    /// <returns></returns>
    public Evento BuscarPorId(Guid Id)
    {
        return _context.Eventos.Find(Id)!;
    }

    /// <summary>
    /// Cadastrar um evento
    /// </summary>
    /// <param name="evento">um evento proximo a ser cadastrado</param>
    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var EventoBuscado = _context.Eventos.Find(Id);


        if (EventoBuscado != null)
        {
            _context.Eventos.Remove(EventoBuscado);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// lista uma dos eventos cadastrados
    /// </summary>
    /// <returns>lista de eventos</returns>
    public List<Evento> Listar()
    {
     return _context.Eventos.OrderBy(evento => evento.DataEvento)
     .ThenBy(evento => evento.Descricao).ToList();
    }

    /// <summary>
    /// Metodo que lista eventos filtrando pelas presencas do usuario
    /// </summary>
    /// <param name="IdUsuario">id do usuario para a filtragem</param>
    /// <returns>lista de eventos filtrados por usuario</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos.Include(e => e.IdTipoEventoNavigation).Include(e => e.IdInstituicaoNavigation).Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true)).ToList();
    }


    /// <summary>
    /// metodo que busca os proximos eventos que vao acontecer
    /// </summary>
    /// <returns>retorna lista de proximos eventos</returns>
    public List<Evento> ListarProximosEventos()
    {
        return _context.Eventos.Include(e => e.IdTipoEventoNavigation).Include(e => e.IdInstituicaoNavigation).Where(e => e.DataEvento >= DateTime.Now).OrderBy(e => e.DataEvento).ToList();
    }
}
