using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IEventoRepository
{
    void Cadastrar( Evento evento);
    void Deletar(Guid guid);

    List<Evento> Listar();

    void atualizar(Guid guid, Presenca presenca);
    Evento BuscarPorId(Guid guid);

    List<Evento> ListarPorId(Guid IdUsuario);
    List<Evento> ListarProximosEventos();
}
