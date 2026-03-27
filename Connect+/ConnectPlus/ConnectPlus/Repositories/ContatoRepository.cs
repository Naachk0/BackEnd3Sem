using ConnectPlus.BdContextEvent;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Repositories;

public class ContatoRepository : IContatoRepository
{

    private readonly EventContext _context;

    public ContatoRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// metodo de cadastrar um contato
    /// </summary>
    /// <param name="contato">cadastro de contato</param>
    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    /// <summary>
    /// metodo que atualiza a forma de contato 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="contato">atualizacao das formas de contatos</param>
    public void atualizar(Guid Id, Contato contato)
    {
        var ContatoBuscado = _context.Contatos.Find(Id);

        if (ContatoBuscado != null)
        {
            ContatoBuscado.FormaContato = contato.FormaContato;

            _context.SaveChanges();
        }
    }


    /// <summary>
    /// metodo de deletar contatos cadastrados
    /// </summary>
    /// <param name="contato">deleta contatos</param>
    public void Deletar(Guid Id)
    {
        var ContatoBuscado = _context.Contatos.Find(Id);


        if (ContatoBuscado != null)
        {
            _context.Contatos.Remove(ContatoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// lista de contatos gerais
    /// </summary>
    /// <returns></returns>
    public List<Contato> Listar()
    {
        return _context.Contatos.OrderBy(Contato => Contato.Nome).ToList();
    }

   
    /// <summary>
    /// lista de contatos especificos
    /// </summary>
    /// <param name="Id">id dos contatos especificos a serem listados</param>
    /// <returns></returns>
    public Contato listarContatosEspecificos(Guid Id)
    {
        return _context.Contatos.Find(Id)!;
    }
}

