using System;
using System.Collections.Generic;


namespace runcode_poo.codigo
{
    class Program
    {
        public static void Main(string[] args)
        {
            string nome_cliente;
            int numero_pessoas;
            int op;
            Restaurante restaurante = new Restaurante();

            do
            {
                Console.WriteLine("\n\nBEM VINDO AO RESTAURANTE :");
                Console.WriteLine("1) Cadastrar cliente.");
                Console.WriteLine("2) Encerrar requisição e buscar na fila.");
                Console.WriteLine("3) Sair.");

                Console.Write("\nDigite a opção desejada:");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        CadastrarCliente();
                        break;

                    case 2:
                        FinalizarRequisicao();
                        break;


                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (op != 3);
        }

        public void CadastrarCliente()
        {
            Console.WriteLine("Digite o seu nome: ");
            nome_cliente = Console.ReadLine();
            Console.WriteLine("Digite o número de pessoas que estão com você:");
            numero_pessoas = int.Parse(Console.ReadLine());
            restaurante.AtenderCliente(nome_cliente, numero_pessoas);
        }

        public void FinalizarRequisicao()
        {
            Console.Write("Digite o ID da mesa para finalizar a requisição: ");
            int idMesaFinalizar = int.Parse(Console.ReadLine());
            Mesa mesaFinalizar = restaurante.mesas.Find(m => m.idMesa == idMesaFinalizar);
            if (mesaFinalizar != null)
            {
                restaurante.FinalizarMesa(mesaFinalizar);
                Console.WriteLine($"Requisição da mesa {idMesaFinalizar} finalizada.\n");
            }
            else
            {
                Console.WriteLine($"Mesa {idMesaFinalizar} não encontrada.\n");
            }
        }
    }
}