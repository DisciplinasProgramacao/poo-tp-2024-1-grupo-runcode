using System;
using System.Collections.Generic;
using System.Linq;

namespace Teste_poo
{

    class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            Cafe cafe = new Cafe();
            int clienteId = 1;

            while (true)
            {
                Console.Clear();
                RenderLogo();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1. Restaurante");
                Console.WriteLine("2. Café");
                Console.WriteLine("3. Sair");
                Console.WriteLine("==============================================");
                Console.Write("> ");

                try
                {
                    int escolha = int.Parse(Console.ReadLine());

                    switch (escolha)
                    {
                        case (int)OpcaoGeral.Restaurante:
                            bool sairMenuRestaurante = false;
                            while (!sairMenuRestaurante)
                            {
                                Console.Clear();
                                Console.WriteLine("==============================================");
                                Console.WriteLine("================= RESTAURANTE ================");
                                Console.WriteLine("==============================================");
                                Console.WriteLine();
                                Console.WriteLine("Escolha uma opção:");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("1. Atender cliente");
                                Console.WriteLine("2. Atender Mesa");
                                Console.WriteLine("3. Visualizar Restaurante");
                                Console.WriteLine("4. Histórico de Requisições Encerradas");
                                Console.WriteLine("5. Voltar");
                                Console.WriteLine("==============================================");
                                Console.Write("> ");
                                int opcaoRestaurante = int.Parse(Console.ReadLine());

                                switch (opcaoRestaurante)
                                {
                                    case (int)OpcaoMenuRestaurante.AtenderCliente:
                                        Console.Write("Digite o nome do cliente: ");
                                        string nomeCliente = Console.ReadLine();
                                        Cliente novoCliente = new Cliente(clienteId++, nomeCliente);
                                        try
                                        {
                                            restaurante.AtenderCliente(novoCliente);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Erro ao atender cliente: {ex.Message}");
                                        }
                                        break;
                                    case (int)OpcaoMenuRestaurante.AtenderMesa:
                                        bool temMesas = restaurante.VisualizarMesas();
                                        if (temMesas)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Digite o ID da mesa para atendimento:");
                                                int idMesa = int.Parse(Console.ReadLine());
                                                RequisicaoRestaurante requisicao = restaurante.LocalizarRequisicaoPorMesa(idMesa);
                                                if (requisicao != null)
                                                {
                                                    restaurante.GerenciarAtendimento(requisicao);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Mesa não encontrada ou não possui atendimento em andamento.");
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Por favor, digite um número válido para o ID da mesa.");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                                            }
                                        }
                                        break;

                                    case (int)OpcaoMenuRestaurante.VisualizarRestaurante:
                                        restaurante.VisualizarRestaurante();
                                        break;
                                    case (int)OpcaoMenuRestaurante.HistoricoRequisicoes:
                                        restaurante.ExibirHistorico();
                                        break;
                                    case (int)OpcaoMenuRestaurante.Voltar:
                                        sairMenuRestaurante = true;
                                        break;
                                    default:
                                        Console.WriteLine("Opção inválida.");
                                        break;
                                }
                            }
                            break;
                        case (int)OpcaoGeral.Cafe:
                            bool sairMenuCafe = false;
                            while (!sairMenuCafe)
                            {
                                Console.Clear();
                                Console.WriteLine("==============================================");
                                Console.WriteLine("==================== CAFÉ ====================");
                                Console.WriteLine("==============================================");
                                Console.WriteLine("Escolha uma opção:");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("1. Atender Cliente");
                                Console.WriteLine("2. Histórico de Atendimentos");
                                Console.WriteLine("3. Voltar");
                                Console.WriteLine("==============================================");
                                Console.Write("> ");

                                int opcaoCafe = int.Parse(Console.ReadLine());

                                switch (opcaoCafe)
                                {
                                    case (int)OpcaoMenuCafe.AtenderCliente:
                                        Console.Write("Digite o nome do cliente:");
                                        string nomeClienteCafe = Console.ReadLine();
                                        Cliente novoClienteCafe = new Cliente(clienteId++, nomeClienteCafe);
                                        try
                                        {
                                            cafe.AtenderCliente(novoClienteCafe);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Erro ao atender cliente: {ex.Message}");
                                        }
                                        break;
                                    case (int)OpcaoMenuCafe.ExibirHistorico:
                                        cafe.ExibirHistorico();
                                        break;
                                    case (int)OpcaoMenuCafe.Voltar:
                                        sairMenuCafe = true;
                                        break;
                                    default:
                                        Console.WriteLine("Opção inválida.");
                                        break;
                                }
                            }
                            break;
                        case (int)OpcaoGeral.Sair:
                            return;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, digite um número válido para a opção.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }

        public static void RenderLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
   ____   ____     _____ ____  __  __ _____ _____           _____  __      ________ _____          _   _           _____ 
  / __ \ / __ \   / ____/ __ \|  \/  |_   _|  __ \   /\    / ____| \ \    / /  ____/ ____|   /\   | \ | |   /\    / ____|
 | |  | | |  | | | |   | |  | | \  / | | | | |  | | /  \  | (___    \ \  / /| |__ | |  __   /  \  |  \| |  /  \  | (___  
 | |  | | |  | | | |   | |  | | |\/| | | | | |  | |/ /\ \  \___ \    \ \/ / |  __|| | |_ | / /\ \ | . ` | / /\ \  \___ \ 
 | |__| | |__| | | |___| |__| | |  | |_| |_| |__| / ____ \ ____) |    \  /  | |___| |__| |/ ____ \| |\  |/ ____ \ ____) |
  \____/ \____/   \_____\____/|_|  |_|_____|_____/_/    \_\_____/      \/   |______\_____/_/    \_\_| \_/_/    \_\_____/                                                                                                                                                                                                                                               
");
            Console.WriteLine("==========================================================================================================================");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("==========================================================================================================================");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}