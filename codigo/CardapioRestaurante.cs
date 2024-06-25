using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Classe que representa um cardápio de restaurante, herdando a classe Cardapio.
    /// </summary>
    public class CardapioRestaurante : Cardapio
    {
        /// <summary>
        /// Preenche o cardápio do restaurante com uma lista predefinida de produtos.
        /// </summary>
        public void PreencherCardapio()
        {
            this.Produtos.Add(new Produto(1, "Moqueca de Palmito", 32.00));
            this.Produtos.Add(new Produto(2, "Falafel Assado", 20.00));
            this.Produtos.Add(new Produto(3, "Salada Primavera com Macarrão Konjac", 25.00));
            this.Produtos.Add(new Produto(4, "Escondidinho de Inhame", 18.00));
            this.Produtos.Add(new Produto(5, "Strogonoff de Cogumelos", 35.00));
            this.Produtos.Add(new Produto(6, "Caçarola de Legumes", 22.00));
            this.Produtos.Add(new Produto(7, "Água", 3.00));
            this.Produtos.Add(new Produto(8, "Copo de Suco", 7.00));
            this.Produtos.Add(new Produto(9, "Refrigerante Orgânico", 7.00));
            this.Produtos.Add(new Produto(10, "Cerveja Vegana", 9.00));
            this.Produtos.Add(new Produto(11, "Taça de Vinho Vegano", 18.00));
        }
    }
}
