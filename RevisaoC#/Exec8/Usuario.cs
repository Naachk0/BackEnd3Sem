

namespace Exec8
{
    public class Usuario
    {
         public string Nome;
        public string Senha;

        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        public void Autenticar(string senha)
        {
            if (Senha == senha)
            {
                Console.WriteLine("Usuário autenticado com sucesso!");
            }
            else
            {
                Console.WriteLine("Senha incorreta. Autenticação falhou.");
            }
    }
    }
}