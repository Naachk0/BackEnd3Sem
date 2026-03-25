using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _context;

    public PresencaRepository(EventContext context)
    {
        _context = context;

    }

    /// <summary>
    /// metodo que alterna a situacao da presenca
    /// </summary>
    /// <param name="Id">id da presenca a ser alterado</param>
    public void atualizar(Guid Id, Presenca presenca)
    {
        var presencaBuscada = _context.Presencas.Find(Id);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();

        }
    }

 /// <summary>
 /// metodo que busca pelo id
 /// </summary>
 /// <param name="Id">id a ser buscada</param>
 /// <returns>presenca buscada</returns>
    public Presenca BuscarPorId(Guid Id)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e!.IdInstituicaoNavigation).FirstOrDefault(p => p.IdPresenca == Id)!;
    }

    /// <summary>
    /// Deleta as presencas
    /// </summary>
    /// <param name="Id">Deleta os ids de presenca</param>
    public void Deletar(Guid Id)
    {
        var PresencaBuscada = _context.Presencas.Find(Id);


        if (PresencaBuscada != null)
        {
            _context.Presencas.Remove(PresencaBuscada);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Inscreve as presencas 
    /// </summary>
    /// <param name="presenca">presencas cadastradas</param>
    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    /// <summary>
    /// metodo que Lista as presencas confirmadas
    /// </summary>
    /// <returns>lista de presenca</returns>
    public List<Presenca> Listar()
    {
        return _context.Presencas.OrderBy(Presenca => Presenca.IdUsuario).ToList();
    }

    /// <summary>
    /// Metodo que lista as presencas de um usuario especifico
    /// </summary>
    /// <param name="IdUSuario">Id do Usuario para filtragem</param>
    /// <returns>Lista de presenca de um usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUSuario)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e!.IdInstituicaoNavigation).Where(p => p.IdUsuario == IdUSuario).ToList();
       
    }
}
