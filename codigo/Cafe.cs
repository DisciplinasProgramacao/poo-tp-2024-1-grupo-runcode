using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Representa um café que é um tipo de estabelecimento.
    /// </summary>
    public class Cafe : Estabelecimento
    {
        /// <summary>
        /// Cardápio específico do café.
        /// </summary>
        private CardapioCafe Cardapio = new CardapioCafe();

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Cafe"/>.
        /// Preenche o cardápio do café.
        /// </summary>
        public Cafe()
        {
            this.Cardapio.PreencherCardapio();
        }

        /// <summary>
        /// Atende um cliente no café.
        /// </summary>
        /// <param name="cliente">O cliente a ser atendido.</param>
        public override void AtenderCliente(Cliente cliente)
        {
            RequisicaoCafe requisicao = new RequisicaoCafe(cliente);
            AdicionarItemAoPedido(requisicao);
            EncerrarAtendimento(requisicao);
        }

        /// <summary>
        /// Adiciona itens ao pedido do cliente.
        /// </summary>
        /// <param name="requisicao">A requisição do café.</param>
        private void AdicionarItemAoPedido(RequisicaoCafe requisicao)
        {
            Cliente clienteEmAtendimento = requisicao.RetornarCliente();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("=============== ATENDIMENTO CAFÉ =============");
                Console.WriteLine("==============================================");
                Console.ResetColor();
                Console.WriteLine($"Cliente: {clienteEmAtendimento.RetornaNome()}");
                Console.WriteLine();
                ExibirCardapio();
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------");
                Console.Write("Digite o ID do produto para adicionar ao pedido (ou 0 para finalizar):");
                int idProduto = int.Parse(Console.ReadLine());

                if (idProduto == 0)
                {
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
        /// Encerra o atendimento de uma requisição de café.
        /// </summary>
        /// <param name="requisicao">A requisição do café.</param>
        private void EncerrarAtendimento(RequisicaoCafe requisicao)
        {
            requisicao.EncerrarRequisicao();
            this.HistoricoAtendimento.Add(requisicao);
            Console.WriteLine(requisicao.ToString());
            Console.WriteLine("Atendimento encerrado.");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        /// <summary>
        /// Exibe o cardápio do café.
        /// </summary>
        public override void ExibirCardapio()
        {
            Console.WriteLine("================== CARDÁPIO ==================");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(this.Cardapio.ToString());
        }
    }

}
