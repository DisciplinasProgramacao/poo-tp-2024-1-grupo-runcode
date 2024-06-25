using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{

    /// <summary>
    /// Representa um restaurante, que é um tipo de estabelecimento.
    /// </summary>
    public class Restaurante : Estabelecimento
    {
        /// <summary>
        /// Lista de mesas no restaurante.
        /// </summary>
        private List<Mesa> Mesas { get; set; } = new List<Mesa>();

        /// <summary>
        /// Lista de requisições de clientes na fila de espera.
        /// </summary>
        private List<RequisicaoRestaurante> FilaEspera { get; set; } = new List<RequisicaoRestaurante>();

        /// <summary>
        /// O cardápio do restaurante.
        /// </summary>
        private CardapioRestaurante Cardapio = new CardapioRestaurante();

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Restaurante"/>.
        /// </summary>
        public Restaurante()
        {
            for (int i = 0; i < 4; i++)
            {
                this.Mesas.Add(new Mesa(i + 1, 4));
            }
            for (int i = 4; i < 8; i++)
            {
                this.Mesas.Add(new Mesa(i + 1, 6));
            }
            for (int i = 8; i < 10; i++)
            {
                this.Mesas.Add(new Mesa(i + 1, 8));
            }

            this.Cardapio.PreencherCardapio();
        }

        /// <summary>
        /// Localiza uma mesa disponível que atenda a requisição do restaurante.
        /// </summary>
        /// <param name="requisicao">A requisição do restaurante.</param>
        /// <returns>A mesa disponível ou null se não houver mesas disponíveis.</returns>
        private Mesa LocalizarMesa(RequisicaoRestaurante requisicao)
        {
            foreach (Mesa mesa in this.Mesas)
            {
                if (mesa.VerificarDisponibilidade() && mesa.RetornaCapacidade() >= requisicao.RetornaQtdPessoas())
                {
                    return mesa;
                }
            }
            return null;
        }

        /// <summary>
        /// Localiza a requisição do restaurante associada a uma mesa específica.
        /// </summary>
        /// <param name="idMesa">O ID da mesa.</param>
        /// <returns>A requisição do restaurante associada à mesa.</returns>
        public RequisicaoRestaurante LocalizarRequisicaoPorMesa(int idMesa)
        {
            return this.ReqAtendimento.FirstOrDefault(r => r is RequisicaoRestaurante && ((RequisicaoRestaurante)r).RetornaIdMesa() == idMesa) as RequisicaoRestaurante;
        }

        /// <summary>
        /// Exibe as mesas que estão em atendimento.
        /// </summary>
        /// <returns>True se houver mesas em atendimento, caso contrário, false.</returns>
        public bool VisualizarMesas()
        {
            Console.WriteLine("============ MESAS EM ATENDIMENTO ============");
            Console.WriteLine("==============================================");
            bool temMesasEmAtendimento = false;

            if (this.Mesas.Count > 0)
            {
                foreach (Mesa mesa in this.Mesas)
                {
                    int idMesa = mesa.RetornaIdMesa();
                    bool disponibilidade = mesa.VerificarDisponibilidade();

                    if (!disponibilidade)
                    {
                        temMesasEmAtendimento = true;
                        Console.Write($"Mesa {idMesa} - ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Em andamento");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                }
            }

            if (!temMesasEmAtendimento)
            {
                Console.WriteLine("Sem mesas para atendimento!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return false;
            }

            Console.WriteLine("==============================================");
            Console.WriteLine();
            return true;
        }

        /// <summary>
        /// Exibe as mesas e a fila de espera do restaurante.
        /// </summary>
        public void VisualizarRestaurante()
        {
            Console.WriteLine("=================== MESAS ====================");
            Console.WriteLine("==============================================");
            foreach (Mesa mesa in this.Mesas)
            {
                int idMesa = mesa.RetornaIdMesa();
                int capacidade = mesa.RetornaCapacidade();
                bool disponibilidade = mesa.VerificarDisponibilidade();

                Console.Write($"Mesa {idMesa} - Capacidade: {capacidade} - ");

                if (disponibilidade)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Disponível");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ocupado");
                }

                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine("Fila de Espera:");
            if (this.FilaEspera.Count > 0)
            {
                foreach (RequisicaoRestaurante requisicao in this.FilaEspera)
                {
                    string clienteEmEspera = requisicao.EntradaCliente();
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"{clienteEmEspera}");
                    Console.WriteLine($"Quantidade de Pessoas: {requisicao.RetornaQtdPessoas()}");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Sem clientes na fila de espera!");
            }

            Console.WriteLine();
            Console.WriteLine("> Pressione qualquer tecla para voltar <");
            Console.ReadKey();
        }

        /// <summary>
        /// Atende um cliente específico.
        /// </summary>
        /// <param name="cliente">O cliente a ser atendido.</param>
        public override void AtenderCliente(Cliente cliente)
        {
            int quantidadePessoas;
            do
            {
                Console.Write("Quantidade de pessoas para a mesa: ");
                quantidadePessoas = int.Parse(Console.ReadLine());
                if (quantidadePessoas > 8)
                {
                    Console.WriteLine($"Não existem mesas com capacidade para {quantidadePessoas} pessoas. Por favor, insira um valor até 8.");
                }
            } while (quantidadePessoas > 8);



            RequisicaoRestaurante requisicao = new RequisicaoRestaurante(cliente, quantidadePessoas);
            Mesa mesa = LocalizarMesa(requisicao);

            if (mesa != null)
            {
                AlocarParaMesa(requisicao, mesa);
                GerenciarAtendimento(requisicao);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não há mesas disponíveis no momento. Adicionado à fila de espera.");
                Console.ResetColor();
                Console.ReadKey();
                FilaEspera.Add(requisicao);
            }
        }

        /// <summary>
        /// Gerencia o atendimento de uma requisição de restaurante.
        /// </summary>
        /// <param name="requisicao">A requisição do restaurante.</param>
        public void GerenciarAtendimento(RequisicaoRestaurante requisicao)
        {
            Cliente clienteEmAtendimento = requisicao.RetornarCliente();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("=========== ATENDIMENTO RESTAURANTE ==========");
                Console.WriteLine("==============================================");
                Console.ResetColor();
                Console.WriteLine($"Cliente: {clienteEmAtendimento.RetornaNome()} || Mesa: {requisicao.RetornaIdMesa()}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1. Adicionar item ao pedido");
                Console.WriteLine("2. Encerrar atendimento");
                Console.WriteLine("3. Voltar");
                Console.WriteLine("==============================================");
                Console.Write("> ");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        AdicionarItemAoPedido(requisicao);
                        break;
                    case 2:
                        EncerrarAtendimento(requisicao);
                        return;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        /// <summary>
        /// Aloca uma mesa para a requisição do restaurante.
        /// </summary>
        /// <param name="requisicao">A requisição do restaurante.</param>
        /// <param name="mesa">A mesa a ser alocada.</param>
        private void AlocarParaMesa(RequisicaoRestaurante requisicao, Mesa mesa)
        {
            mesa.OcuparMesa();
            requisicao.AdicionarMesa(mesa.RetornaIdMesa());
            this.ReqAtendimento.Add(requisicao);
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine($"Mesa {mesa.RetornaIdMesa()} alocada para \n" + $"{requisicao.EntradaCliente()}");
            Console.WriteLine("==============================================");
            Console.WriteLine();
        }

        /// <summary>
        /// Adiciona um item ao pedido do cliente.
        /// </summary>
        /// <param name="requisicao">A requisição do restaurante.</param>
        private void AdicionarItemAoPedido(RequisicaoRestaurante requisicao)
        {
            while (true)
            {
                ExibirCardapio();
                Console.WriteLine();
                Console.Write("Digite o ID do produto para adicionar ao pedido (ou 0 para finalizar): ");
                int idProduto = int.Parse(Console.ReadLine());

                if (idProduto == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Finalizando adição de itens ao pedido.");
                    break;
                }

                Produto produto = this.Cardapio.RetornaProdutos().FirstOrDefault(p => p.RetornarId() == idProduto);

                if (produto != null)
                {
                    Console.Write("Digite a quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    requisicao.AdicionarItem(produto, quantidade);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{quantidade} {produto.RetornaNome()} adicionado ao pedido!");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
        }

        /// <summary>
        /// Encerra o atendimento de uma requisição de restaurante.
        /// </summary>
        /// <param name="requisicao">A requisição do restaurante.</param>
        private void EncerrarAtendimento(RequisicaoRestaurante requisicao)
        {
            requisicao.EncerrarRequisicao();
            Mesa mesa = this.Mesas.FirstOrDefault(m => m.RetornaIdMesa() == requisicao.RetornaIdMesa());
            if (mesa != null)
            {
                mesa.LiberarMesa();
            }
            this.ReqAtendimento.Remove(requisicao);
            this.HistoricoAtendimento.Add(requisicao);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Atendimento encerrado.");
            Console.ResetColor();
            Console.WriteLine(requisicao.ToString());
            Console.WriteLine(" > Clique em qualquer tecla para voltar..");
            Console.ReadKey();

            if (this.FilaEspera.Count > 0)
            {
                for (int i = 0; i < this.FilaEspera.Count; i++)
                {
                    RequisicaoRestaurante novaRequisicao = this.FilaEspera[i];
                    Mesa novaMesa = LocalizarMesa(novaRequisicao);
                    if (novaMesa != null)
                    {
                        AlocarParaMesa(novaRequisicao, novaMesa);
                        this.FilaEspera.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Exibe o cardápio do restaurante.
        /// </summary>
        public override void ExibirCardapio()
        {
            Console.WriteLine("================== CARDÁPIO ==================");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(this.Cardapio.ToString());
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
        }
    }
}