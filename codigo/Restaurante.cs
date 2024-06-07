
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{

    /// <summary>
    /// Classe Restaurante que gerencia mesas e a fila de espera de clientes.
    /// </summary>
    class Restaurante
    {
        // Fila de espera de clientes
        private Queue<Cliente> filaEspera;

        // Lista de mesas no restaurante
        private List<Mesa> mesas;

        /// <summary>
        /// Construtor da classe Restaurante que inicializa a fila de espera e as mesas.
        /// </summary>
        public Restaurante()
        {
            filaEspera = new Queue<Cliente>();
            mesas = new List<Mesa>();

            // Adiciona mesas de 4 lugares
            for (int i = 1; i <= 4; i++)
            {
                mesas.Add(new Mesa(i, 4));
            }

            // Adiciona mesas de 6 lugares
            for (int i = 5; i <= 8; i++)
            {
                mesas.Add(new Mesa(i, 6));
            }

            // Adiciona mesas de 8 lugares
            for (int i = 9; i <= 10; i++)
            {
                mesas.Add(new Mesa(i, 8));
            }
        }

        /// <summary>
        /// Localiza uma mesa disponível que possa acomodar a quantidade de clientes especificada.
        /// </summary>
        /// <param name="quantidadeClientes">Número de clientes a serem acomodados.</param>
        /// <returns>Mesa disponível ou null se não houver.</returns>
        public Mesa LocalizarMesa(int quantidadeClientes)
        {
            foreach (var mesa in mesas)
            {
                if (mesa.EstaDisponivel && mesa.CapacidadeMesa >= quantidadeClientes)
                {
                    return mesa;
                }
            }
            return null;
        }

        /// <summary>
        /// Atende um cliente, alocando uma mesa ou adicionando à fila de espera.
        /// </summary>
        /// <param name="cliente">Cliente a ser atendido.</param>
        /// <param name="quantidadeClientes">Número de clientes do grupo do cliente.</param>
        /// <returns>Requisição criada ou null se não houver mesa disponível.</returns>
        public Requisicao AtenderCliente(Cliente cliente, int quantidadeClientes)
        {
            Mesa mesa = LocalizarMesa(quantidadeClientes);
            if (mesa != null)
            {
                mesa.EstaDisponivel = false;
                return new Requisicao(cliente, quantidadeClientes) { Mesa = mesa, HoraEntrada = DateTime.Now };
            }
            else
            {
                AdicionarFilaEspera(cliente);
                return null;
            }
        }

        /// <summary>
        /// Adiciona um cliente à fila de espera.
        /// </summary>
        /// <param name="cliente">Cliente a ser adicionado à fila de espera.</param>
        public void AdicionarFilaEspera(Cliente cliente)
        {
            filaEspera.Enqueue(cliente);
        }

        /// <summary>
        /// Aloca uma mesa para uma requisição existente.
        /// </summary>
        /// <param name="requisicao">Requisição que necessita de uma mesa.</param>
        public void AlocarParaMesa(Requisicao requisicao)
        {
            Mesa mesa = LocalizarMesa(requisicao.QuantidadeClientes);
            if (mesa != null)
            {
                mesa.EstaDisponivel = false;
                requisicao.Mesa = mesa;
                requisicao.HoraEntrada = DateTime.Now;
            }
        }

        /// <summary>
        /// Finaliza o uso de uma mesa, tornando-a disponível novamente.
        /// </summary>
        /// <param name="mesa">Mesa a ser finalizada.</param>
        public void FinalizarMesa(Mesa mesa)
        {
            mesa.EstaDisponivel = true;
        }

        /// <summary>
        /// Encerra uma requisição, marca a mesa como disponível e atende o próximo cliente na fila de espera.
        /// </summary>
        /// <param name="requisicao">Requisição a ser encerrada.</param>
        public void EncerrarRequisicao(Requisicao requisicao)
        {
            requisicao.EncerrarRequisicao();
            FinalizarMesa(requisicao.Mesa);

            if (filaEspera.Count > 0)
            {
                Cliente clienteNaFila = filaEspera.Dequeue();
                int quantidadeClientes = requisicao.QuantidadeClientes; // Supondo que a quantidade de clientes é a mesma
                Requisicao novaRequisicao = AtenderCliente(clienteNaFila, quantidadeClientes);
                if (novaRequisicao == null)
                {
                    filaEspera.Enqueue(clienteNaFila); // Reenfileira se não conseguiu alocar
                }
            }
        }
    }
}