using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Representa uma requisição de café, derivada da classe abstrata <see cref="Requisicao"/>.
    /// </summary>
    public class RequisicaoCafe : Requisicao
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="RequisicaoCafe"/> com o cliente especificado.
        /// </summary>
        /// <param name="cliente">O cliente associado à requisição de café.</param>
        public RequisicaoCafe(Cliente cliente) : base(cliente) { }

        /// <summary>
        /// Adiciona um item ao pedido de café.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado ao pedido.</param>
        /// <param name="quantidade">A quantidade do produto a ser adicionada.</param>
        public override void AdicionarItem(Produto produto, int quantidade)
        {
            this.Pedido.AdicionarItem(produto, quantidade);
        }

        /// <summary>
        /// Retorna uma string que representa a requisição de café.
        /// </summary>
        /// <returns>Uma string contendo as informações do cliente, horários e pedido.</returns>
        public override string ToString()
        {
            return "==============================================\n" +
                   $"Cliente: {this.Cliente.ToString()}\n" +
                   $"Horário de Entrada: {this.HorarioInicio}\n" +
                   $"Horário de Saída: {(this.Encerrada ? this.HorarioSaida.ToString() : "Atendimento em andamento")}\n" +
                   $"Pedido: \n{this.Pedido.ToString()}\n" +
                   "==============================================\n" +
                   $"Taxa %: R$ {this.Pedido.CalcularTaxa()}\n" +
                   $"Total: R$ {this.Pedido.CalcularTotal():F2}\n" +
                   "==============================================\n";
        }
    }
}