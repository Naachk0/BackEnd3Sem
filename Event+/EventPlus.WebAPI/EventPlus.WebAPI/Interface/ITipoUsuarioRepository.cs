using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface ITipoUsuarioRepository
{
    void Cadastrar(TipoUsuario tipoUsuario);
    void Deletar(Guid guid);

    List<TipoUsuario> Listar();

    TipoUsuario BuscarPorId(Guid guid);

    void atualizar(Guid guid, TipoUsuario tipoUsuario);
}
