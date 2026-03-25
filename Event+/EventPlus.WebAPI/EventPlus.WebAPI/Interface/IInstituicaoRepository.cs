using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IInstituicaoRepository
{
    void Cadastrar(Instituicao instituicao);
    void Deletar(Guid guid);

    List<Instituicao> Listar();

    Instituicao BuscarPorId(Guid guid);

    void atualizar(Guid guid, Instituicao instituicao);
}
