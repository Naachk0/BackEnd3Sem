

namespace Exec3
{
    public class Pessoa
    {
        public string nome;
         public int Idade;


 public void ExibirDados()
        {
            if (Idade >= 0)
            {
           Console.WriteLine($"{nome} tem {Idade}");
  
                
                return;

            }
            else
            {
                Console.WriteLine($"Não é possível cadastrar idade.");
            }
        }
    }

}
