

namespace Exec4
{
    public class Pessoa
    {
        public string nome;
         public int Idade;


        public Pessoa(string n, int i)
        {
            nome = n;
            Idade = i;
        }
    

 public void ExibirDados()
        {
           Console.WriteLine($"{nome} tem {Idade}");
  
        }
    }

}
