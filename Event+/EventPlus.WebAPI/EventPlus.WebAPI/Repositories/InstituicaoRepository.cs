using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{

    private readonly EventContext _context;

    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// atualiza a instituicao
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="instituicao"></param>
    public void atualizar(Guid Id, Instituicao instituicao)
    {
        var InstituicaoBuscada = _context.Instituicaos.Find(Id);

        if (InstituicaoBuscada != null)
        {
            InstituicaoBuscada.Cnpj = instituicao.Cnpj;
            InstituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Buscar as instituicoes pelo Id
    /// </summary>
    /// <param name="Id">Obejtos instituicoes que contem informacoes da instituicao</param>
    /// <returns></returns>
    public Instituicao BuscarPorId(Guid Id)
    {
        return _context.Instituicaos.Find(Id)!;
    }

    /// <summary>
    /// Cadastrar uma instituicao
    /// </summary>
    /// <param name="instituicao">uma insituicao a ser cadastrada</param>
    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }

    /// <summary>
    /// deleta uma das instituicoes
    /// </summary>
    /// <param name="Id">id da instituicao a ser deletada</param>
    public void Deletar(Guid Id)
    {
        var InstituicaoBuscada = _context.Instituicaos.Find(Id);


        if (InstituicaoBuscada != null)
        {
            _context.Instituicaos.Remove(InstituicaoBuscada);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// lista uma das instituicoes cadastradas
    /// </summary>
    /// <returns>lista de instituicoes</returns>
    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(Instituicao => Instituicao.Cnpj).ToList();
    

    }
}
