using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IPresencaRepository
{
    void Inscrever(Presenca presenca);
    void Deletar(Guid guid);

    List<Presenca> Listar();

    Presenca BuscarPorId(Guid guid);

    void atualizar(Guid guid, Presenca presenca);
    List<Presenca> ListarMinhas (Guid IdUSuario);
}
