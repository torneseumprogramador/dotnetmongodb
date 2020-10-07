using System;

namespace dotnetmongo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cliente cliente = new Cliente();
            // cliente.Nome = "Danilo";
            // cliente.Sobrenome = "Aparecido";
            // cliente.Salvar();

            // Console.WriteLine("Dados incluidos");

            Cliente cliente = new Cliente();

            Console.WriteLine($"Listando dados - {cliente.Lista().Count}");
        }
    }
}
