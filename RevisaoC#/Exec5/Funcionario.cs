
namespace Exec5
{
    public class Funcionario : Pessoa
    {
        public double salario = 1600;

        
 public void ExibirDados()
        {
           Console.WriteLine($"funcionario {nome} tem {Idade} e salario de{salario}");
  
        }
    }
}