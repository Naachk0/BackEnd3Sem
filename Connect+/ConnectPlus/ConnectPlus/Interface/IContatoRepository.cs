
using ConnectPlus.Models;

namespace ConnectPlus.Interface;

public interface IContatoRepository
{
    void Cadastrar(Contato contato);
    void Deletar(Guid Id);

    List<Contato> Listar();

    void atualizar(Guid guid, Contato contato);

    public Contato listarContatosEspecificos(Guid Id);

}
