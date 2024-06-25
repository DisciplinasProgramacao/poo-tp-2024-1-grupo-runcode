using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{

    /// <summary>
    /// Representa uma requisição abstrata que contém informações sobre um cliente, pedido e horários de início e saída.
    /// </summary>
    public abstract class Requisicao
    {
        /// <summary>
        /// Obtém ou define o cliente associado à requisição.
        /// </summary>
        protected Cliente Cliente { get; set; }

        /// <summary>
        /// Obtém ou define o pedido associado à requisição.
        /// </summary>
        protected Pedido Pedido { get; set; } = new Pedido();

        /// <summary>
        /// Obtém ou define o horário de início da requisição.
        /// </summary>
        protected DateTime HorarioInicio { get; set; }

        /// <summary>
        /// Obtém ou define o horário de saída da requisição.
        /// </summary>
        protected DateTime HorarioSaida { get; set; }

        /// <summary>
        /// Obtém ou define um valor indicando se a requisição está encerrada.
        /// </summary>
        protected bool Encerrada { get; set; } = false;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Requisicao"/> com o cliente especificado.
        /// </summary>
        /// <param name="cliente">O cliente associado à requisição.</param>
        public Requisicao(Cliente cliente)
        {
            this.Cliente = cliente;
            this.HorarioInicio = DateTime.Now;
        }

        /// <summary>
        /// Adiciona um item ao pedido associado à requisição.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado.</param>
        /// <param name="quantidade">A quantidade do produto a ser adicionada.</param>
        public abstract void AdicionarItem(Produto produto, int quantidade);

        /// <summary>
        /// Encerra a requisição, definindo o horário de saída como o horário atual.
        /// </summary>
        public void EncerrarRequisicao()
        {
            this.Encerrada = true;
            this.HorarioSaida = DateTime.Now;
        }

        /// <summary>
        /// Retorna uma string com as informações de entrada do cliente.
        /// </summary>
        /// <returns>Uma string contendo as informações do cliente e o horário de entrada.</returns>
        public string EntradaCliente()
        {
            return $"Cliente: {this.Cliente.ToString()}\n" +
                   $"Horário de Entrada: {this.HorarioInicio}";
        }

        /// <summary>
        /// Retorna um valor indicando se a requisição está encerrada.
        /// </summary>
        /// <returns><c>true</c> se a requisição estiver encerrada; caso contrário, <c>false</c>.</returns>
        public bool RetornarEncerrada()
        {
            return this.Encerrada;
        }

        /// <summary>
        /// Retorna o horário de saída da requisição.
        /// </summary>
        /// <returns>O horário de saída da requisição.</returns>
        public DateTime RetornarHorarioSaida()
        {
            return this.HorarioSaida;
        }

        /// <summary>
        /// Retorna o cliente associado à requisição.
        /// </summary>
        /// <returns>O cliente associado à requisição.</returns>
        public Cliente RetornarCliente()
        {
            return this.Cliente;
        }
    }

}
