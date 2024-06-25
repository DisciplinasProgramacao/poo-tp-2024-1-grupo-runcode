using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Classe abstrata que representa um cardápio contendo uma lista de produtos.
    /// </summary>
    public abstract class Cardapio
    {
        /// <summary>
        /// Lista de produtos presentes no cardápio.
        /// </summary>
        protected List<Produto> Produtos { get; set; } = new List<Produto>();

        /// <summary>
        /// Retorna a lista de produtos do cardápio.
        /// </summary>
        /// <returns>Lista de produtos.</returns>
        public List<Produto> RetornaProdutos() => this.Produtos;

        /// <summary>
        /// Retorna uma string que representa todos os produtos no cardápio.
        /// </summary>
        /// <returns>Uma string que descreve todos os produtos no cardápio.</returns>
        public override string ToString() => string.Join("\n", this.Produtos.Select(p => p.ToString()));
    }
}
