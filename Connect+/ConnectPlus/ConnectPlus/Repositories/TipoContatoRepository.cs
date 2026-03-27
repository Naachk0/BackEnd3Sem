using ConnectPlus.BdContextEvent;
using ConnectPlus.Interface;
using ConnectPlus.Models;

namespace ConnectPlus.Repositories;

public class TipoContatoRepository : ITipoContatoRepository
{

    private readonly EventContext _context;

    public TipoContatoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo de cadastrar um tipo de contato
    /// </summary>
    /// <param name="tipoContato">cadastro tipo Contato</param>
    public void Cadastrar(TipoContato tipoContato)
    {
       _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }
    /// <summary>
    /// metodo que atualiza o tipo de contato
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="tipoContato">tipo de conato atualizado</param>
    public void atualizar(Guid Id, TipoContato tipoContato)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(Id);

        if (tipoContatoBuscado != null)
        {
            tipoContatoBuscado.Titulo = tipoContato.Titulo;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// metodo de buscar por id o tipo de contato
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>buscar tipo de usuario</returns>
    public TipoContato BuscarPorId(Guid Id)
    {
        return _context.TipoContatos.Find(Id)!;
    }

    /// <summary>
    /// metodo de deletar um tipo de contato
    /// </summary>
    /// <param name="Id">deletar tipo contato</param>
    public void Deletar(Guid Id)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(Id);


        if (tipoContatoBuscado != null)
        {
            _context.TipoContatos.Remove(tipoContatoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// metodo de listar tipos de contato
    /// </summary>
    /// <returns>lista de tipocontatos</returns>
    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.OrderBy(TipoContato => TipoContato.Titulo).ToList();
    }
}
