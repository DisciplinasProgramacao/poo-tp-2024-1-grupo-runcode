using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{

    /// <summary>
    /// Representa um estabelecimento abstrato.
    /// </summary>
    public abstract class Estabelecimento
    {
        /// <summary>
        /// Lista de requisições em atendimento.
        /// </summary>
        protected List<Requisicao> ReqAtendimento { get; set; } = new List<Requisicao>();

        /// <summary>
        /// Lista de requisições encerradas.
        /// </summary>
        protected List<Requisicao> HistoricoAtendimento { get; set; } = new List<Requisicao>();

        /// <summary>
        /// Método para atender cliente com um parâmetro.
        /// </summary>
        /// <param name="cliente">O cliente a ser atendido.</param>
        public virtual void AtenderCliente(Cliente cliente)
        {
            throw new NotImplementedException("Este método não foi implementado.");
        }

        /// <summary>
        /// Método virtual para atender cliente com dois parâmetros.
        /// </summary>
        /// <param name="cliente">O cliente a ser atendido.</param>
        /// <param name="quantidadePessoas">A quantidade de pessoas a serem atendidas.</param>
        public virtual void AtenderCliente(Cliente cliente, int quantidadePessoas)
        {
            throw new NotImplementedException("Este método não foi implementado.");
        }

        /// <summary>
        /// Método abstrato para exibir o cardápio do estabelecimento.
        /// </summary>
        public abstract void ExibirCardapio();

        /// <summary>
        /// Retorna a lista de requisições em atendimento.
        /// </summary>
        /// <returns>Lista de requisições em atendimento.</returns>
        public List<Requisicao> RetornaReqAtendimento() => this.ReqAtendimento;

        /// <summary>
        /// Exibe o histórico de atendimentos encerrados.
        /// </summary>
        public void ExibirHistorico()
        {
            var historicoOrdenado = this.HistoricoAtendimento
                .OrderByDescending(r => r.RetornarEncerrada() ? r.RetornarHorarioSaida() : DateTime.MinValue)
                .ToList();

            if (historicoOrdenado.Count > 0)
            {
                Console.WriteLine("============ REQUISIÇÕES ENCERRADAS ==========");
                foreach (var requisicao in historicoOrdenado)
                {
                    Console.WriteLine(requisicao.ToString());
                    Console.WriteLine("--------------------------");
                }
            }
            else
            {
                Console.WriteLine("Sem Atendimentos!");
            }

            Console.WriteLine();
            Console.WriteLine("> Pressione qualquer tecla para voltar <");
            Console.ReadKey();
        }
    }
}
