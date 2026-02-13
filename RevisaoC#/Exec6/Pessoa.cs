

namespace Exec6
{
    public class Pessoa
    {
        
         public string nome {get; set;}

         public string Sobrenome;
         public int Idade;

             public Pessoa(string Nome, int idade)
    {
       Idade = idade;
        // Sobrenome = sobrenome;
        nome = Nome;
    }

       public void Apresentar()
    {
        Console.WriteLine($"meu nome é {nome}");
    }
    
    public void Apresentar(string sobrenome)
    {
   
           Console.WriteLine($" {nome} {sobrenome} tem {Idade}");
  
    }

   
    }
}