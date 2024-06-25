using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Representa uma requisição de restaurante, derivada da classe abstrata <see cref="Requisicao"/>.
    /// </summary>
    public class RequisicaoRestaurante : Requisicao
    {
        /// <summary>
        /// Obtém ou define a quantidade de pessoas na requisição de restaurante.
        /// </summary>
        private int QuantidadePessoas { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da mesa associada à requisição de restaurante.
        /// </summary>
        private int IdMesa { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="RequisicaoRestaurante"/> com o cliente e a quantidade de pessoas especificados.
        /// </summary>
        /// <param name="cliente">O cliente associado à requisição de restaurante.</param>
        /// <param name="quantidadePessoas">A quantidade de pessoas associadas à requisição de restaurante.</param>
        public RequisicaoRestaurante(Cliente cliente, int quantidadePessoas) : base(cliente)
        {
            this.QuantidadePessoas = quantidadePessoas;
        }

        /// <summary>
        /// Adiciona uma mesa à requisição de restaurante.
        /// </summary>
        /// <param name="idMesa">O identificador da mesa a ser adicionada.</param>
        public void AdicionarMesa(int idMesa)
        {
            this.IdMesa = idMesa;
        }

        /// <summary>
        /// Adiciona um item ao pedido de restaurante.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado ao pedido.</param>
        /// <param name="quantidade">A quantidade do produto a ser adicionada.</param>
        public override void AdicionarItem(Produto produto, int quantidade)
        {
            this.Pedido.AdicionarItem(produto, quantidade);
        }

        /// <summary>
        /// Retorna o identificador da mesa associada à requisição de restaurante.
        /// </summary>
        /// <returns>O identificador da mesa.</returns>
        public int RetornaIdMesa() => this.IdMesa;

        /// <summary>
        /// Retorna a quantidade de pessoas associadas à requisição de restaurante.
        /// </summary>
        /// <returns>A quantidade de pessoas.</returns>
        public int RetornaQtdPessoas() => this.QuantidadePessoas;

        /// <summary>
        /// Retorna uma string que representa a requisição de restaurante.
        /// </summary>
        /// <returns>Uma string contendo as informações do cliente, horários, mesa e pedido.</returns>
        public override string ToString()
        {
            return "==============================================\n" +
                   $"Cliente: {this.Cliente.ToString()}\n" +
                   $"Horário de Entrada: {this.HorarioInicio}\n" +
                   $"Horário de Saída: {(this.Encerrada ? this.HorarioSaida.ToString() : "Atendimento em andamento")}\n" +
                   $"Mesa: {this.IdMesa}\n" +
                   $"Pedido: \n{this.Pedido.ToString()}\n" +
                   "==============================================\n" +
                   $"Taxa %: R$ {this.Pedido.CalcularTaxa()}\n" +
                   $"Total: R$ {this.Pedido.CalcularTotal():F2}\n" +
                   $"Total por pessoa: R$ {this.Pedido.CalcularTotalPorPessoa(this.QuantidadePessoas):F2}\n" +
                   "==============================================\n";
        }
    }
}