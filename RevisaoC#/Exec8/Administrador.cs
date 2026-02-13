

namespace Exec8
{
    public class Administrador
    {
               public string Nome;
        public string Senha;

        public Administrador(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        public void Autenticar(string senha)
        {
            if (Senha == senha)
            {
                Console.WriteLine("Administrador autenticado com sucesso!");
            }
            else
            {
                Console.WriteLine("Senha incorreta. Autenticação falhou.");
            }
        }
    }
}