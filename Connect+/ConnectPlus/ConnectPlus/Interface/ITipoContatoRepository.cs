using ConnectPlus.Models;

namespace ConnectPlus.Interface;

public interface ITipoContatoRepository
{
    void Cadastrar(TipoContato tipoContato);
    void Deletar(Guid guid);

    List<TipoContato> Listar();

    TipoContato BuscarPorId(Guid guid);

    void atualizar(Guid guid, TipoContato tipoContato);
}
