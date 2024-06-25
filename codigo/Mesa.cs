using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Representa uma mesa com ID, capacidade e disponibilidade.
    /// </summary>
    public class Mesa
    {
        private int Id { get; set; }
        private int Capacidade { get; set; }
        private bool Disponivel { get; set; } = true;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Mesa"/> com o id e capacidade especificados.
        /// </summary>
        /// <param name="id">O identificador da mesa.</param>
        /// <param name="capacidade">A capacidade da mesa.</param>
        public Mesa(int id, int capacidade)
        {
            this.Id = id;
            this.Capacidade = capacidade;
        }

        /// <summary>
        /// Retorna o identificador da mesa.
        /// </summary>
        /// <returns>O identificador da mesa.</returns>
        public int RetornaIdMesa() => this.Id;

        /// <summary>
        /// Retorna a capacidade da mesa.
        /// </summary>
        /// <returns>A capacidade da mesa.</returns>
        public int RetornaCapacidade() => this.Capacidade;

        /// <summary>
        /// Verifica se a mesa está disponível.
        /// </summary>
        /// <returns>True se a mesa está disponível; caso contrário, false.</returns>
        public bool VerificarDisponibilidade() => this.Disponivel;

        /// <summary>
        /// Marca a mesa como ocupada.
        /// </summary>
        public void OcuparMesa() => this.Disponivel = false;

        /// <summary>
        /// Marca a mesa como disponível.
        /// </summary>
        public void LiberarMesa() => this.Disponivel = true;
    }
}
