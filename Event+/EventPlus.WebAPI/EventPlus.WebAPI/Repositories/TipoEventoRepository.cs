using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;


public class TipoEventoRepository : ITipoEventoRepository
{

    private readonly EventContext _context;


    public TipoEventoRepository(EventContext context) 
    {
        _context = context;
    }

        /// <summary>
        /// </summary>
        /// <param name="id">id do tipo evento a ser atualizado</param>
        /// <param name="tipoEvento">Novos dados do tipo evento </param>

    public void atualizar(Guid Id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscando = _context.TipoEventos.Find(Id);

        if (tipoEventoBuscando != null)
        {
            tipoEventoBuscando.Titulo = tipoEvento.Titulo;

            _context.SaveChanges();
        }
    }


    /// <summary>
    /// busca um tipo de evento por id
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>Objeto do tipoEvento com as informações do tipo de evento</returns>
    public TipoEvento BuscarPorId(Guid Id)
    {
        return _context.TipoEventos.Find(Id)!;


    }

   /// <summary>
   /// Cadastra um novo tipo de evento
   /// </summary>
   /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
      _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="Id">id do tipo evento a ser deletado</param>
    public void Deletar(Guid Id)
    {
        var TipoEventoBuscado = _context.TipoEventos.Find(Id);


        if (TipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(TipoEventoBuscado);
            _context.SaveChanges();
        }

    }


    /// <summary>
    /// busca a lista do tipo evento cadastrado
    /// </summary>
    /// <returns>uma lista de tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(tipoEevento => tipoEevento.Titulo).ToList();
    }
}
