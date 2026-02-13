
﻿using Exec8;

Usuario usuario = new Usuario("Aguiar", "senha123");

Administrador administrador = new Administrador("hamilton", "admin44");

Console.WriteLine("Autenticando usuário:");
usuario.Autenticar("senha123");
Console.WriteLine($"");

Console.WriteLine("Autenticando usuário:");
usuario.Autenticar("1999");
Console.WriteLine($"");


Console.WriteLine("Autenticando administrador:");
administrador.Autenticar("admin44");
Console.WriteLine($"");
Console.WriteLine($"");


Console.WriteLine("Autenticando administrador:");
administrador.Autenticar("053024");
