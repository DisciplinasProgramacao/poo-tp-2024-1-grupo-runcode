using System;
using System.Collections.Generic;


namespace runcode_poo.codigo
{
    class Program
    {
        static void Main()
        {
            // Crie uma lista para armazenar as requisições
              List<Requisicao> listaRequisicoes = new List<Requisicao>();

            Produto p1 = new Produto("castanha", "boa", 18.0, "grãos");

            Cardapio c1 = new Cardapio();
            c1.AdicionarProduto(p1);

            // Exemplo de criação de uma requisição
            Cliente cliente1 = new Cliente("João");
            Requisicao req1 = new Requisicao(cliente1, 4);

            // Adicione a requisição à lista
            listaRequisicoes.Add(req1);

            // Exemplo de outra requisição
            Cliente cliente2 = new Cliente("Maria");
            Requisicao req2 = new Requisicao(cliente2, 2);
            listaRequisicoes.Add(req2);

            // Exemplo de uso posterior das requisições
            foreach (var req in listaRequisicoes)
            {
                Console.WriteLine($"Cliente {req.ToString()}");
                // Faça outras operações com os dados da requisição
            }

            Console.ReadKey();
        }
    }
}