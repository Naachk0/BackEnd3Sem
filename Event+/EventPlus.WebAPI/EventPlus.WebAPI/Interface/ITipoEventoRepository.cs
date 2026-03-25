using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface ITipoEventoRepository
{
    void Cadastrar(TipoEvento tipoEvento);
    void Deletar(Guid guid);

    List<TipoEvento> Listar();

    TipoEvento BuscarPorId(Guid guid);

    void atualizar(Guid guid, TipoEvento tipoEvento);
}
