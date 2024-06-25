using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Representa um pedido de itens.
    /// </summary>
    public class Pedido
    {
        /// <summary>
        /// Taxa de serviço aplicada ao total do pedido.
        /// </summary>
        private static double TAXA_SERVICO = 0.1;

        /// <summary>
        /// Dicionário que armazena os itens do pedido e suas quantidades.
        /// </summary>
        private Dictionary<Produto, int> Itens { get; set; } = new Dictionary<Produto, int>();

        /// <summary>
        /// Adiciona um item ao pedido.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado.</param>
        /// <param name="quantidade">A quantidade do produto.</param>
        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (Itens.ContainsKey(produto))
            {
                Itens[produto] += quantidade;
            }
            else
            {
                Itens.Add(produto, quantidade);
            }
        }

        /// <summary>
        /// Calcula o valor da taxa de serviço do pedido.
        /// </summary>
        /// <returns>O valor da taxa de serviço.</returns>
        public double CalcularTaxa()
        {
            double subtotal = Itens.Sum(item => item.Key.RetornaPreco() * item.Value);
            double valorTaxa = subtotal * TAXA_SERVICO;
            return valorTaxa;
        }

        /// <summary>
        /// Calcula o valor total do pedido, incluindo a taxa de serviço.
        /// </summary>
        /// <returns>O valor total do pedido.</returns>
        public double CalcularTotal()
        {
            double subtotal = Itens.Sum(item => item.Key.RetornaPreco() * item.Value);
            double valorTaxa = subtotal * TAXA_SERVICO;
            return subtotal + valorTaxa;
        }

        /// <summary>
        /// Calcula o valor total do pedido por pessoa, incluindo a taxa de serviço.
        /// </summary>
        /// <param name="quantidadePessoas">A quantidade de pessoas para dividir o total.</param>
        /// <returns>O valor total do pedido por pessoa.</returns>
        public double CalcularTotalPorPessoa(int quantidadePessoas)
        {
            double totalComTaxa = CalcularTotal();
            return totalComTaxa / quantidadePessoas;
        }

        /// <summary>
        /// Retorna uma string que representa o pedido.
        /// </summary>
        /// <returns>Uma string que representa o pedido.</returns>
        public override string ToString()
        {
            return string.Join("\n", Itens.Select(item => $"{item.Key.RetornaNome()} - Quantidade: {item.Value} - Preço: R$ {item.Key.RetornaPreco():F2}"));
        }
    }

}
