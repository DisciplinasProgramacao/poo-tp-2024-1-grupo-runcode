using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Classe que representa um Produto com ID, Nome e Preço.
    /// </summary>
    public class Produto
    {
        // Propriedades privadas do produto
        private int Id { get; set; }
        private string Nome { get; set; }
        private double Preco { get; set; }

        /// <summary>
        /// Construtor da classe Produto.
        /// </summary>
        /// <param name="id">Identificador único do produto.</param>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="preco">Preço do produto.</param>
        public Produto(int id, string nome, double preco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
        }

        /// <summary>
        /// Retorna o ID do produto.
        /// </summary>
        /// <returns>ID do produto.</returns>
        public int RetornarId() => this.Id;

        /// <summary>
        /// Retorna o nome do produto.
        /// </summary>
        /// <returns>Nome do produto.</returns>
        public string RetornaNome() => this.Nome;

        /// <summary>
        /// Retorna o preço do produto.
        /// </summary>
        /// <returns>Preço do produto.</returns>
        public double RetornaPreco() => this.Preco;

        /// <summary>
        /// Retorna uma string que representa o objeto Produto.
        /// </summary>
        /// <returns>Uma string que descreve o produto.</returns>
        public override string ToString() => $"ID: {this.Id}, Nome: {this.Nome}, Preço: R$ {this.Preco:F2}";
    }

}
