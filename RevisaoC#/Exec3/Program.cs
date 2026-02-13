using Exec3;

Pessoa SH = new Pessoa();

string nome = SH.nome;
int idade = SH.Idade;

Console.WriteLine("Qual o seu nome?");
SH.nome = (Console.ReadLine());

Console.WriteLine("Qual a sua idade?");
SH.Idade = int.Parse(Console.ReadLine());

SH.ExibirDados();
