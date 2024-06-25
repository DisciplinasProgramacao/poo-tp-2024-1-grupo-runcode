using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Representa um cliente com ID e nome.
    /// </summary>
    public class Cliente
    {
        private int Id { get; set; }
        private string Nome { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Cliente"/> com o id e nome especificados.
        /// </summary>
        /// <param name="id">O identificador do cliente.</param>
        /// <param name="nome">O nome do cliente.</param>
        public Cliente(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        /// <summary>
        /// Retorna o nome do cliente.
        /// </summary>
        /// <returns>O nome do cliente.</returns>
        public string RetornaNome() => this.Nome;

        /// <summary>
        /// Retorna uma string que representa o cliente.
        /// </summary>
        /// <returns>Uma string que representa o cliente.</returns>
        public override string ToString() => $"ID: {this.Id}, Nome: {this.Nome}";
    }
}
